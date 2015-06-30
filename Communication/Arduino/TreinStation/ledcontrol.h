#include <Adafruit_NeoPixel.h>
class LedControl
{
    Adafruit_NeoPixel* led;
  public:
    //Expects that ::begin() is already called in 'led'
    LedControl(int leds, int pin)
    {
      led = new Adafruit_NeoPixel(leds, pin);
      led->begin();
    }

    //{{:<len><startindex><endindex><R><G><B><Brightness>}}
    void UpdateLeds(byte* data)
    {
      for (byte i = data[0]; i < data[1]; ++i)
      {
        led->setPixelColor(i, data[2], data[3], data[4]);
        led->setBrightness(data[5]);
      }
      led->show();
    }
};
