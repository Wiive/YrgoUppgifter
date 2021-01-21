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

int frame = 0;
int numberOfPoints = 50;

public void setup()
{	
	
  frameRate(30);
	strokeWeight(4);
}

public void draw()
{
	background(136,209,255);
	stroke(255,202,248);

	drawSprial(20);
  drawCircle(50);
  frame++;
}

public void drawSprial(int n)
{
	for (int i = 0; i < n; i++)
	{
		float x = cos((frame * 0.005f)* i * TWO_PI/n) * i * 5;
    	float y = sin((frame * 0.005f) * i * TWO_PI/n) * i * 5;
    	ellipse(width/2 + x, height/2 + y, 4, 4);
	}
}

public void drawCircle(int n)
{
	for (int i = 0; i < n; i++)
	{
		float x = cos((frame * 0.005f) * i * TWO_PI/n) * 100;
    	float y = sin((frame * 0.005f) * i * TWO_PI/n) * 100;
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
