using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System.ComponentModel.Design;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioCrouchState : ICharacterState
    {
        private Mario mario;

        public MarioCrouchState(Mario mario)
        {
            this.mario = mario;
        }

        public void Move()
        {
            mario.State = new MarioMoveState(mario);
        }

        public void Jump()
        {
            mario.State = new MarioJumpState(mario);
        }

        public void Crouch()
        {
            
        }

        public void Stop()
        {
            mario.State = new MarioIdleState(mario);
        }



        public void Die()
        {
           // mario.marioSprite = CharacterSpriteFactory.Instance.CreateDeadMarioSprite();
        }
        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Jump;
            if (mario.facingLeft)
            {
                switch (mario.health)
                {
                    case (Mario.MarioHealth.Normal):
                        {
                            //mario.marioSprite = new MarioLeftSprite(mario.mySprint, mario);
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            // mario.marioSprite = new MarioRaccoonLeftIdleSprite(mario.mySprint, mario);
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
            else
            {
                switch (mario.health)
                {
                    case (Mario.MarioHealth.Normal):
                        {
                            // mario.marioSprite = new MarioJumpCrouchRSprite(mario.mySprint, mario);
                            break;
                        }

                    case (Mario.MarioHealth.Raccoon):
                        {
                            // mario.marioSprite = new MarioRaccoonLeftIdleSprite(mario.mySprint, mario);
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.marioSprite = new MarioFireCrouchRightSprite(mario.mySprint, mario);
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.marioSprite = new MarioBigCrouchRightSprite(mario.mySprint, mario);
                            break;
                        }
                }
            }
        }
    }
}
