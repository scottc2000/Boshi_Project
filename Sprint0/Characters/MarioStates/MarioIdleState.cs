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


        public void Throw()
        {

                mario.State = new MarioThrowState(mario);

        }

        public void Stop()
        {
            
        }

        
        public void Die()
        {
           // mario.marioSprite = CharacterSpriteFactory.Instance.CreateDeadMarioSprite();
        }
        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Idle;
            if (mario.facingLeft)
            {
                switch (mario.health)
                {
                    case (Mario.MarioHealth.Normal):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("NormalMarioStillLeft");
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("RaccoonMarioStillLeft");
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("FireMarioStillLeft");
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("BigMarioStillLeft");
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
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("NormalMarioStillRight");
                            break;
                        }

                    case (Mario.MarioHealth.Raccoon):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("RaccoonMarioStillRight");
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("FireMarioStillRight");
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.currentSprite = mario.mySpriteFactory.returnSprite("BigMarioStillRight");
                            break;
                        }
                }
            }
        }
    }
}
