using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Runtime.CompilerServices;

namespace Sprint0.Characters.MarioStates
{
    internal class LuigiIdleState : ICharacterState
    {
        private Luigi luigi;
        public LuigiIdleState(Luigi luigi)
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
            luigi.State = new LuigiCrouchState(luigi);
        }


        public void Throw()
        {

            luigi.State = new LuigiThrowState(luigi);

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
            luigi.pose = Luigi.LuigiPose.Idle;
            if (luigi.facingLeft)
            {
                switch (luigi.health)
                {
                    case (Luigi.LuigiHealth.Normal):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("NormalLuigiStillLeft");
                            break;
                        }


                    case (Luigi.LuigiHealth.Raccoon):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("RaccoonLuigiStillLeft");
                            break;
                        }

                    case (Luigi.LuigiHealth.Fire):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("FireLuigiStillLeft");
                            break;
                        }

                    case (Luigi.LuigiHealth.Big):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("BigLuigiStillLeft");
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
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("NormalLuigiStillRight");
                            break;
                        }

                    case (Luigi.LuigiHealth.Raccoon):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("RaccoonLuigiStillRight");
                            break;
                        }

                    case (Luigi.LuigiHealth.Fire):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("FireLuigiStillRight");
                            break;
                        }

                    case (Luigi.LuigiHealth.Big):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("BigLuigiStillRight");
                            break;
                        }
                }
            }
        }
    }
}