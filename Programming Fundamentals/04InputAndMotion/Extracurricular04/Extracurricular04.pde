PVector position, direction, velocity, gravity;
float acceleration = 200f;
float friction = 0.91f;
float maxSpeed = 400f;
int ballSize = 33;
boolean gravityOn = false;

float deltaTime;
long time;


void setup()
{
  size(512, 512);
  frameRate(30);
  time = millis();
  position = new PVector(width/2,height/2);
  gravity = new PVector(0, 100f);
  direction = new PVector();
  velocity = new PVector();
  ellipseMode(CENTER);
  noStroke();
}

void draw()
{
  background(0, 150, 140);
  fill(25, 255, 177);
  long currentTime = millis();
  deltaTime = (currentTime - time) * 0.001f;

  direction.normalize();

  wrapBall();

  if(gravityOn)
  {
    applyGravity();
  }

  calculateMovement();

  position.x += velocity.x * deltaTime;
  position.y += velocity.y * deltaTime;

  ellipse(position.x, position.y, ballSize, ballSize);

  time = currentTime;
}

void wrapBall()
{
  //Wrap ball from left to right or right to left.
  if(position.x > width)
  {
    position.x = 1;
  }
  if(position.x < 0)
  {
    position.x = width - 1;
  }

  //Makes the ball not move up or down from screen.
  if(!gravityOn && position.y > height)
  {
    position.y = height;
  }
  if(position.y < 0)
  {
    position.y = 1;
  }
}

void applyGravity()
{
  velocity.add(gravity);
  if(position.y  > height)
  {
    velocity.y *= -0.95;
  }
}

void calculateMovement()
{
  if(direction.x != 0)
  {
    velocity.x += direction.x * acceleration * deltaTime;
    if(abs(velocity.x) > maxSpeed)
    {
      velocity.x = maxSpeed * direction.x * deltaTime;
    }
  }
  else 
  {
    velocity.x *= friction;
  }

  if(direction.y != 0)
  {
    velocity.y += direction.y * acceleration * deltaTime;
    if(abs(velocity.y) > maxSpeed)
    {
      velocity.y = maxSpeed * direction.y * deltaTime;
    }
  }
  else
  {
    velocity.y *= friction;
  }
}

void keyPressed()
{
  if (keyCode == LEFT || key == 'a')
    direction.x = -1;
  else if (keyCode == RIGHT || key == 'd')
    direction.x = 1;

  if (keyCode == UP || key == 'w')
    direction.y = -1;
  else if (keyCode == DOWN || key == 's')
    direction.y = 1;

  if (key == 'g')
  {
    gravityOn = !gravityOn;
  }
}

void keyReleased()
{
   if (keyCode == LEFT || key == 'a')
    direction.x = 0;
  else if (keyCode == RIGHT || key == 'd')
    direction.x = 0;

  if (keyCode == UP || key == 'w')
    direction.y = 0;
  else if (keyCode == DOWN || key == 's')
    direction.y = 0;
}