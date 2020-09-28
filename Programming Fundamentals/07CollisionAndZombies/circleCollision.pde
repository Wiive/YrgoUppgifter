  boolean circleCollision(Character one, Character two){ 
    int maxDistance = one.size/2 + two.size/2;

    if(abs(one.position.x - two.position.x) > maxDistance || abs(one.position.y - two.position.y) > maxDistance) {
      return false;
    }
    else if(dist(one.position.x, one.position.y, two.position.x, two.position.y) > maxDistance) {
      return false;
    }
    else {
      return true;
    }
  }