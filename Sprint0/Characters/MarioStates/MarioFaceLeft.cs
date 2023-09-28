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
    internal class MarioFaceLeft : ICharacterState
    {
        private Mario mario;

        public MarioFaceLeft(Mario mario)
        {
            this.mario = mario;
        }
        public void ChangeDirection()
        {
            mario.State = new MarioFaceRight(mario);
        }

        public void Move()
        {
            mario.State = new MarioMoveLeft(mario);
        }

        public void Stop()
        {

        }

        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            {
                switch (mario.health)
                {
                    case (Mario.MarioHealth.Normal):
                        {
                            mario.mySprint.marioSprite = new MarioLeftIdleSprite(mario.mySprint);
                            break;
                        }


                    case (Mario.MarioHealth.Star):
                        {
                            //mario.mySprint.marioSprite = new MarioStarLeftIdleSprite(mario.mySprint);
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.mySprint.marioSprite = new MarioFireLeftIdleSprite(mario.mySprint);
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.mySprint.marioSprite = new MarioBigLeftIdleSprite(mario.mySprint);
                            break;
                        }

                }
            }
        }
    }
}
