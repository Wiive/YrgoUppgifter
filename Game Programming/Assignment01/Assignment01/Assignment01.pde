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
    point(373 + i * 3, height/2 + sin((frame * 0.023) + i) * 166);
    
  }
}

void cosCurve()
{
    for (int i = 0; i < numberOfPoints; i++)
  {
    point(50 + i * 3, height/2 + cos((frame * 0.023) + i) * 171);
    
  }
}
