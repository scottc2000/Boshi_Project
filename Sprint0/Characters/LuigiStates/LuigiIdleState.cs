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
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillLeft");
                            break;
                        }


                    case (Luigi.LuigiHealth.Raccoon):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillLeft");
                            break;
                        }

                    case (Luigi.LuigiHealth.Fire):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillLeft");
                            break;
                        }

                    case (Luigi.LuigiHealth.Big):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillLeft");
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
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillRight");
                            break;
                        }

                    case (Luigi.LuigiHealth.Raccoon):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillRight");
                            break;
                        }

                    case (Luigi.LuigiHealth.Fire):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillRight");
                            break;
                        }

                    case (Luigi.LuigiHealth.Big):
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillRight");
                            break;
                        }
                }
            }
        }
    }
}