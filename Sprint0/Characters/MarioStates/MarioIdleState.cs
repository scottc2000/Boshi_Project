using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System.Runtime.CompilerServices;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioIdleState : ICharacterState
    {
        private Mario mario;
        public MarioIdleState(Mario mario)
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
            mario.State = new MarioCrouchState(mario);
        }

        public void Stop()
        {
            if(mario.facingLeft)
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
                            // mario.marioSprite = new MarioRaccoonLeftIdleSprite(mario.mySprint, mario);
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.marioSprite = new MarioFireLeftIdleSprite(mario.mySprint, mario);
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.marioSprite = new MarioBigLeftIdleSprite(mario.mySprint, mario);
                            break;
                        }

                }
            } else
            {
                switch (mario.health)
                {
                    case (Mario.MarioHealth.Normal):
                        {
                            mario.marioSprite = new MarioRightIdleSprite(mario.mySprint, mario);
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            // mario.marioSprite = new MarioRaccoonLeftIdleSprite(mario.mySprint, mario);
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.marioSprite = new MarioFireRightIdleSprite(mario.mySprint, mario);
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.marioSprite = new MarioBigRightIdleSprite(mario.mySprint, mario);
                            break;
                        }

                }
            }
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
            mario.pose = Mario.MarioPose.Idle;
        }
    }
}
