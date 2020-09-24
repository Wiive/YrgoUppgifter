class Zombie extends Character{

  Zombie(float x, float y){
    super(x,y);

    col = color(0,random(45,256),0);
    velocity.x *= 0.3;
    velocity.y *= 0.3;
  }
}