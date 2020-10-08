int cellSize = 5;
color alive = color(0,150,130);
color dead = color(0,30,30,60);

float probabilityAsAliveAtStart = 20;

float oneUpdateTime = 100;
int storedTime = 0;

int[][] cells;
int[][] cellsDecoy;

void setup()
{
	size(500,500);
	noStroke();

	setCellsStartState();

	background(0);
}


void setCellsStartState()
{
	cells = new int[width/cellSize][height/cellSize];
	cellsDecoy = new int[width/cellSize][height/cellSize];

	for (int x = 0; x < width/cellSize; x++) {
    	for (int y = 0; y < height/cellSize; y++) {
     		float state = random (100);     		
      		if (state > probabilityAsAliveAtStart) { 
        		state = 0;
     		}

      		else {
        		state = 1;
      		}
      		
     		cells[x][y] = int(state);
    	}
  	}
}


void draw()
{
	drawCells();
 	
	if (millis() - storedTime > oneUpdateTime) {
    	if (!pause) {
 			cellUpdate();
      		storedTime = millis();
    	}
	}

	if(pause)
	{
		drawSliderHUD();		
	}
}


void drawCells()
{
	for (int x = 0; x < width/cellSize; x++) {
    	for (int y = 0; y < height/cellSize; y++) {
    		if (cells[x][y] == 1) {
        		fill(alive);
    		}

      		else {     		
 	      		fill(dead);
      		}

      	rect (x * cellSize, y * cellSize, cellSize, cellSize);
    	}
  	}
}


void cellUpdate()
{
	for (int x = 0; x < width/cellSize; x++) {
    	for (int y = 0; y < height/cellSize; y++) {
     		cellsDecoy[x][y] = cells[x][y];
    	}
  	}
  	//Check all cells
	for (int x = 0; x < width/cellSize; x++) {
    	for (int y = 0; y < height/cellSize; y++) {
    		int aliveNeighbours = 0;
     			for (int xx = x - 1; xx <= x + 1; xx++) {
        			for (int yy = y - 1; yy <= y + 1; yy++) {  
        				//Avoid to check edge cases
         				if (((xx >= 0) && (xx < width/cellSize))
         				&& (( yy >= 0) && (yy < height/cellSize))) {
            				//The cell checks itself
            				if (!((xx == x) && (yy == y))) {
              					if (cellsDecoy[xx][yy] == 1){
                					aliveNeighbours ++;
              					}
            				}
         				}
        			}
      			}
     		if (cellsDecoy[x][y] == 1) { 
        		if (aliveNeighbours < 2 || aliveNeighbours > 3) {
         			cells[x][y] = 0;
        		}
      		}

      		else {    
        		if (aliveNeighbours == 3 ) {
          			cells[x][y] = 1; 
        		}
      		}
    	}
	}
}