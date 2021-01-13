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

public class FizzBuzz extends PApplet {
  public void setup() {
String three = "Fizz";
String five = "Buzz";


for (int i = 1; i <= 100; i++){
	if (i % 3 == 0)
	{		
		if (i % 5 == 0)
		{
			println(three + five);
		}
		else{
			println(three);
		}		
	}
	else if (i % 5 == 0){
		println(five);
	}
	
	else{
			println(i);
	}
}
    noLoop();
  }

  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "FizzBuzz" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
