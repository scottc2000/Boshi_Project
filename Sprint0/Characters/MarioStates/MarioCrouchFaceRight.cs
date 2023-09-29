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
    internal class MarioCrouchFaceRight : ICharacterState
    {
        private Mario mario;

        public MarioCrouchFaceRight(Mario mario)
        {
            this.mario = mario;
        }
        public void ChangeDirection()
        {
            mario.marioState = new MarioCrouchFaceLeft(mario);
        }
        public void Move()
        {

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
                            // not needed - little mario can't crouch
                            break;
                        }


                    case (Mario.MarioHealth.Star):
                        {
                            //.mario.mySprint.marioSprite = new MarioStarCrouchRightSprite(mario.mySprint);
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.mySprint.marioSprite = new MarioFireCrouchRightSprite(mario.mySprint);
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.mySprint.marioSprite = new MarioBigCrouchRightSprite(mario.mySprint);
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
