class BallManager
{
  Ball[] balls;
  int numberOfBalls;


  BallManager(int n)
  {
    numberOfBalls = n;
    balls = new Ball[numberOfBalls];

    for (int i = 0; i < balls.length; ++i) {
    balls[i] = new Ball(random(0, width), 0, 20,
      30 + int(random(-i*10,i*10)),
      229 + int(random(-i,i)),
      136 + int(random(-i*10,i*10)));
    }
  }
  
  void update()
  {
    //Checking collisions between player and balls
    for (int i = 0; i < balls.length; ++i) {
      boolean hasCollided = roundCollision(player.position.x,
        player.position.y,
        player.size/2,
        balls[i].position.x,
        balls[i].position.y,
        balls[i].ballSize/2);
      if(hasCollided){
        gameOver = true;
      }
    }

    for (int i = 0; i < balls.length; ++i) {
      balls[i].update();
      balls[i].draw();
    }

    if(timeCount >= 3){
        addBall();
    }
  }

  void addBall()
  {
    print("Trying to add one ball. ");
    if(numberOfBalls < 100){ 
      numberOfBalls++;
      Ball addBall = new Ball(random(0, width), 0, 20, 30, 229, 136);
      balls = (Ball[])append(balls, addBall);
      print("NumberOfBalls: " + numberOfBalls + " ");
      timeCount = 0;
    }
    
    else{
      print("100 balls on the screen. ");
      timeCount = 0;
    }
  }
}