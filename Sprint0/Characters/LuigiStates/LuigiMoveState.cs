using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;

namespace Sprint0.Characters.MarioStates
{
    internal class LuigiMoveState : ICharacterState
    {
        private Luigi luigi;

        public LuigiMoveState(Luigi luigi)
        {
            this.luigi = luigi;
        }

        public void Move()
        {
            if (luigi.facingLeft)
            {
                luigi.position.X -= 1;
            }
            else
            {
                luigi.position.X += 1;
            }
        }

        public void Jump()
        {
            luigi.State = new LuigiJumpState(luigi);
        }

        public void Crouch()
        {
            luigi.State = new LuigiCrouchState(luigi);
        }

        public void Stop()
        {
            luigi.State = new LuigiIdleState(luigi);
        }
        public void Throw()
        {
            luigi.State = new LuigiThrowState(luigi);
        }
        public void Die()
        {
            // mario.marioSprite = CharacterSpriteFactory.Instance.CreateDeadMarioSprite();
        }

        public void Update(GameTime gametime)
        {

            luigi.pose = Luigi.LuigiPose.Walking;

            if (luigi.facingLeft)
            {
                switch (luigi.health)
                {
                    case (Luigi.LuigiHealth.Normal):
                        {
                            if (luigi.currentSprite.spriteName.Equals("NormalLuigiMoveLeft"))
                            {
                                luigi.currentSprite.Update(gametime);
                            }
                            else
                            {
                                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("NormalLuigiMoveLeft");
                            }
                            break;
                        }


                    case (Luigi.LuigiHealth.Raccoon):
                        {
                            if (luigi.currentSprite.spriteName.Equals("RaccoonLuigiMoveLeft"))
                            {
                                luigi.currentSprite.Update(gametime);
                            }
                            else
                            {
                                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("RaccoonLuigiMoveLeft");
                            }
                            break;
                        }

                    case (Luigi.LuigiHealth.Fire):
                        {
                            if (luigi.currentSprite.spriteName.Equals("FireLuigiMoveLeft"))
                            {
                                luigi.currentSprite.Update(gametime);
                            }
                            else
                            {
                                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("FireLuigiMoveLeft");
                            }
                            break;
                        }

                    case (Luigi.LuigiHealth.Big):
                        {
                            if (luigi.currentSprite.spriteName.Equals("BigLuigiMoveLeft"))
                            {
                                luigi.currentSprite.Update(gametime);
                            }
                            else
                            {
                                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("BigLuigiMoveLeft");
                            }
                            break;
                        }

                }
            }
            else
            {
                switch (luigi.health)
                {
                    case (Luigi.LuigiHealth.Normal):
                        {
                            if (luigi.currentSprite.spriteName.Equals("NormalLuigiMoveRight"))
                            {
                                luigi.currentSprite.Update(gametime);
                            }
                            else
                            {
                                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("NormalLuigiMoveRight");
                            }
                            break;
                        }


                    case (Luigi.LuigiHealth.Raccoon):
                        {
                            if (luigi.currentSprite.spriteName.Equals("RaccoonLuigiMoveRight"))
                            {
                                luigi.currentSprite.Update(gametime);
                            }
                            else
                            {
                                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("RaccoonLuigiMoveRight");
                            }
                            break;
                        }

                    case (Luigi.LuigiHealth.Fire):
                        {
                            if (luigi.currentSprite.spriteName.Equals("FireLuigiMoveRight"))
                            {
                                luigi.currentSprite.Update(gametime);
                            }
                            else
                            {
                                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("FireLuigiMoveRight");
                            }
                            break;
                        }

                    case (Luigi.LuigiHealth.Big):
                        {
                            if (luigi.currentSprite.spriteName.Equals("BigLuigiMoveRight"))
                            {
                                luigi.currentSprite.Update(gametime);
                            }
                            else
                            {
                                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("BigLuigiMoveRight");
                            }
                            break;
                        }

                }
            }

            luigi.pose = Luigi.LuigiPose.Walking;

        }
    }
}
