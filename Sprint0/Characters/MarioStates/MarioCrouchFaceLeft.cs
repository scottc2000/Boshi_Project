using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioCrouchFaceLeft : ICharacterState
    {
        private Mario mario;

        public MarioCrouchFaceLeft(Mario mario)
        {
            this.mario = mario;
        }
        public void MoveLeft()
        {
            mario.State = new MarioFaceLeft(mario);
        }

        public void MoveRight()
        {
            mario.State = new MarioFaceRight(mario);
        }

        public void JumpLeft()
        {
            mario.State = new MarioFaceLeft(mario);
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
            switch (mario.health)
            {
                case (Mario.MarioHealth.Normal):
                    {
                        mario.marioSprite = new MarioLeftIdleSprite(mario.mySprint, mario);
                        break;
                    }


                case (Mario.MarioHealth.Raccoon):
                    {
                        //mario.marioSprite = new MarioRaccoonCrouchLeftSprite(mario.mySprint, mario);
                        break;
                    }

                case (Mario.MarioHealth.Fire):
                    {
                        mario.marioSprite = new MarioFireCrouchLeftSprite(mario.mySprint, mario);
                        break;
                    }

                case (Mario.MarioHealth.Big):
                    {
                        mario.marioSprite = new MarioBigCrouchLeftSprite(mario.mySprint, mario);
                        break;
                    }
            }
        }
    }
}
