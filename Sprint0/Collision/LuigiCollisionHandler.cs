using Microsoft.Xna.Framework;
using Sprint0.Commands.Collisions;
using Sprint0.Interfaces;
using static Sprint0.Collision.CollisionDetector;

namespace Sprint0.Collision
{
    public class LuigiCollisionHandler
    {
        private Sprint0 sprint;

        public LuigiCollisionHandler(Sprint0 sprint) 
        {
            this.sprint = sprint;
        }
        public void LuigiStaticBlockCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            if (side == Side.Horizontal)
            {
                ICollidableCommand command = new CLuigiStuckX(sprint);
                command.Execute(entity2.Destination);
            }
            else if (side == Side.Vertical)
            {
                ICollidableCommand command = new CLuigiStuckY(sprint);
                command.Execute(entity2.Destination);
            }
        }

        public void PlayerCollision(ICollidable entity1, ICollidable entity2, Side side, Rectangle hitarea)
        {
            
        }
        public void LuigiItemCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            
        }
    }
}
