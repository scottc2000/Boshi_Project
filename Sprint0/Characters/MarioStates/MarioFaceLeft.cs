using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            mario.marioState = new MarioFaceRight(mario);
        }

        public void Move()
        {
            mario.marioState = new MarioMoveLeft(mario);
        }

        public void Stop()
        {

        }

        public void Draw()
        {
            {
                switch (mario.health)
                {
                    case (Mario.MarioHealth.Normal):
                        {
                            //mario.mySprint.marioSprite = new MarioLeftIdleSprite(mario.mySprint);
                            break;
                        }


                    case (Mario.MarioHealth.Star):
                        {
                            //mario.mySprint.marioSprite = new MarioStarLeftIdleSprite(mario.mySprint);
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            //mario.mySprint.marioSprite = new MarioFireLeftIdleSprite(mario.mySprint);
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            //mario.mySprint.marioSprite = new MarioBigLeftIdleSprite(mario.mySprint);
                            break;
                        }

                }
            }
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager content)
        {
            throw new NotImplementedException();
        }
    }
}
