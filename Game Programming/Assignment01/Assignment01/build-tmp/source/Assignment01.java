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

public class Assignment01 extends PApplet {

int frame = 0;
int numberOfPoints = 100;

public void setup()
{
	
	strokeWeight(5);
}

public void draw()
{
	background(255);
  stroke(21);
	sinCurve();
  stroke(18,187,0);
  cosCurve();	
  frame++;
}

public void sinCurve()
{    
  for (int i = 0; i < numberOfPoints; i++)
  {
    point(405 + i * 2, height/2 + sin((frame * 0.044f) + i) * 171);
    
  }
}

public void cosCurve()
{
    for (int i = 0; i < numberOfPoints; i++)
  {
    point(290 + i * 2, height/2 + cos((frame * 0.044f) + i) * 171);
    
  }
}
  public void settings() { 	size(700, 700); }
  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "Assignment01" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
