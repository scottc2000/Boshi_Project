using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
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
            // mario.State = new MarioCrouchState(mario);   
        }

        public void Stop()
        {
            mario.State = new MarioIdleState(mario);
        }

        public void Throw()
        {
            mario.State = new MarioThrowState(mario);
        }

        public void Die()
        {
            mario.State = new DeadMarioState(mario);
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
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("NormalMarioCrouchLeft");
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("RaccoonMarioCrouchLeft");
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("FireMarioCrouchLeft");
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("BigMarioCrouchLeft");
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
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("NormalMarioCrouchRight");
                            break;
                        }

                    case (Mario.MarioHealth.Raccoon):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("RaccoonMarioCrouchRight");
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("FireMarioCrouchRight");
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("BigMarioCrouchRight");
                            break;
                        }
                }
            }
        }
    }
}
