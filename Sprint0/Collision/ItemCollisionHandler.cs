using Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using static Sprint0.Collision.CollisionDetector;
using System;
using Sprint0.Commands.Collision;
using Sprint0.Commands.Collisions;

namespace Sprint0.Collision
{
    public class ItemCollisionHandler
    {
        private Sprint0 sprint;

        public enum staticBlocks { Floor, Cloud, LargeBlock, Pipe, WoodBlocks, YellowBrick }
        public enum dynamicBlocks { YellowBrick, QuestionBlock, SpinningCoin }

        public enum Items { RedMushroom, OneUpMushroom, Leaf }

        public ItemCollisionHandler(Sprint0 sprint)
        {
            this.sprint = sprint;
        }

        public void HandleCollision(ICollidable entity1, ICollidable entity2, Side side, Rectangle hitarea)
        {
            Type type1 = entity1.GetType();
            Type type2 = entity2.GetType();

            if (Enum.IsDefined(typeof(staticBlocks), type1.Name) || Enum.IsDefined(typeof(staticBlocks), type2.Name))
                ItemStaticBlockCollision(entity1, entity2, side, hitarea);
            if (Enum.IsDefined(typeof(dynamicBlocks), type1.Name) || Enum.IsDefined(typeof(dynamicBlocks), type2.Name))
                ItemStaticBlockCollision(entity1, entity2, side, hitarea);
        }
        
        public void ItemStaticBlockCollision(ICollidable entity1, ICollidable entity2, Side side, Rectangle hitarea)
        {
            if (side == Side.Horizontal)
            {
                if (entity1 is IItem)
                {
                    ICommand command = new CItemBlockX((IItem)entity1);
                    command.Execute();
                } else
                {
                    ICommand command = new CItemBlockX((IItem)entity2);
                    command.Execute();
                }
                
            }
            if (side == Side.Vertical)
            {
                if (entity1 is IItem)
                {
                    ICommand command = new CItemBlockY((IItem)entity1, hitarea);
                    command.Execute();
                } else
                {
                    ICommand command = new CItemBlockY((IItem)entity2, hitarea);
                    command.Execute();
                }
            }
        }
    }
}
