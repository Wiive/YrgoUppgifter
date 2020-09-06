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

public class Name extends PApplet {

//Variables
int bgcolor = 0;
int startPos = 750;
int currentPos;
float eatAnim = -3;
float eatAnimlower = 2;
boolean add = true;
int timer = millis();

public void setup()
{
  
  frameRate(30);
  noStroke();
  currentPos = startPos;
}

public void drawL(int x, int y)
{
  //Drawing blue L
  fill(0, 50 , 255);
  rect(x, y, 10, 50);
  rect(x, y+50, 50, 10);
}

public void drawO(int x, int y)
{
  //Drawing blue O
  ellipseMode(CORNER);  
  fill(0, 50 , 228); 
  ellipse(x, y, 52, 60);  
  //Drawing whole in O
  ellipseMode(CORNER);  
  fill(bgcolor);
  ellipse(x+20, y+30, 20, 20);  
}


public void drawU(int x, int y)
{
    //Drawing blue U
  ellipseMode(CORNER);  
  fill(0, 50 , 255); 
  ellipse(x, y, 52, 60);  
  //Drawing whole in U
  ellipseMode(CORNER);  
  fill(bgcolor);
  ellipse(x+14, y-10, 25, 30);  
}

public void drawI(int x, int y)
{
  //Drawing blue I
  fill(0, 50 , 255); 
  rect(x, y, 10, 40);
  ellipse(x-1, y-20, 13, 13);  
}

public void drawS(int x, int y)
{
  //Drawing blue S
  ellipseMode(CORNER);  
  fill(0, 50 , 255); 
  ellipse(x, y, 52, 60);  
  //Drawing whole in S
  ellipseMode(CORNER);  
  fill(bgcolor);
  ellipse(x-3, y+33, 26, 20);  
  ellipseMode(CORNER);  
  fill(bgcolor);
  ellipse(x+31, y+12, 26, 20);  
}

public void drawE(int x, int y, float z, float a)
{
  //Drawing E as Pacman
  fill(255, 244 , 0); 
  arc(x, y, 70, 70, z, a, PIE);
}

public void draw()
{
  background(bgcolor);
  print("Timer " + timer+"  ");
  print("CurrentPos " + currentPos+"  ");
  drawL(200, 200);
  drawO(260, 200);
  drawU(320, 200);
  drawI(385, 220);
  drawS(410, 200);
  timer++;
  //Animate Pac-Man
  if(currentPos > -100)
  {
    drawE(currentPos, 193, eatAnim, eatAnimlower);
    if(add)
    {
    eatAnim += 0.15f;
    eatAnimlower -= 0.01f;
    } 
    else
    eatAnim -= 0.15f;
    eatAnimlower += 0.01f;
    if(eatAnim  <= -4)
    {
     add = true;
    } 
    if(eatAnim >= -2)
    {
     add = false;
    }
    if(timer > 83 && timer < 100)
    {
    currentPos = 501;
    }
    else
    currentPos -=3;
   }
   else
   {
   currentPos = startPos;
   eatAnim = -3;
   eatAnimlower = 2;
   timer = 0;
   }

}
  public void settings() {  size(768, 432); }
  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "Name" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
