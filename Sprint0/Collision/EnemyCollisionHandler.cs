using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Commands.Collision;
using Sprint0.Commands.Collisions;
using System;
using static Sprint0.Collision.CollisionDetector;

namespace Sprint0.Collision
{
    public class EnemyCollisionHandler
    {
        private Sprint0 sprint;
        private Type type1;
        private Type type2;

        public EnemyCollisionHandler(Sprint0 sprint)
        {
            this.sprint = sprint;
        }

        public void HandleCollision(ICollidable entity1, ICollidable entity2, Side side, Rectangle hitarea)
        {
            type1 = entity1.GetType();
            type2 = entity2.GetType();

            if (type1 is IMario || type2 is IMario)
                EnemyPlayerCollision(entity1, entity2, side);
        }

        public void EnemyPlayerCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            if (side == Side.Horizontal)
            {
                ICommand command = new CGoombaStomp(sprint);
                command.Execute();
            }

        }

    }
}
