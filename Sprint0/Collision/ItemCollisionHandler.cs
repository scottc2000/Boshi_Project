﻿using Sprint0.Interfaces;
using static Sprint0.Collision.CollisionDetector;

namespace Sprint0.Collision
{
    public class ItemCollisionHandler
    {
        private Sprint0 sprint;

        public ItemCollisionHandler(Sprint0 sprint)
        {
            this.sprint = sprint;
        }
        public void ItemStaticBlockCollision(ICollidable entity1, ICollidable entity2, Side side)
        {

        }
    }
}
