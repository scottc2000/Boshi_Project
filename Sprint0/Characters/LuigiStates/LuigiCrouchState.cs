using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.ComponentModel.Design;

namespace Sprint0.Characters.MarioStates
{
    internal class LuigiCrouchState : ICharacterState
    {
        private Luigi luigi;

        public LuigiCrouchState(Luigi luigi)
        {
            this.luigi = luigi;
        }

        public void Move()
        {
            luigi.State = new LuigiMoveState(luigi);
        }

        public void Jump()
        {
            luigi.State = new LuigiJumpState(luigi);
        }

        public void Crouch()
        {
            // mario.State = new MarioCrouchState(mario);   
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
            luigi.pose = Luigi.LuigiPose.Crouch;
            if (luigi.facingLeft)
            {
                switch (luigi.health)
                {
                    case (Luigi.LuigiHealth.Normal):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("NormalLuigiCrouchLeft");
                            break;
                        }


                    case (Luigi.LuigiHealth.Raccoon):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("BigLuigiCrouchLeft");
                            break;
                        }

                    case (Luigi.LuigiHealth.Fire):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("FireLuigiCrouchLeft");
                            break;
                        }

                    case (Luigi.LuigiHealth.Big):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("BigLuigiCrouchLeft");
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
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("NormalLuigiCrouchRight");
                            break;
                        }

                    case (Luigi.LuigiHealth.Raccoon):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("BigLuigiCrouchRight");
                            break;
                        }

                    case (Luigi.LuigiHealth.Fire):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("FireLuigiCrouchRight");
                            break;
                        }

                    case (Luigi.LuigiHealth.Big):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("BigLuigiCrouchRight");
                            break;
                        }
                }
            }
        }
    }
}
