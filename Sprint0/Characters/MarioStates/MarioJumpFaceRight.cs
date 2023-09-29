using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioJumpFaceRight : ICharacterState
    {
        private Mario mario;

        public MarioJumpFaceRight(Mario mario)
        {
            this.mario = mario;
        }
        public void MoveLeft()
        {
            mario.State = new MarioFaceLeft(mario);
        }

        public void MoveRight()
        {
            mario.State = new MarioMoveRight(mario);
        }

        public void JumpLeft()
        {
            mario.State = new MarioFaceLeft(mario);
        }

        public void JumpRight()
        {
            mario.State = new MarioJumpFaceRight(mario);
        }

        public void CrouchLeft()
        {
            mario.State = new MarioFaceLeft(mario);
        }

        public void CrouchRight()
        {
            mario.State = new MarioCrouchFaceRight(mario);
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
            mario.facingLeft = false;

            switch (mario.health)
            {
                case (Mario.MarioHealth.Normal):
                    {
                        mario.marioSprite = new MarioJumpRightSprite(mario.mySprint, mario);
                        break;
                    }


                case (Mario.MarioHealth.Raccoon):
                    {
                        //mario.marioSprite = new MarioRaccoonJumpRightSprite(mario.mySprint, mario);
                        break;
                    }

                case (Mario.MarioHealth.Fire):
                    {
                        mario.marioSprite = new MarioFireJumpRightSprite(mario.mySprint, mario);
                        break;
                    }

                case (Mario.MarioHealth.Big):
                    {
                        mario.marioSprite = new MarioBigJumpRightSprite(mario.mySprint, mario);
                        break;
                    }

            }
        }
    }
}
