using Sprint0.Interfaces;
using Sprint0.HUD;
using Sprint0.GameMangager;
using Sprint0.Blocks;
using Sprint0.Characters;
using Microsoft.Xna.Framework;
using Sprint0.Commands;

namespace Sprint0.Commands.Collisions
{
    public class CQuestionBump : ICollidableCommand
    {
        private Sprint0 sprint;
        private ObjectManager objectManager;
        private GameStats stats;
        private IPlayer player;
        private IItem item;

        public CQuestionBump(Sprint0 sprint, IPlayer player)
        {
            this.sprint = sprint;
            objectManager = sprint.objects;
            
            this.player = player;
        }
        public void Execute(Rectangle hitbox)
        {

        }

        public void Execute(Rectangle hitbox, IBlock block)
        {
            Rectangle hitarea = Rectangle.Intersect(hitbox, player.Destination);
            item = ((QuestionBlock)block).item;

            if (!((QuestionBlock)block).newSpriteSet)
            {
                if (hitarea.Width >= hitarea.Height)
                {
                    if (player.Destination.Top <= hitbox.Bottom && player.Destination.Bottom >= hitbox.Top + 5)
                    {
                        ((QuestionBlock)block).bumped = true;
                        if (item is Coin)
                        {
                            ((Coin)item).getInstance(sprint, item);
                        }
                        objectManager.AddToList(item);

                    }

                }
            }


        }
    }
}
