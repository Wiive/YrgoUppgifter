float lineSpace = 10f;

void setup()
{
	size(600, 600);
}

void draw()
{
	background(0, 228, 255);
	stroke(202,202, 202);
	strokeWeight(1f);

	for (int i = 0; i < width; i += lineSpace)
	{
		if( i % 3 == 0)
     	{
        stroke(0);
      	}
      	else
      	stroke(202,202,202);

      	line(i, 0, width, i); //Upper right corner
      	line(i, 0, 0, width - i); // Upper left corner
      	line(width, i, width - i, width); // Lower right corner
      	line(0, i, i , width); // Lower left corner
	}

}
