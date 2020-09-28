//Time variables
float deltaTime;
long time;
float timeCount;

CharacterManager characterManager;
int numberOfCharacters = 100;

boolean gameOver = false;
String gameOverText = "Game Over";

void setup()
{
	size(820,610);
	frameRate(60);

	ellipseMode(CENTER);
	noStroke();
	textAlign(CENTER);

	characterManager = new CharacterManager(numberOfCharacters);
}

void draw()
{
	background(0, 10, 10);

	//Time
	long currentTime = millis();
	deltaTime = (currentTime - time) * 0.001f;


	characterManager.update();

	if(gameOver){
		textSize(40);
		fill(255);
		text(gameOverText, width/2, height/2);
		textSize(20);
		text("Took " + nf(timeCount,0,2) + " secconds.",width/2, height/2+45);
	}
	else {
		timeCount = timeCount + deltaTime;
	}

	time = currentTime;
}