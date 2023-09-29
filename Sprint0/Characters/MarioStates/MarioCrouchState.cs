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

        public void Stop()
        {
            mario.State = new MarioIdleState(mario);
        }

        // Attempts to fix bug where mario animation does not change health at key press, only after pose is changed. Needs work
        public void ChangeHealth()
        {
            switch (mario.pose)
            {
                case (Mario.MarioPose.Crouch):
                    {
                        mario.State = new MarioCrouchState(mario);
                        break;
                    }
                case (Mario.MarioPose.Idle):
                    {
                        mario.State = new MarioIdleState(mario);
                        break;
                    }
                case (Mario.MarioPose.Walking):
                    {
                        mario.State = new MarioMoveState(mario);
                        break;
                    }
                case (Mario.MarioPose.Jump):
                    {
                        mario.State = new MarioJumpState(mario);
                        break;
                    }
            }
        }

        public void Die()
        {
           // mario.marioSprite = CharacterSpriteFactory.Instance.CreateDeadMarioSprite();
        }
        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Jump;

        }
    }
}
