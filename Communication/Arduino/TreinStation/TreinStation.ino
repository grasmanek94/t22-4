#include <Adafruit_NeoPixel.h>
#include "message.h"
#include "ledcontrol.h"

#include "D:/Development/GitHub/t22-4/Communication/Enumerators/Actions.cs" //Waar Rafal zijn Actions.cs heeft

LedControl * ledControl = NULL;
Message message;

void setup()
{
  Serial.begin(9600);
  ledControl = new LedControl(50/*leds*/, 6/*pin*/);
  byte startup[6] = { 0, 50, 0, 120, 0, 120 };
  ledControl->UpdateLeds(startup);
}

void loop()
{
  int readchars = message.Read();
  
  if (readchars && !message.possiblyCorrupt && ledControl && message.action == CHANGE_LED_COLOR && message.dataLen == 6)
  {
    ledControl->UpdateLeds(message.data);
  }
  
  if (readchars)
  {
    message.Write();
  }
}
