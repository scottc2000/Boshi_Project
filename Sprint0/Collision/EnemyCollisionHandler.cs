﻿using Microsoft.Xna.Framework;
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

            if (type1 is ISingleProjectile || type2 is ISingleProjectile)
            {
                Console.WriteLine(entity1 + " ENTERa " + entity2);
            }



            if (type1 is IPlayer || type2 is IPlayer)
            {
                EnemyPlayerCollision(entity1, entity2, side);
            }

            if (type1 is ISingleProjectile || type2 is ISingleProjectile)
            {
                
                EnemyProjectileCollision(entity1, entity2, side);
            }

        }

        public void EnemyProjectileCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            System.Diagnostics.Debug.WriteLine("Projectile Hit enemy");

            ICommand command;
            if (entity1 is ISingleProjectile)
            {
                command = new CEnemyStomp(sprint, (IEnemies)entity2);
                sprint.objects.DynamicEntities.Remove(entity1);
                System.Diagnostics.Debug.WriteLine("Enemy Killed");
            }
            else
            {
                command = new CEnemyStomp(sprint, (IEnemies)entity1);
                sprint.objects.DynamicEntities.Remove(entity2);
                System.Diagnostics.Debug.WriteLine("Enemy Killed");
            }

            command.Execute();
        }

        public void EnemyPlayerCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            type1 = entity1.GetType();
            type2 = entity2.GetType();

           /* if (side == Side.Vertical)
            {
                if (type1 is Goomba || type2 is Goomba)
                {
                    ICommand command = new CEnemyStomp(sprint);
                    command.Execute();
                    System.Diagnostics.Debug.WriteLine("Goomba Stomped");
                } else if (type1 is Koopa || type2 is Koopa)
                {
                    ICommand command = new CKoopaStomp(sprint);
                    command.Execute();
                    System.Diagnostics.Debug.WriteLine("Goomba Stomped");
                }
            }*/

        }

    }
}
