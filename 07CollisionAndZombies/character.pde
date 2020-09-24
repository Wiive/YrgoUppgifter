class Character
{
    PVector position;
    PVector velocity;
    int size = 30;
    color col;

    Character(float x, float y)
    {
        position = new PVector(x, y);

        //Create the velocity vector and give it a random direction.
        velocity = new PVector();
        velocity.x = random(10) - 4;
        velocity.y = random(10) - 4;

        col = color(random(20,240),0,random(20,240));
    }

    void update()
    {
        position.x += velocity.x;
        position.y += velocity.y;

        // Wrap on edges
        if (position.x > width){
             position.x = 0;
        }
        else if (position.x < 0){
            position.x = width;
        }
        if (position.y > height){
            position.y = 0;
        }
        else if (position.y < 0){
            position.y = height;
        }
    }

    void draw()
    {
        fill(col);
        ellipse(position.x, position.y, size, size);
    }
}
