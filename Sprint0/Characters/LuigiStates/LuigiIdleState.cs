using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Characters.LuigiStates
{
    internal class LuigiIdleState : ICharacterState
    {
        private Luigi luigi;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames FileNames = new FileNames();
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
            if (luigi.timeGap == 0)
            {
                luigi.State = new LuigiJumpState(luigi);
                audioManager.PlaySFX(FileNames.jumpSFX);
            }

        }
        public void Fly() { }
        public void Fall()
        {

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
            luigi.timeGap = 0;
            luigi.State = new LuigiIdleState(luigi);
        }

        public void UpdateVelocity()
        {
            luigi.velocityX *= 0;
            luigi.velocityY *= 0;

        }

        public void Die()
        {
            luigi.State = new DeadLuigiState(luigi);
        }
        public void Update(GameTime gametime)
        {
            luigi.pose = Luigi.LuigiPose.Idle;

            UpdateVelocity();

            if (luigi.facingLeft)
            {
                if (luigi.currentSprite.spriteName.Equals("LuigiStillLeft")) {

                    luigi.currentSprite.Update(gametime);
                    
                }

                else
                {
                    luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillLeft");
                    
                }

            }
            
            else
            {
                if (luigi.currentSprite.spriteName.Equals("LuigiStillRight"))
                {

                    luigi.currentSprite.Update(gametime);

                }
                else
                {
                    luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillRight");
                    
                }
            }
        }
    }
}