using Microsoft.Xna.Framework;
using Sprint0.Commands.Collisions;
using Sprint0.Interfaces;
using Sprint0.Items;
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
            if (side == Side.Horizontal)
            {
                IMario mario = (IMario)entity1;
                Characters.Luigi luigi = (Characters.Luigi)entity2;

                if (side == Side.Horizontal)
                {
                    if (mario.facingLeft)
                        mario.position = new Vector2(mario.position.X + hitarea.Width, mario.position.Y);
                    else
                        mario.position = new Vector2(mario.position.X - hitarea.Width, mario.position.Y);

                    if (luigi.facingLeft)
                        luigi.position.X += hitarea.Width;
                    else
                        luigi.position.X -= hitarea.Width;
                }
            }
        }
        public void LuigiItemCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            Characters.Luigi luigi = (Characters.Luigi)entity1;
            if (entity2 is RedMushroom)
                luigi.ChangeToBig();
            else if (entity2 is Leaf)
                luigi.ChangeToRaccoon();
            else if (entity2 is FireFlower)
                luigi.ChangeToFire();
            else if (entity2 is OneUpMushroom) ;
            // increase HUD life counter

            ICommand command2 = new CItemDisappear(sprint, (IItem)entity2);
            command2.Execute();
        }
    }
}
