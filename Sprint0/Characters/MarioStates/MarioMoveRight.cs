using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioMoveRight : ICharacterState
    {
        private Mario mario;

        public MarioMoveRight(Mario mario)
        {
            this.mario = mario;
        }
        public void MoveLeft()
        {
            mario.State = new MarioFaceLeft(mario);
        }

        public void MoveRight()
        {
            mario.position.X += 1;
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
                       mario.marioSprite = new MarioMoveRightSprite(mario.mySprint, mario);
                        break;
                    }


                case (Mario.MarioHealth.Raccoon):
                    {
                        //mario.marioSprite = new MarioRaccoonMoveRightSprite(mario.mySprint, mario);
                        break;
                    }

                case (Mario.MarioHealth.Fire):
                    {
                       mario.marioSprite = new MarioFireMoveRightSprite(mario.mySprint, mario);
                        break;
                    }

                case (Mario.MarioHealth.Big):
                    {
                       mario.marioSprite = new MarioBigMoveRightSprite(mario.mySprint, mario);
                        break;
                    }

            }
        }
    }
}
