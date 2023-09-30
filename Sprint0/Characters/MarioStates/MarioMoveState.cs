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
        public void Throw()
        {
                mario.State = new MarioThrowState(mario);
        }
        public void Die()
        {
           // mario.marioSprite = CharacterSpriteFactory.Instance.CreateDeadMarioSprite();
        }

        public void Update(GameTime gametime)
        {

            mario.pose = Mario.MarioPose.Walking;

            if (mario.facingLeft)
            {
                switch (mario.health)
                {
                    case (Mario.MarioHealth.Normal):
                        {
                            if (mario.currentSprite.spriteName.Equals("NormalMarioMoveLeft"))
                            {
                                mario.currentSprite.Update(gametime);
                            } else
                            {
                                mario.currentSprite = mario.mySpriteFactory.returnSprite("NormalMarioMoveLeft");
                            }
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            if (mario.currentSprite.spriteName.Equals("RaccoonMarioMoveLeft"))
                            {
                                mario.currentSprite.Update(gametime);
                            }
                            else
                            {
                                mario.currentSprite = mario.mySpriteFactory.returnSprite("RaccoonMarioMoveLeft");
                            }
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            if (mario.currentSprite.spriteName.Equals("FireMarioMoveLeft"))
                            {
                                mario.currentSprite.Update(gametime);
                            }
                            else
                            {
                                mario.currentSprite = mario.mySpriteFactory.returnSprite("FireMarioMoveLeft");
                            }
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            if (mario.currentSprite.spriteName.Equals("BigMarioMoveLeft"))
                            {
                                mario.currentSprite.Update(gametime);
                            } else
                            {
                                mario.currentSprite = mario.mySpriteFactory.returnSprite("BigMarioMoveLeft");
                            }
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
                            if (mario.currentSprite.spriteName.Equals("NormalMarioMoveRight"))
                            {
                                mario.currentSprite.Update(gametime);
                            } else
                            {
                                mario.currentSprite = mario.mySpriteFactory.returnSprite("NormalMarioMoveRight");
                            }
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            if (mario.currentSprite.spriteName.Equals("RaccoonMarioMoveRight"))
                            {
                                mario.currentSprite.Update(gametime);
                            } else
                            {
                                mario.currentSprite = mario.mySpriteFactory.returnSprite("RaccoonMarioMoveRight");
                            }
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            if (mario.currentSprite.spriteName.Equals("FireMarioMoveRight"))
                            {
                                mario.currentSprite.Update(gametime);
                            } else
                            {
                                mario.currentSprite = mario.mySpriteFactory.returnSprite("FireMarioMoveRight");
                            }
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            if (mario.currentSprite.spriteName.Equals("BigMarioMoveRight"))
                            {
                                mario.currentSprite.Update(gametime);
                            } else
                            {
                                mario.currentSprite = mario.mySpriteFactory.returnSprite("BigMarioMoveRight");
                            }
                            break;
                        }

                }
            }

            mario.pose = Mario.MarioPose.Walking;

        }
    }
}
