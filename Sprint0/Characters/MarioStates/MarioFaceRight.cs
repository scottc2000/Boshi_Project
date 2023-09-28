using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioFaceRight : ICharacterState
    {
        private Mario mario;

        public MarioFaceRight(Mario mario)
        {
            this.mario = mario;
        }
        public void ChangeDirection()
        {
            mario.State = new MarioFaceLeft(mario);
        }

        public void Move()
        {
            mario.State = new MarioMoveRight(mario);
        }

        public void Stop()
        {

        }
        public void Update()
        {
            mario.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            switch (mario.health)
            {
                case (Mario.MarioHealth.Normal):
                    {
                        mario.mySprint.marioSprite = new MarioRightIdleSprite(mario.mySprint);
                        break;
                    }


                case (Mario.MarioHealth.Star):
                    {
                        //mario.mySprint.marioSprite = new MarioStarRightIdleSprite(mario.mySprint);
                        break;
                    }

                case (Mario.MarioHealth.Fire):
                    {
                        mario.mySprint.marioSprite = new MarioFireRightIdleSprite(mario.mySprint);
                        break;
                    }

                case (Mario.MarioHealth.Big):
                    {
                        mario.mySprint.marioSprite = new MarioBigRightIdleSprite(mario.mySprint);
                        break;
                    }

            }
        }
    }
}
