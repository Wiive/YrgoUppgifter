int frame = 0;
int numberOfPoints = 100;

void setup()
{
	size(700, 700);
	strokeWeight(5);
}

void draw()
{
	background(255);
  stroke(21);
	sinCurve();
  stroke(18,187,0);
  cosCurve();	
  frame++;
}

void sinCurve()
{    
  for (int i = 0; i < numberOfPoints; i++)
  {
    point(405 + i * 2, height/2 + sin((frame * 0.044) + i) * 171);
    
  }
}

void cosCurve()
{
    for (int i = 0; i < numberOfPoints; i++)
  {
    point(290 + i * 2, height/2 + cos((frame * 0.044) + i) * 171);
    
  }
}
