using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioMoveState : ICharacterState
    {
        private Mario mario;

        public MarioMoveState(Mario mario)
        {
            this.mario = mario;
        }

        public void Move()
        {
            if (mario.facingLeft)
            {
                mario.position.X -= 1;
            }
            else
            {
                mario.position.X += 1;
            }
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
            mario.State = new MarioIdleState(mario);
        }

        public void Die()
        {
           // mario.marioSprite = CharacterSpriteFactory.Instance.CreateDeadMarioSprite();
        }

        public void Update(GameTime gametime)
        {
            if (mario.facingLeft)
            {
                switch (mario.health)
                {
                    case (Mario.MarioHealth.Normal):
                        {
                            mario.marioSprite = new MarioMoveLeftSprite(mario.mySprint, mario);
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            // mario.marioSprite = new MarioRaccoonLeftIdleSprite(mario.mySprint, mario);
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.marioSprite = new MarioFireMoveLeftSprite(mario.mySprint, mario);
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.marioSprite = new MarioBigMoveLeftSprite(mario.mySprint, mario);
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
                            mario.marioSprite = new MarioMoveRightSprite(mario.mySprint, mario);
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            // mario.marioSprite = new MarioRaccoonLeftIdleSprite(mario.mySprint, mario);
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

            mario.pose = Mario.MarioPose.Walking;

        }
    }
}
