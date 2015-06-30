using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Net;

namespace Communication
{
    public class Arduino
    {
        private SerialPort _serialPort;

        /// <summary>
        /// Gets the COM port.
        /// </summary>
        /// <value>The COM port.</value>
        public string ComPort { get; private set; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { private set; get; }

        /// <summary>
        /// Gets the message list.
        /// </summary>
        /// <value>The message list.</value>
        public List<String> MessageList { private set; get; }

        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        /// <value><c>true</c> if this instance is connected; otherwise, <c>false</c>.</value>
        public bool IsConnected { private set; get; }

        /// <summary>
        /// Gets or sets the baud rate.
        /// </summary>
        /// <value>The baud rate.</value>
        public int BaudRate
        {
            get { return _serialPort.BaudRate; }
            set { _serialPort.BaudRate = value; }
        }

        public int BytesToRead { get { return _serialPort.BytesToRead; } }

        public IPEndPoint NextStation { get; set; }
        /// <summary>
        /// Initializes a new instance of the Arduino.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="comPort">COM port.</param>
        public Arduino(int id, string comPort)
        {
            NextStation = new IPEndPoint(1, 1);
            this.ComPort = comPort;
            this.Id = id;
            this._serialPort = new SerialPort(ComPort, 9600);
        }

        /// <summary>
        /// Initializes a new instance of the Arduino.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="comPort">COM port.</param>
        /// <param name="baudRate">Baud rate.</param>
        public Arduino(int id, string comPort, int baudRate)
            : this(id, comPort)
        {
            this.BaudRate = baudRate;
        }

        /// <summary>
        /// Connect to the Arduino board
        /// </summary>
        /// <returns>Retuns true is the the connection was succesful</returns>
        public bool Connect()
        {
            if (_serialPort.IsOpen)
            {
                IsConnected = true;
                return true;
            }
            try
            {
                _serialPort.Open();
            }
            catch (IOException exception)
            {
                Debug.Write("ERROR: " + exception.Message + "\n");
                throw;
            }
            IsConnected = true;
            return true;
        }

        /// <summary>
        /// Disconnect this arduino.
        /// </summary>
        public void Disconnect()
        {
            if (IsConnected)
            {
                IsConnected = false;
                _serialPort.Close();
            }
        }

        /// <summary>
        /// Write the specified data.
        /// </summary>
        /// <param name="data">Data.</param>
        public void Write(string data)
        {
            try
            {
                _serialPort.Write(data);
            }
            catch (InvalidOperationException e)
            {
                IsConnected = false;
                throw e;
            }
        }

        /// <summary>
        /// Write the specified buffer, offset and count.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="count">Count.</param>
        public void Write(byte[] buffer, int offset, int count)
        {
            try
            {
                _serialPort.Write(buffer, offset, count);
            }
            catch (InvalidOperationException)
            {
                IsConnected = false;
                throw;
            }
        }

        /// <summary>
        /// Reads the byte.
        /// </summary>
        /// <returns>The byte.</returns>
        public int ReadByte()
        {
            if (!this.IsConnected)
                return 0;
            return _serialPort.ReadByte();
        }

        /// <summary>
        /// Read the specified buffer, offset and count.
        /// </summary>
        /// <param name="buffer">Buffer.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="count">Count.</param>
        public int Read(byte[] buffer, int offset, int count)
        {
            if (!this.IsConnected)
                return 0;

            return _serialPort.Read(buffer, offset, count);
        }

        /// <summary>
        /// Read messages from the Arduino
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Returns amount of bytes</returns>
        public byte Read(MMessage message)
        {
            if (this.BytesToRead > 5 &&
                this.ReadByte() == message.Begin[0] &&
                this.ReadByte() == message.Begin[1])
            {
                //Read action & Data lenght
                message.Action = (byte)this.ReadByte();
                message.DataLen = (byte)this.ReadByte();
                if (message.DataLen > 58)
                {
                    message.DataLen = 58;
                }
                this.Read(message.Data, 0, message.DataLen);
                message.Data[message.DataLen] = 0;

                //Corruption check
                this.Read(message.Corruptioncheck, 0, 2);

                message.PossiblyCorrupt = message.Corruptioncheck[0] != message.End[0] || message.Corruptioncheck[1] != message.End[1];

                return (byte)(message.DataLen + 6);
            }
            return 0;
        }

        /// <summary>
        /// Write a message to Arduino
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public byte Write(MMessage message)
        {
            message.Header[0] = message.Action;
            message.Header[1] = message.DataLen;

            this.Write(message.Begin, 0, 2);
            this.Write(message.Header, 0, 2);
            this.Write(message.Data, 0, message.DataLen);
            this.Write(message.End, 0, 2);

            return (byte)(message.DataLen + 6);
        }
    }
}


