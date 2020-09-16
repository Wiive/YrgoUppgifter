PVector goalPosision, playerGuess, currentGuess;
float distance;
float playerGuessDistance;

void setup()
{
	size(430,430);
	goalPosision = new PVector(200,100);
	print("GOAL POINT: " + goalPosision.mag() + " ");
	playerGuess = new PVector();
	currentGuess = new PVector();
}

void draw()
{
	background(255);
	stroke(255,0,0);
	strokeWeight(2f);

	if (mousePressed == true)
	{
		currentGuess.x = mouseX;
		currentGuess.y = mouseY;
	}
	line(currentGuess.x, currentGuess.y, mouseX, mouseY);

}

void calculateDistance()
{
	playerGuess.x = currentGuess.x;
	playerGuess.y = currentGuess.y;

	//calculate playerguess mag
	playerGuessDistance = playerGuess.mag();
	distance = goalPosision.mag() - playerGuessDistance;
}

void mouseReleased()
{
	calculateDistance();
	print("Player Guess: " + playerGuess.mag() + " ");
	print("Distance between: " + distance + " ");;
}