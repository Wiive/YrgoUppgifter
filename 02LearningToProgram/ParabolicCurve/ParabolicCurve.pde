int numberOfLines = 10;

Axis line1;
Axis line2;

void setup()
{
  size(600, 600);
  line1 = new Axis(200f, 200f, 500f, 40f);
  line2 = new Axis(200f, 200f, 500f, 300f);
}

void draw()
{
  background(0, 128, 128);
  stroke(202,202, 202);
  strokeWeight(1f);


  drawAxis(line1, line2);

  for (int i = 0; i <= numberOfLines; i++)
  {
    stroke(202,202,202);

    if( i % 3 == 0)
    {
    stroke(0);
    }
   line(line2.x2 - i, line2.y2 - i * line1.y2 * 0.1, line2.x1 + i*2, line2.y1 - i * 2);
  } 
}

public class Axis
{
  float x1;
  float y1;
  float x2;
  float y2;


  Axis(float x1, float y1, float x2, float y2)
  {
    this.x1 = x1;
    this.y1 = y1;
    this.x2 = x2;
    this.y2 = y2;
  }

}

void drawAxis(Axis axis1, Axis axis2)
{
  line(axis1.x1, axis1.y1, axis1.x2 , axis1.y2);
  line(axis2.x1, axis2.y1, axis2.x2 , axis2.y2);
}