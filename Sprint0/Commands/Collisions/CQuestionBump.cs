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

        public CQuestionBump(Sprint0 sprint, IPlayer player)
        {
            this.sprint = sprint;
            objectManager = sprint.objects;
            stats = sprint.levelLoader.hud;
            this.player = player;
        }
        public void Execute(Rectangle hitbox)
        {

        }

        public void Execute(Rectangle hitbox, IBlock block)
        {
            Rectangle hitarea = Rectangle.Intersect(hitbox, player.Destination);

            if (hitarea.Width >= hitarea.Height)
            {
                if (player.Destination.Top <= hitbox.Bottom && player.Destination.Bottom >= hitbox.Top + 5)
                {
                    CBlockBump command = new CBlockBump(sprint);
                    command.Execute(block);
                    objectManager.AddToList(((QuestionBlock)block).item);
                }

            }
            
        }
    }
}
