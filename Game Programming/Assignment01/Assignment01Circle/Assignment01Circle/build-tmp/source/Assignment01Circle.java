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

public class Assignment01Circle extends PApplet {

int numberOfPoints = 50;

public void setup()
{	
	
	strokeWeight(5);
}

public void draw()
{
	background(0);
	stroke(255);

	drawSprial(20);
    drawCircle(50);
}

public void drawSprial(int n)
{
	for (int i = 0; i < n; i++)
	{
		float x = cos(i * TWO_PI/n) * i * 5;
    	float y = sin(i * TWO_PI/n) * i * 5;
    	ellipse(width/2 + x, height/2 + y, 4, 4);
	}
}

public void drawCircle(int n)
{
	for (int i = 0; i < n; i++)
	{
		float x = cos(i * TWO_PI/n) * 100;
    	float y = sin(i * TWO_PI/n) * 100;
    	ellipse(width/2 + x, height/2 + y, 4, 4);
	}
}
  public void settings() { 	size(700, 700); }
  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "Assignment01Circle" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
