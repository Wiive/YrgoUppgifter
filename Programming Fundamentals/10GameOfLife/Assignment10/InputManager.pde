boolean pause = false;
int sliderOffset = 20;
int sliderLenght = 210;
int sliderThicknes = 15;
float sliderValue = sliderLenght / oneUpdateTime;
float sliderProcetage;
String sliderText = "Millis between updates: ";
int mousex;
int mousey;

void keyPressed()
{
	if (key == 'p' || key == 'P') {
		pause = !pause;
	}

	//Restarts a new cell simulation
	if (key == 'r' || key == 'R'){
		setCellsStartState();
	}
}

void drawSliderHUD()
{
	int y = height - sliderOffset - sliderThicknes;

	fill(0,0,0,70);
	rect(0, height - (sliderOffset * 3), height, width);

	fill(0);
	rect(sliderOffset, y, sliderLenght, sliderThicknes);

	fill(250, 255, 255);
	rect(sliderOffset, y, sliderValue, sliderThicknes);

	textSize(14);
	text(sliderText + int(oneUpdateTime), sliderOffset, height - (sliderOffset * 2));
}


void mousePressed()
{
	mousex = mouseX;
	mousey = mouseY;
}


void mouseDragged()
{
	if(pause){
		if(mousex < mouseX) {
			sliderValue = sliderValue + 1;
			if (sliderValue > sliderLenght) {
				sliderValue = sliderLenght;
			}
		}

		else if(mousex > mouseX) {
			sliderValue = sliderValue - 1;
			if (sliderValue < 1) {
				sliderValue = 1;
			}
		}
		sliderProcetage = (sliderValue / sliderLenght);
		oneUpdateTime = 500 * sliderProcetage;
	}
}