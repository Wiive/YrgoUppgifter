class LouBul implements WalkerInterface {
  
  int screenWidth;
  int screenHeight;

  PVector currrentPosision;
  PVector up = new PVector(0, -1);
  PVector down = new PVector(0, 1);
  PVector left = new PVector(-1, 0);
  PVector right = new PVector(1, 0);
  int switchInput = 1;
  //Do not use processing variables like width or height

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
    screenWidth = playAreaWidth;
    screenHeight = playAreaHeight;
    currrentPosision = new PVector((int)x, (int)y);
    return new PVector((int)x, (int)y);
  }

  PVector update()
  {
    
    if ((currrentPosision.y+1) == screenHeight){
      switchInput = 3;         
    }
    if ((currrentPosision.x+1) == screenWidth && (currrentPosision.y+1) < screenHeight){
      switchInput = 2;
    }
    if ((currrentPosision.x-1) == 0){
      switchInput = 0;            
    }
     if ((currrentPosision.y-1) == 0){
      switchInput = 1;            
    }
    

    //add your own walk behavior for your walker here.
    //Make sure to only use the outputs listed below.

    switch(switchInput) {
    case 0:
      currrentPosision = currrentPosision.add(left);
      print("left");
      return new PVector(-1, 0);
    case 1:
      currrentPosision = currrentPosision.add(right);
      print("right");
      return new PVector(1, 0);
    case 2:
      currrentPosision = currrentPosision.add(down);
      print("down");
      return new PVector(0, 1);
    case 3:
      currrentPosision = currrentPosision.add(up);
      print("up");
      return new PVector(0, -1);
    default:
      return new PVector(0, 0);
    }
  }
}

//All valid outputs:
// PVector(-1, 0);
// PVector(1, 0);
// PVector(0, 1);
// PVector(0, -1);

//Any other outputs will kill the walker!
