import processing.core.*; 
import processing.data.*; 
import processing.event.*; 
import processing.opengl.*; 

import java.util.HashMap; 
import java.util.ArrayList; 
import java.io.File; 
import java.io.BufferedReader; 
import java.io.PrintWriter; 
import java.io.InputStream; 
import java.io.OutputStream; 
import java.io.IOException; 

public class Assignment02 extends PApplet {

  
//This file is only for testing your movement/behavior.
//The Walkers will compete in a different program!

WalkerInterface walker;
PVector walkerPos;

public void setup() {
  

  //Create a walker from the class Example it has the type of WalkerInterface
  walker = new LouBul();

  walkerPos = walker.getStartPosition(width, height);
}

public void draw() {
  point(walkerPos.x, walkerPos.y);
  walkerPos.add(walker.update());
}
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

  public String getName()
  {
    return "Lady Wiive Buller"; //When asked, tell them our walkers name
  }

  public PVector getStartPosition(int playAreaWidth, int playAreaHeight)
  {
    //Select a starting position or use a random one.
    float x = (int) random(0, playAreaWidth/2);
    float y = (int) random(0, playAreaHeight);

    //a PVector holds floats but make sure its whole numbers that are returned!
    playScreen = new PVector(playAreaWidth, playAreaHeight);
    currrentPosision = new PVector((int)x, (int)y);
    return new PVector((int)x, (int)y);
  }

  public PVector update()
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


public boolean alovidToMove(PVector vector, PVector screenSize)
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

public int newDirection(PVector currrentPosision, PVector screenSize)
{
  if(currrentPosision.x < 2)
  {
      return 1;
  }
  if(currrentPosision.x > screenSize.x-2)
  {
      return 0;
  }

   if(currrentPosision.y < 2)
  {
      return 2;
  }
  if(currrentPosision.y > screenSize.y-2)
  {
      return 3;
  }
  else
    return (int)random(0,4);
    
}

interface WalkerInterface {
  //returns the name of the walker, should be your name!
  public String getName();

  //returns the start position for the walker
  public PVector getStartPosition(int playAreaWidth, int playAreaHeight);

  //updates the walker position
  //the walker is only allowed to take one step, left/right or up/down
  //If the walker moves diagonally or too long, it will be killed.
  public PVector update();
}
  public void settings() {  size(500, 500); }
  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "Assignment02" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
