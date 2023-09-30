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
    internal class MarioJumpFaceLeft : ICharacterState
    {
        private Mario mario;

        public MarioJumpFaceLeft(Mario mario)
        {
            this.mario = mario;
        }
        public void ChangeDirection()
        {
            mario.marioState = new MarioJumpFaceRight(mario);
        }

        public void Move()
        {

        }

        public void Stop()
        {

        }

        public void Draw()
        {
            switch (mario.health)
            {
                case (Mario.MarioHealth.Normal):
                    {
                       // mario.mySprint.marioSprite = new MarioJumpLeftSprite(mario.mySprint);
                        break;
                    }


                case (Mario.MarioHealth.Star):
                    {
                        //mySprint.marioSprite = new MarioStarJumpLeft(mySprint);
                        break;
                    }

                case (Mario.MarioHealth.Fire):
                    {
                        //mario.mySprint.marioSprite = new MarioFireJumpLeftSprite(mario.mySprint);
                        break;
                    }

                case (Mario.MarioHealth.Big):
                    {
                        //mario.mySprint.marioSprite = new MarioBigJumpLeftSprite(mario.mySprint);
                        break;
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
