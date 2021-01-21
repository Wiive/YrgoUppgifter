class LouBul implements WalkerInterface {
  PVector playScreen;
  int frame = 0;

  PVector currrentPosision;
  PVector up = new PVector(0, -1);
  PVector down = new PVector(0, 1);
  PVector left = new PVector(-1, 0);
  PVector right = new PVector(1, 0);

  int switchInput = 1;
 
  boolean swapDirection;

  String getName()
  {
    return "Lady Wiive Buller"; //When asked, tell them our walkers name
  }

  PVector getStartPosition(int playAreaWidth, int playAreaHeight)
  {
    //Select a starting position or use a random one.
    float x = (int) random(0, playAreaWidth/2);
    float y = (int) random(0, playAreaHeight);

    //a PVector holds floats but make sure its whole numbers that are returned!
    playScreen = new PVector(playAreaWidth, playAreaHeight);
    currrentPosision = new PVector((int)x, (int)y);
    return new PVector((int)x, (int)y);
  }

  PVector update()
  {            
    swapDirection = alovidToMove(currrentPosision, playScreen);
    if (swapDirection)
    {
      if (frame % 5 == 0)
      {
        switchInput = (int)random(0, 4);
      }
    }
    else
    {        
        switchInput = newDirection(currrentPosision, playScreen);
    }

    frame++;

    switch(switchInput) {
    case 0:
      currrentPosision = currrentPosision.add(left);
      return new PVector(-1, 0);
    case 1:
      currrentPosision = currrentPosision.add(right);
      return new PVector(1, 0);
    case 2:
      currrentPosision = currrentPosision.add(down);
      return new PVector(0, 1);
    default:
      currrentPosision = currrentPosision.add(up);
      return new PVector(0, -1);
    }       
  }
}


boolean alovidToMove(PVector vector, PVector screenSize)
{
 if ((vector.y+10) < screenSize.y && (vector.x+10) < screenSize.x
             && (vector.x-10) > 0 && (vector.y-10) > 0)
  {
  return true;
  }
  else
  {
    return false;
  }
}

int newDirection(PVector currrentPosision, PVector screenSize)
{
  if(currrentPosision.x < 10)
  {
      return 1;
  }
  if(currrentPosision.x > screenSize.x-10)
  {
      return 0;
  }

   if(currrentPosision.y < 10)
  {
      return 2;
  }
  if(currrentPosision.y > screenSize.y-10)
  {
      return 3;
  }
  else
    return (int)random(0,4);
    
}

