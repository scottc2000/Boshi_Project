using Microsoft.Xna.Framework;
using Sprint0.Characters;
using Sprint0.Commands.Collisions;
using Sprint0.Interfaces;
using Sprint0.Items;
using static Sprint0.Collision.CollisionDetector;
using static Sprint0.LevelLoader.Level1Data;

namespace Sprint0.Collision
{
    public class MarioCollisionHandler
    {
        private Sprint0 sprint;

        public MarioCollisionHandler(Sprint0 sprint) 
        {
            this.sprint = sprint;
        }
        public void MarioStaticBlockCollision(ICollidable entity1, ICollidable entity2, Side side, Rectangle hitarea)
        { 
            IMario mario = (IMario) entity1;
            if (side == Side.Horizontal)
            {
                if (mario.facingLeft)
                    mario.position = new Vector2(mario.position.X + hitarea.Width, mario.position.Y);
                else
                    mario.position = new Vector2(mario.position.X - hitarea.Width, mario.position.Y);
            }
            else if (side == Side.Vertical)
            {
                if (hitarea.Width >= hitarea.Height)
                {
                    if (entity2.Destination.Y <= mario.position.Y)
                    {
                        mario.position = new Vector2(mario.position.X, mario.position.Y + hitarea.Height);
                    }
                    else
                    {
                        mario.uphit = true;
                        mario.position = new Vector2(mario.position.X, mario.position.Y - hitarea.Height);
                    }
                }
            }
        }

        public void PlayerCollision(ICollidable entity1, ICollidable entity2, Side side, Rectangle hitarea)
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

        public void MarioItemCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            System.Diagnostics.Debug.WriteLine("entities: " + entity1 + " and " + entity2);
            System.Diagnostics.Debug.WriteLine("recrangle: " + entity2.Destination);

            IMario mario = (IMario)entity1;
            if (entity2 is RedMushroom)
                mario.ChangeToBig();
            else if (entity2 is Leaf)
                mario.ChangeToRaccoon();
            else if (entity2 is FireFlower)
                mario.ChangeToFire();
            else if (entity2 is OneUpMushroom) ;
            // increase HUD life counter

            ICommand command2 = new CItemDisappear(sprint, (IItem)entity2);
            command2.Execute();
        }

        public void MarioEnemyCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            if(side == Side.Horizontal)
            {
                ICommand command = new CMarioTakeDamage(sprint);
                command.Execute();
            }
        }
    }
}
