using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Commands.Collision;
using Sprint0.Commands.Collisions;
using System;
using static Sprint0.Collision.CollisionDetector;
using Sprint0.Enemies;

namespace Sprint0.Collision
{
    public class EnemyCollisionHandler
    {
        private Sprint0 sprint;
        private Type type1;
        private Type type2;

        public enum Enemies { Koopa, Goomba }
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
            ICommand command;
            System.Diagnostics.Debug.WriteLine("Enemy-Player Collision");
            if (side == Side.Vertical)
            {
                System.Diagnostics.Debug.WriteLine("Mario hit enemy top");
                if (entity1 is IEnemies)
                {
                    command = new CEnemyStomp(sprint, (IEnemies)entity1);
                    System.Diagnostics.Debug.WriteLine("Enemy Stomped");
                } else {
                    command = new CEnemyStomp(sprint, (IEnemies)entity2);
                    System.Diagnostics.Debug.WriteLine("Enemy Stomped");
                }
                command.Execute();
            }

        }

    }
}
