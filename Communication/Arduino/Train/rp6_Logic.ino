void RP6_State() {
  message.Write();
  switch ( message.data[0] ) {
    case 0: //Forward
      Rp6.changeDirection( RP6_FORWARD );
      Rp6.moveAtSpeed(255, 255);
      break;
    case 1: //Forward Left
      Rp6.changeDirection( RP6_FORWARD );
      Rp6.moveAtSpeed(50, 255);
      break;
    case 2: //Forward Right
      Rp6.changeDirection( RP6_FORWARD );
      Rp6.moveAtSpeed(255, 50);
      break;
    case 3: //Backward
      Rp6.changeDirection( RP6_BACKWARD );
      Rp6.moveAtSpeed(255, 255);
      break;
    case 4: //Backward Left
      Rp6.changeDirection( RP6_BACKWARD );
      Rp6.moveAtSpeed(50, 255);
      break;
    case 5: //Backward Right
      Rp6.changeDirection( RP6_BACKWARD );
      Rp6.moveAtSpeed(255, 50);
      break;
    case 6: //Left
      Rp6.changeDirection( RP6_LEFT );
      Rp6.moveAtSpeed(255, 255);
      break;
    case 7: //Right
      Rp6.changeDirection( RP6_RIGHT );
      Rp6.moveAtSpeed(255, 255);
      break;
    default: //Stop
      Rp6.stop();
      break;
  }
}
