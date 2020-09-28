class CharacterManager
{
  Character[] characters;
  int numberOfCharacter;
  int numberOfZombies = 1;

  CharacterManager(int n)
  {
    numberOfCharacter = n;
    characters = new Character[numberOfCharacter];

    for (int i = 0; i < characters.length; ++i){
      if(i < characters.length-numberOfZombies)
      {
        characters[i] = new Human(random(width),random(height));
      }
      else{
        characters[i] = new Zombie(random(width),random(height));
      }
    }
  }

  void update()
  {
    for (int i = 0; i < characters.length; ++i) {
      characters[i].update();
      characters[i].draw();
      if(characters[i] instanceof Zombie) {
        for (int j = 0; j < characters.length; ++j){
          if(circleCollision(characters[i], characters[j]) && characters[j] instanceof Human){
            int posX = (int)characters[j].position.x;
            int posY = (int)characters[j].position.y;
            int velX = (int)characters[j].velocity.x;
            int velY = (int)characters[j].velocity.y;

            characters[j] = new Zombie(posX,posY);
            characters[j].velocity.x = velX * 0.4;
            characters[j].velocity.y = velY * 0.4;
            numberOfZombies++;
          }
        }
      }
      if(numberOfZombies == numberOfCharacter){
        gameOver = true;
      }
    }
  }
}
