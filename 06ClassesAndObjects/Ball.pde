class Ball
{
    //Our class variables
    PVector position; //Ball position
    PVector velocity; //Ball direction
    int ballSize;
    color ballColor;

    //Ball Constructor, called when we type new Ball(x, y);
    Ball(float x, float y, int size, int value1, int value2, int value3)
    {
        //Set our position when we create the code.
        position = new PVector(x, y);

        //Create the velocity vector and give it a random direction.
        velocity = new PVector();
        velocity.x = random(11) - 5;
        velocity.y = random(11) - 5;

        ballSize = size;
        ballColor = color(value1, value2, value3);
    }

    void update()
    {
        position.x += velocity.x;
        position.y += velocity.y;

        // Bounce off edges
        if ((position.x > width) || (position.x < 0))
        {
             velocity.x = velocity.x * -1;
        }
        if ((position.y > height) || (position.y < 0))
        {
            velocity.y = velocity.y * -1; 
        }
    }

    void draw()
    {
        fill(ballColor);
        ellipse(position.x, position.y, ballSize, ballSize);
    }
}