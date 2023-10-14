using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.ComponentModel.Design;

namespace Sprint0.Characters.MarioStates
{
    internal class LuigiJumpState : ICharacterState
    {
        private Luigi luigi;

        public LuigiJumpState(Luigi luigi)
        {
            this.luigi = luigi;
        }

        public void Move()
        {
            luigi.State = new LuigiMoveState(luigi);
        }

        public void Jump()
        {
            // insert jump logic/physics
        }

        public void Crouch()
        {
            luigi.State = new LuigiCrouchState(luigi);
        }

        public void Throw()
        {
            luigi.State = new LuigiThrowState(luigi);
        }
        public void Stop()
        {
            luigi.State = new LuigiIdleState(luigi);
        }


        public void Die()
        {
            // mario.marioSprite = CharacterSpriteFactory.Instance.CreateDeadMarioSprite();
        }
        public void Update(GameTime gametime)
        {
            luigi.pose = Luigi.LuigiPose.Jump;
            if (luigi.facingLeft)
            {
                switch (luigi.health)
                {
                    case (Luigi.LuigiHealth.Normal):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiJumpLeft");
                            break;
                        }


                    case (Luigi.LuigiHealth.Raccoon):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiJumpLeft");
                            break;
                        }

                    case (Luigi.LuigiHealth.Fire):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiJumpLeft");
                            break;
                        }

                    case (Luigi.LuigiHealth.Big):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiJumpLeft");
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
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiJumpRight");
                            break;
                        }

                    case (Luigi.LuigiHealth.Raccoon):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiJumpRight");
                            break;
                        }

                    case (Luigi.LuigiHealth.Fire):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiJumpRight");
                            break;
                        }

                    case (Luigi.LuigiHealth.Big):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiJumpRight");
                            break;
                        }
                }
            }
        }
    }
}
