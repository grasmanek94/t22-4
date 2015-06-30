#if (ARDUINO >= 100)
 #include <Arduino.h>
#else
 #include <WProgram.h>
 #include <pins_arduino.h>
#endif

class Message
{
    byte begin[2];
    byte end[2];
  public:
    byte action;
    byte dataLen;
    byte data[59];
    bool possiblyCorrupt;

    Message()
    {
      begin[0] = '{';
      begin[1] = '{';
      end[0] = '}';
      end[1] = '}';
    }

    //returns the ammount of data that has been succesfully read
    byte Read()
    {
      if (Serial.available() > 5 &&
          Serial.read() == begin[0] &&
          Serial.read() == begin[1])
      {
        //Read action & data lenght
        Serial.readBytes((char*)&action, 1);
        Serial.readBytes((char*)&dataLen, 1);
        if (dataLen > 58)
        {
          dataLen = 58;
        }
        Serial.readBytes((char*)data, dataLen);
        data[dataLen] = 0;

        //Corruption check
        byte corruptioncheck[2];
        Serial.readBytes((char*)&corruptioncheck, 2);

        possiblyCorrupt = *((uint16_t*)corruptioncheck) != *((uint16_t*)end);

        return 6 + dataLen;
      }
      return 0;
    }

    char * ReadString()
    {
      if (Read())
      {
        return (char*)data;
      }
      return 0;
    }

    //returns the amount of bytes succesfully written
    byte Write()
    {
      byte written = 0;
      written += Serial.write((const uint8_t*)begin, 2);
      written += Serial.write(action);
      written += Serial.write(dataLen);
      written += Serial.write((const uint8_t*)data, dataLen);
      written += Serial.write((const uint8_t*)end, 2);
      return written;
    }

    byte WriteString(char * str)
    {
      dataLen = strlen(str) + 1;
      memcpy(data, str, dataLen);
      return Write();
    }
};
