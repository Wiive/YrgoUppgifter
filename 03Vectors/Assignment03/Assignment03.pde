PVector circleV, betweenV, velocity;
float speed = 0.015;

void setup()
{
	size(600, 600);
	circleV = new PVector(300,300);
	betweenV = new PVector();
	velocity = new PVector();
}

void draw()
{
	background(12,12,12);
	stroke(255);
	fill(0);
	strokeWeight(2f);

	ellipse(circleV.x, circleV.y, 66, 66);
	circleV.add(velocity);

	if(mousePressed == true)
	{
		line(circleV.x, circleV.y, mouseX, mouseY);
		betweenV.x = circleV.x - mouseX;
		betweenV.y = circleV.y - mouseY;
		velocity.x = betweenV.x * speed * -1;
		velocity.y = betweenV.y * speed * -1;
	}

	//Bounce on screen
	if ((circleV.x > width) || (circleV.x < 0))
	{
	    velocity.x = velocity.x * -1;
	}

	if ((circleV.y > height) || (circleV.y < 0))
	{
	    velocity.y = velocity.y * -1;
	}
		    
}
