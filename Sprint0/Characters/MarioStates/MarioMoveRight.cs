using Sprint0.Interfaces;
using Sprint0.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioMoveRight : ICharacterState
    {
        private Mario mario;

        public MarioMoveRight(Mario mario)
        {
            this.mario = mario;
        }
        public void ChangeDirection()
        {
            mario.State = new MarioMoveLeft(mario);
        }

        public void Move()
        {

        }

        public void Stop() 
        {
            mario.State = new MarioFaceRight(mario);
        }

        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            switch (mario.health)
            {
                case (Mario.MarioHealth.Normal):
                    {
                        mario.mySprint.marioSprite = new MarioMoveRightSprite(mario.mySprint);
                        break;
                    }


                case (Mario.MarioHealth.Star):
                    {
                        //mario.mySprint.marioSprite = new MarioStarMoveRightSprite(mario.mySprint);
                        break;
                    }

                case (Mario.MarioHealth.Fire):
                    {
                        mario.mySprint.marioSprite = new MarioFireMoveRightSprite(mario.mySprint);
                        break;
                    }

                case (Mario.MarioHealth.Big):
                    {
                        mario.mySprint.marioSprite = new MarioBigMoveRightSprite(mario.mySprint);
                        break;
                    }

            }
        }
    }
}
