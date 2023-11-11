using Microsoft.Xna.Framework;
using Sprint0.Characters.LuigiStates;
using Sprint0.Interfaces;
using Sprint0.Utility;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.LuigiStates
{
    public class LuigiMoveState : ICharacterState
    {
        private Luigi luigi;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames FileNames = new FileNames();

        public LuigiMoveState(Luigi luigi)
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
            audioManager.PlaySFX(FileNames.jumpSFX);
        }
        public void Fly()
        {
            luigi.State = new LuigiFlyState(luigi);
        }
        public void Fall()
        {

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
            luigi.State = new DeadLuigiState(luigi);
        }

        public void UpdateVelocity()
        {
            if (luigi.runningTimer < 75)
            {
                luigi.velocityX = 2.0f;
                luigi.boosted = false;
            }
            else if (luigi.runningTimer > 75)
            {
                luigi.velocityX = 3.0f;
                luigi.boosted = true;
            }
            luigi.velocityY *= 0;
        }


        public void Update(GameTime gametime)
        {


            luigi.pose = Luigi.LuigiPose.Walking;

            UpdateVelocity();

            if (luigi.boosted)
            {
                if (luigi.facingLeft)
                {
                    if (luigi.currentSprite.spriteName.Equals("LuigiBoostLeft"))
                    {
                        luigi.currentSprite.Update(gametime);
                    }
                    else
                    {
                        luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiBoostLeft");

                    }
                }
                else
                {
                    if (luigi.currentSprite.spriteName.Equals("LuigiBoostRight"))
                    {
                        luigi.currentSprite.Update(gametime);
                    }
                    else
                    {
                        luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiBoostRight");


                    }

                }
            }
            else
            {
                if (luigi.facingLeft)
                {
                    if (luigi.currentSprite.spriteName.Equals("LuigiMoveLeft"))
                    {
                        luigi.currentSprite.Update(gametime);
                    }
                    else
                    {
                        luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiMoveLeft");

                    }
                }
                else
                {
                    if (luigi.currentSprite.spriteName.Equals("LuigiMoveRight"))
                    {
                        luigi.currentSprite.Update(gametime);
                    }
                    else
                    {
                        luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiMoveRight");


                    }

                }
            }
        }
    }
}