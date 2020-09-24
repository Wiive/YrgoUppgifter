//Time variables
float deltaTime;
long time;
float timeCount;

//Moving objects varibles
Player player;
BallManager ballmanager;
int numberOfBalls = 10;

//Lose varibles
boolean gameOver;
String gameOverText = "Game Over";

void setup()
{
  size(700, 520);
  frameRate(60);
  ellipseMode(CENTER);
  noStroke();
  textAlign(CENTER);
  gameOver = false;

  ballmanager = new BallManager(numberOfBalls);
  player = new Player(width/2, height/2, 30);
}

void draw() {
  background(32, 160, 101);

  long currentTime = millis();
  timeCount = timeCount + deltaTime;

  deltaTime = (currentTime - time);
  deltaTime *= 0.001f;

  ballmanager.update();

  if(gameOver){
      textSize(40);
      fill(255);
      text(gameOverText, width/2, height/2);
  }

  else{
    player.update();
    player.draw();
  }

  //save the time when the last frame was run
  time = currentTime;
}