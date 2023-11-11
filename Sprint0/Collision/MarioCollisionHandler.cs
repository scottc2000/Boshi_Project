using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Commands.Collision;
using Sprint0.Commands.Collisions;
using Sprint0.Interfaces;
using System;
using static Sprint0.Collision.CollisionDetector;

namespace Sprint0.Collision
{
    public class MarioCollisionHandler
    {
        private Sprint0 sprint;
        private Type type1;
        private Type type2;

        public enum staticBlocks { Floor, Clouds, LargeBlock, Pipe, WoodBlocks }
        public enum dynamicBlocks { YellowBrick, QuestionBlock, SpinningCoin }
        public enum Items { RedMushroom, OneUpMushroom, Leaf}
        public enum Enemies { Koopa, Goomba}
        public MarioCollisionHandler(Sprint0 sprint) 
        {
            this.sprint = sprint;
        }

        public void HandleCollision(ICollidable entity1, ICollidable entity2, Side side, Rectangle hitarea)
        {
            type1 = entity1.GetType();
            type2 = entity2.GetType();

            if (Enum.IsDefined(typeof(staticBlocks), type1.Name) || Enum.IsDefined(typeof(staticBlocks), type2.Name))
                MarioStaticBlockCollision(entity1, entity2, side, hitarea);

            else if (Enum.IsDefined(typeof(dynamicBlocks), type1.Name) || Enum.IsDefined(typeof(dynamicBlocks), type2.Name))
                MarioDynamicBlockCollision(entity1, entity2, side, hitarea);

            else if (Enum.IsDefined(typeof(Items), type1.Name) || Enum.IsDefined(typeof(Items), type2.Name))
                MarioItemCollision(entity1, entity2, side);

            else if (Enum.IsDefined(typeof(Enemies), type1.Name) || Enum.IsDefined(typeof(Enemies), type2.Name))
                MarioEnemyCollision(entity1, entity2, side);

            else if (type1 is IMario || type2 is IMario)
                PlayerCollision(entity1, entity2, side, hitarea);
        }
        public void MarioStaticBlockCollision(ICollidable entity1, ICollidable entity2, Side side, Rectangle hitarea)
        {
            if (entity1 is DeathZone || entity2 is DeathZone)
            {
                ICommand command = new CMarioDie(sprint);
                command.Execute();
            }
            if (side == Side.Horizontal)
            {
                ICollidableCommand command = new CMarioStuckX(sprint);
                command.Execute(hitarea);
            }
            else if (side == Side.Vertical)
            {
                ICollidableCommand command = new CMarioStuckY(sprint);
                command.Execute(hitarea);
            }
            else if (side == Side.Both)
            {
                ICollidableCommand command = new CMarioStuckY(sprint);

                command.Execute(hitarea);
            }
        }

        public void MarioDynamicBlockCollision(ICollidable entity1, ICollidable entity2, Side side, Rectangle hitarea)
        {
            if (entity1 is SpinningCoin)
            {
                CGetCoin command = new CGetCoin(sprint);
                command.Execute((IBlock)entity1);
            }
            else if (entity2 is SpinningCoin)
            {
                CGetCoin command = new CGetCoin(sprint);
                command.Execute((IBlock)entity2);
            }
            
            if (side == Side.Horizontal)
            {
                ICollidableCommand command = new CMarioStuckX(sprint);
                command.Execute(hitarea);
            }
            else if (side == Side.Vertical)
            {
                ICollidableCommand command = new CMarioStuckY(sprint);
                command.Execute(hitarea);
                if (entity1 is YellowBrick)
                {
                    
            }
                else if (entity2 is YellowBrick)
                {

                }
            }
            else if (side == Side.Both)
            {
                ICollidableCommand command = new CMarioStuckY(sprint);

                command.Execute(hitarea);
            }
        }

        public void PlayerCollision(ICollidable entity1, ICollidable entity2, Side side, Rectangle hitarea)
        {
            if (side == Side.Horizontal)
            {
                ICollidableCommand command1 = new CMarioStuckX(sprint);
                command1.Execute(hitarea);
                ICollidableCommand command2 = new CLuigiStuckX(sprint);
                command2.Execute(hitarea);
            }
        }

        public void MarioItemCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            ICommand command1;
            ICommand command2;

            if (entity1 is IItem)
            {
                command1 = new CMarioPowerUp(sprint, (IItem)entity1);
                command2 = new CItemDisappear(sprint, (IItem)entity1);
            }
            else
            {
                command1 = new CMarioPowerUp(sprint, (IItem)entity2);
                command2 = new CItemDisappear(sprint, (IItem)entity2);
            }

            command1.Execute();
            command2.Execute();
        }

        public void MarioEnemyCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            if (side == Side.Horizontal)
            {
                ICommand command = new CMarioTakeDamage(sprint);
                command.Execute();
            }
        }
    }
}
