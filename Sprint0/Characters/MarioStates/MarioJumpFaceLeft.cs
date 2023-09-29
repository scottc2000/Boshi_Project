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
    internal class MarioJumpFaceLeft : ICharacterState
    {
        private Mario mario;

        public MarioJumpFaceLeft(Mario mario)
        {
            this.mario = mario;
        }
        public void MoveLeft()
        { 
            mario.State = new MarioMoveLeft(mario);
        }

        public void MoveRight()
        {
            mario.State = new MarioFaceRight(mario);
        }

        public void JumpLeft()
        {
            mario.State = new MarioJumpFaceLeft(mario);
        }

        public void JumpRight()
        {
            mario.State = new MarioFaceRight(mario);
        }

        public void CrouchLeft()
        {
            mario.State = new MarioCrouchFaceLeft(mario);
        }

        public void CrouchRight()
        {
            mario.State = new MarioFaceRight(mario);
        }

        public void StopLeft()
        {
            mario.State = new MarioFaceLeft(mario);
        }

        public void StopRight()
        {
            mario.State = new MarioFaceRight(mario);
        }

        public void Update()
        {
            mario.facingLeft = true;
            switch (mario.health)
            {
                case (Mario.MarioHealth.Normal):
                    {
                        mario.marioSprite = new MarioJumpLeftSprite(mario.mySprint, mario);
                        break;
                    }


                case (Mario.MarioHealth.Star):
                    {
                        //mySprint.marioSprite = new MarioStarJumpLeft(mySprint);
                        break;
                    }

                case (Mario.MarioHealth.Fire):
                    {
                        mario.marioSprite = new MarioFireJumpLeftSprite(mario.mySprint, mario);
                        break;
                    }

                case (Mario.MarioHealth.Big):
                    {
                        mario.marioSprite = new MarioBigJumpLeftSprite(mario.mySprint, mario);
                        break;
                    }

            }
        }
    }
}
