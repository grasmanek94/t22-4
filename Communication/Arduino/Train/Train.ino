#include <Wire.h>
#include "Rp6.h"

#include <Arduino.h>
#include "message.h"
#include "wagon.h"
//#include "D:\\Gebruikers\\Documenten\\School\\p3\\Proftaak\\t22-4\\Communication\Enumerators\\Actions.cs"
#include "D:/Development/GitHub/t22-4/Communication/Enumerators/Actions.cs" //Waar Rafal zijn Actions.cs heeft

const int inside = A0;
const int outside = A1;
const int numberOfWagons = 4;
int personsIn = 0;
const int amountOfSeats = 4;
int seats[amountOfSeats] = { 2, 3, 4, 5};

Wagon *wagons[numberOfWagons];

Message message;
bool connected = false;
int connectiontimer = 0;
int timenow;
int lastUpdate = 0;
int which = 0;

void setup()
{
  Serial.begin(9600);

  Rp6.begin();

  for (int i = 0; i < amountOfSeats - 1; i++)
  {
    pinMode(seats[i], INPUT);
  }
  createWagonsWithTestData();

  CalibrateInfrarood();
}

void loop()
{
  DoorPersonCounter();

  int readchars = message.Read();
  if (readchars)
  {
    //message.Write();//echo
    if (!message.possiblyCorrupt)
    {
      switch (message.action)
      {
        case REQUEST_TRAIN_TRAFFIC_UPDATE:
          wagons[0]->personsIn = personsIn;
          wagons[0]->seatsTaken = countSeatsTaken();
          message.action = TRAIN_TRAFFIC_UPDATE;
          for (int i = 0; i < numberOfWagons; i++)
          {
            message.data[i * 3] = i;
            message.data[i * 3 + 1] = wagons[i]->personsIn;
            message.data[i * 3 + 2] = wagons[i]->seatsTaken;
          }
          message.dataLen = numberOfWagons * 3;
          message.Write();
          break;
        case RP6_MOVE:
          RP6_State();
          break;
        case TRAIN_CONNECTIONOK:
          connected = true;
          break;
        case TRAIN_I_AM_GOING_TO_NEXT_STATION:
          message.action = TRAIN_I_AM_GOING_TO_NEXT_STATION;
          message.dataLen = 0;
          message.Write();
          break;
        default:
          break;
      }
    }
  }

  timenow = millis();

  if (!connected && (timenow - connectiontimer) > 1000)
  {
    connectiontimer = timenow;
    message.action = TRAIN_CONNECTME;
    message.WriteString("ITTF_TRAIN_01");
    message.Write();
  }
}

void createWagonsWithTestData()
{
  for (int i = 0; i < numberOfWagons; i++)
  {
    wagons[i] = new Wagon(i);
  }
  wagons[1]->personsIn = 8;
  wagons[1]->seatsTaken = 8;
  wagons[2]->personsIn = 15;
  wagons[2]->seatsTaken = 11;
  wagons[3]->personsIn = 13;
  wagons[3]->seatsTaken = 13;
}

///////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///// ----------------------------For testing-------------------------------\\\\\\
///////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
/*if (connected && (timenow - lastUpdate) > 4000)
  {
    lastUpdate = timenow;
    which ^= 1;
    if (which)
    {
      wagons[0]->personsIn = 10;
      wagons[0]->seatsTaken = 9;
      message.action = TRAIN_TRAFFIC_UPDATE;
      for (int i = 0; i < numberOfWagons; i++)
      {
        message.data[i * 3] = i;
        message.data[i * 3 + 1] = wagons[i]->personsIn;
        message.data[i * 3 + 2] = wagons[i]->seatsTaken;
      }
      message.dataLen = numberOfWagons * 3;
      message.Write();
    }
    else
    {
      message.action = TRAIN_I_AM_GOING_TO_NEXT_STATION;
      message.dataLen = 0;
      message.Write();
    }
  }
*/
///////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///// ----------------------------For testing-------------------------------\\\\\\
///////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
