class Player
{
  PVector position;
  PVector velocity = new PVector();
  PVector acceleration = new PVector();

  //Player movement speed variables
  float accelerationMultiplyer = 0.75;
  float deaccelerationMultiplyer = 0.15;
  float speed = 60;
  float maxSpeed = 8;
  float size;

  Player(float x, float y, float s)
  {
    //Set startposition in the middle of the screen
    position = new PVector(x,y);
    size = s;
  }

  void update()
  {
    acceleration = input();

    acceleration.mult(accelerationMultiplyer * speed * deltaTime);

    if (acceleration.mag() == 0)
    {
      acceleration.x -= velocity.x * deaccelerationMultiplyer * speed * deltaTime;
      acceleration.y -= velocity.y * deaccelerationMultiplyer * speed * deltaTime;
    }

    //Update Velocity by adding acceleration.
    velocity.add(acceleration);
    velocity.limit(maxSpeed);

    //Create a new temporary vector so deltaTime doesn't change our real velocity
    PVector move = velocity.copy();
    move.mult(speed * deltaTime);

    //Add our adjusted velocity to our player
    position.add(move);
  }

  void draw()
  {
    //Screen bounderies
    if ((position.x > width - size/2) || (position.x < size/2))
    {
      velocity.x = velocity.x * -1;
    }
    if ((position.y > height - size/2) || (position.y < size/2))
    {
      velocity.y = velocity.y * -1; 
    }

    fill(250,250,250);
    ellipse(position.x, position.y, size, size);
  }
}