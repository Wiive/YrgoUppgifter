PVector posistion, betweenV, velocity;
float speed = 0.015;

void setup()
{
  size(600, 600);
  posistion = new PVector(300,300);
  betweenV = new PVector();
  velocity = new PVector();
}

void draw()
{
  background(12,12,12);
  stroke(255);
  fill(0);
  strokeWeight(2f);

  ellipse(posistion.x, posistion.y, 66, 66);
  
  posistion.add(velocity);

  if(mousePressed == true)
  {
    line(posistion.x, posistion.y, mouseX, mouseY);
  }
  bounce();  
}

void bounce()
{  
  //Bounce on screen
  if ((posistion.x > width) || (posistion.x < 0))
  {
      velocity.x = velocity.x * -1;
  }

  if ((posistion.y > height) || (posistion.y < 0))
  {
      velocity.y = velocity.y * -1;
  }  
       
}

void mousePressed()
{
	posistion.x = mouseX;
	posistion.y = mouseY;
	velocity.x = 0;
	velocity.y = 0;
}

void mouseReleased()
{
	betweenV.x = posistion.x - mouseX;
    betweenV.y = posistion.y - mouseY;
    velocity.x = betweenV.x * speed * -1;
    velocity.y = betweenV.y * speed * -1;
}
