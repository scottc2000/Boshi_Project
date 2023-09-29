using Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioJumpFaceRight : ICharacterState
    {
        private Mario mario;

        public MarioJumpFaceRight(Mario mario)
        {
            this.mario = mario;
        }
        public void ChangeDirection()
        {
            mario.State = new MarioJumpFaceLeft(mario);
        }
        public void Move()
        {

        }

        public void Stop()
        {
            mario.State = new MarioFaceLeft(mario);
        }

        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            switch (mario.health)
            {
                case (Mario.MarioHealth.Normal):
                    {
                        mario.mySprint.marioSprite = new MarioJumpRightSprite(mario.mySprint);
                        break;
                    }


                case (Mario.MarioHealth.Star):
                    {
                        //mario.mySprint.marioSprite = new MarioStarJumpRightSprite(mario.mySprint);
                        break;
                    }

                case (Mario.MarioHealth.Fire):
                    {
                        mario.mySprint.marioSprite = new MarioFireJumpRightSprite(mario.mySprint);
                        break;
                    }

                case (Mario.MarioHealth.Big):
                    {
                        mario.mySprint.marioSprite = new MarioBigJumpRightSprite(mario.mySprint);
                        break;
                    }

            }
        }
    }
}
