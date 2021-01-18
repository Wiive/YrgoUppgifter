int frame = 0;
int numberOfPoints = 50;

void setup()
{	
	size(700, 700);
	strokeWeight(5);
}

void draw()
{
	background(0);
	stroke(255);

	drawSprial(20);
  drawCircle(50);
  frame++;
}

void drawSprial(int n)
{
	for (int i = 0; i < n; i++)
	{
		float x = cos((frame * 0.005)* i * TWO_PI/n) * i * 5;
    	float y = sin((frame * 0.005) * i * TWO_PI/n) * i * 5;
    	ellipse(width/2 + x, height/2 + y, 4, 4);
	}
}

void drawCircle(int n)
{
	for (int i = 0; i < n; i++)
	{
		float x = cos(i * TWO_PI/n) * 100;
    	float y = sin(i * TWO_PI/n) * 100;
    	ellipse(width/2 + x, height/2 + y, 4, 4);
	}
}
