int insideValue;
int outsideValue;
int buffer = 100;
int normalInside;
int normalOutside;

void CalibrateInfrarood(){
  for (int i = 0; i < 10; i++)
  {
    normalInside += analogRead(inside);
    normalOutside += analogRead(outside);
    delay(200);
  }
  normalInside = normalInside / 10;
  normalOutside = normalOutside / 10;
  Serial.print("Normal value inside: ");
  Serial.println(normalInside);
  Serial.print("Normal value outside: ");
  Serial.println(normalOutside);
  Serial.print("There are 0 people inside");
}

void DoorPersonCounter(){
  insideValue = analogRead(inside);
  outsideValue = analogRead(outside);
  if (((insideValue + buffer) < normalInside) && (outsideValue > (normalOutside - buffer)))
  {
      delay(5);
      while (analogRead(outside) < (normalOutside - buffer))
      { 
        if (((analogRead(inside) + buffer) > normalInside))
        {
          personsIn--;
          break;
        }
      }
  }
  if (((outsideValue + buffer) < normalOutside) && (insideValue > (normalInside - buffer)))
  {
      delay(5);
      while (analogRead(inside) < (normalInside - buffer))
      {
        if (((analogRead(outside) + buffer) > normalOutside))
        {
          personsIn++;
          break;
        }
      }
  }
}

int countSeatsTaken()
{ 
  int seatsTaken = 0;
  for (int i = 0; i < amountOfSeats; i++)
  {
    if (digitalRead(seats[i]) == HIGH)
    {
      seatsTaken++;
    }
  }
  return seatsTaken;
}
