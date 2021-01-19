class LouBul implements WalkerInterface {
  PVector screen;
  int frame = 0;

  PVector currrentPosision;
  PVector up = new PVector(0, -1);
  PVector down = new PVector(0, 1);
  PVector left = new PVector(-1, 0);
  PVector right = new PVector(1, 0);

  int switchInput = 1;
 
  boolean swapDirection;
  int previusDirection;

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
    screen = new PVector(playAreaWidth, playAreaHeight);
    currrentPosision = new PVector((int)x, (int)y);
    return new PVector((int)x, (int)y);
  }

  PVector update()
  {            
    swapDirection = alovidToMove(currrentPosision, screen);
    if (swapDirection)
    {
      if (frame % 5 == 0)
      {
        switchInput = (int)random(0, 4);
      }
    }
    else
    {
        
      switchInput = (int)random(0, 4);      
    }
    frame++;

    switch(switchInput) {
    case 0:
      currrentPosision = currrentPosision.add(left);
      constrainWalker(currrentPosision, screen);
      return new PVector(-1, 0);
    case 1:
      currrentPosision = currrentPosision.add(right);
        constrainWalker(currrentPosision, screen);
      return new PVector(1, 0);
    case 2:
      currrentPosision = currrentPosision.add(down);
        constrainWalker(currrentPosision, screen);
      return new PVector(0, 1);
    default:
      currrentPosision = currrentPosision.add(up);
        constrainWalker(currrentPosision, screen);
      return new PVector(0, -1);
    }
    

   
  }
}

void constrainWalker(PVector vector, PVector bounderies)
{
   vector.x = constrain(vector.x, 0, bounderies.x);
   vector.y = constrain(vector.y, 0, bounderies.y);
}


boolean alovidToMove(PVector vector, PVector screenSize)
{
 if ((vector.y+10) < screenSize.y
    && (vector.x+10) < screenSize.x
    && (vector.x-10) > 0
    && (vector.y-10) > 0)
 {
  return true;
 }
  else return false;
}
