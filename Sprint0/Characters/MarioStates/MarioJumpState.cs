using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.ComponentModel.Design;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioJumpState : ICharacterState
    {
        private Mario mario;

        public MarioJumpState(Mario mario)
        {
            this.mario = mario;
        }

        public void Move()
        {
            mario.State = new MarioMoveState(mario);
        }

        public void Jump()
        {
            // insert jump logic/physics
        }

        public void Crouch()
        {
            mario.State = new MarioCrouchState(mario);
        }

        public void Throw()
        {
            mario.State = new MarioThrowState(mario);
        }
        public void Stop()
        {
            mario.State = new MarioIdleState(mario);
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
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("NormalMarioJumpLeft");
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("RaccoonMarioJumpLeft");
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("FireMarioJumpLeft");
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("BigMarioJumpLeft");
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
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("NormalMarioJumpRight");
                            break;
                        }

                    case (Mario.MarioHealth.Raccoon):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("RaccoonMarioJumpRight");
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("FireMarioJumpRight");
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("BigMarioJumpRight");
                            break;
                        }
                }
            }
        }
    }
}
