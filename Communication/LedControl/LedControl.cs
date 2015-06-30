using System.Drawing;
using Communication.Enumerators;

namespace Communication.LedControl
{
	public class LedControl
	{
		private readonly Message _controlMessage;
		private readonly Arduino _arduino;
		public int MaxLeds { private set; get; }

		private readonly byte _pin;

		public LedControl(Arduino arduino, byte pin, byte amountOfLeds)
		{
			this.MaxLeds = amountOfLeds;
			this._pin = pin;

			_arduino = arduino;
			_controlMessage = new Message();
		}

		/// <summary>
		/// Initializes the led strip.
		/// </summary>
		/// <returns>The amount of bytes writen</returns>
		public byte InitializeLedStrip ()
		{
			_controlMessage.Action = (byte)Actions.INITIALIZE_LED_STUFF;
			_controlMessage.Data [0] = (byte)MaxLeds;
			_controlMessage.Data [1] = _pin;
			_controlMessage.DataLen = 2;

			return _arduino.Write(_controlMessage);
		}

		/// <summary>
		///     Change the color in RGB and brightness of a section of leds. And writes the command to the board.
		/// </summary>
		/// <param name="beginLed"></param>
		/// <param name="endLed"></param>
		/// <param name="red"></param>
		/// <param name="green"></param>
		/// <param name="blue"></param>
		/// <param name="brightness"></param>
		/// <returns>Returns the amout of bytes writen</returns>
		public byte ChangeColor (byte beginLed, byte endLed, byte red, byte green, byte blue, byte brightness)
		{
			_controlMessage.Action = (byte)Actions.CHANGE_LED_COLOR;
			_controlMessage.Data [0] = beginLed;
			_controlMessage.Data [1] = endLed;
			_controlMessage.Data [2] = red;
			_controlMessage.Data [3] = green;
			_controlMessage.Data [4] = blue;
			_controlMessage.Data [5] = brightness;
			_controlMessage.DataLen = 6;

			return _arduino.Write(_controlMessage);
		}

		/// <summary>
		/// Change the color to any given color for the first led till to last led given. The color is formated as HEX color
		/// </summary>
		/// <param name="beginLed">First led to change</param>
		/// <param name="endLed">pre last led to change</param>
		/// <param name="color">Color formated in HEX</param>
		/// <returns>Returns the amout of bytes writen</returns>
		public byte ChangeColor (byte beginLed, byte endLed, uint color)
		{
			return ChangeColor (beginLed, endLed, 
				(byte)(color >> 24 & 0xFF), 
				(byte)(color >> 16 & 0xFF), 
				(byte)(color >> 8 & 0xFF), 
				(byte)(color & 0xFF));
		}

		/// <summary>
		/// Change the color to any given color for the first led till to last led given
		/// </summary>
		/// <param name="beginLed">First led to change</param>
		/// <param name="endLed">pre last led to change</param>
		/// <param name="color">Color object from c#</param>
		/// <returns>Returns the amout of bytes writen.</returns>
		public byte ChangeColor (byte beginLed, byte endLed, Color color)
		{
			return ChangeColor (beginLed, endLed, 
				color.R, 
				color.G, 
				color.B, 
				color.A);
		}

		/// <summary>
		/// Changes the color.
		/// </summary>
		/// <returns>The amount of bytes writen.</returns>
		/// <param name="beginLed">Begin led.</param>
		/// <param name="endLed">End led.</param>
		/// <param name="red">Red.</param>
		/// <param name="green">Green.</param>
		/// <param name="blue">Blue.</param>
		/// <param name="brightness">Brightness.</param>
		public byte ChangeColor (int beginLed, int endLed, int red, int green, int blue, int brightness)
		{
			return ChangeColor ((byte)beginLed, (byte)endLed, (byte)red, (byte)green, (byte)blue, (byte)brightness);
		}

		/// <summary>
		/// Changes the color.
		/// </summary>
		/// <returns>The amount of bytes writen.</returns>
		/// <param name="beginLed">Begin led.</param>
		/// <param name="endLed">End led.</param>
		/// <param name="color">Color.</param>
		public byte ChangeColor (int beginLed, int endLed, uint color)
		{
			return ChangeColor ((byte)beginLed, (byte)endLed, color);
		}

		/// <summary>
		/// Changes the color.
		/// </summary>
		/// <returns>The amount of bytes writen.</returns>
		/// <param name="beginLed">Begin led.</param>
		/// <param name="endLed">End led.</param>
		/// <param name="color">Color.</param>
		public byte ChangeColor (int beginLed, int endLed, Color color)
		{
			return ChangeColor ((byte)beginLed, (byte)endLed, color);
		}
	}
}