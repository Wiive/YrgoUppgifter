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

public void setup()
{
  
  background(bgcolor);
  frameRate(30);
  noStroke();

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
  fill(0, 50 , 255); 
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

public void drawE(int x, int y)
{
  //Drawing E as Pacman
  fill(234, 255 , 0); 
  arc(x, y, 65, 65, -3, PIE-QUARTER_PI, PIE);
}

public void draw()
{
  clear();
  drawL(200, 200);
  drawO(260, 200);
  drawU(320, 200);
  drawI(385, 220);
  drawS(410, 200);
  drawE(477, 193);
}

/*//Old values for reference 
  //Drawing blue L
  fill(0, 50 , 255);
  rect(200, 200, 10, 50);
  rect(200, 250, 50, 10);

  //Drawing blue O
  ellipseMode(CORNER);  
  fill(0, 50 , 255); 
  ellipse(260, 200, 52, 60);  
  //Drawing whole in O
  ellipseMode(CORNER);  
  fill(bgcolor);
  ellipse(280, 230, 20, 20);

  //Drawing blue U
  ellipseMode(CORNER);  
  fill(0, 50 , 255); 
  ellipse(320, 200, 52, 60);  
  //Drawing whole in U
  ellipseMode(CORNER);  
  fill(bgcolor);
  ellipse(334, 190, 25, 30);

  //Drawing I
  fill(0, 50 , 255); 
  rect(385, 220, 10, 40);
  ellipse(384, 200, 13, 13);    

  //Drawing blue S
  ellipseMode(CORNER);  
  fill(0, 50 , 255); 
  ellipse(410, 200, 52, 60);  
  //Drawing whole in S
  ellipseMode(CORNER);  
  fill(bgcolor);
  ellipse(407, 233, 26, 20);  
  ellipseMode(CORNER);  
  fill(bgcolor);
  ellipse(441, 212, 26, 20);  

  //Drawing E
  fill(234, 255 , 0); 
  arc(477, 193, 65, 65, -3, PIE-QUARTER_PI, PIE);
*/
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
