using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Characters.LuigiStates
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
            AudioManager audioManager = AudioManager.Instance;
            audioManager.PlaySFX("jump");
        }
        public void Fall()
        {

        }
        public void Crouch()
        {
   
        }

        public void Stop()
        {
            luigi.timeGap = 0;
            luigi.State = new LuigiIdleState(luigi);
        }

        public void Throw()
        {
            luigi.State = new LuigiThrowState(luigi);
        }
        public void TakeDamage() { }
        public void Die()
        {
    
        }

        public void UpdateVelocity()
        {
            luigi.velocityX *= luigi.decay;
        }

        public void Update(GameTime gametime)
        {
            luigi.pose = Luigi.LuigiPose.Crouch;

            UpdateVelocity();

            if (luigi.facingLeft)
            {
                if (luigi.currentSprite.spriteName.Equals("LuigiCrouchLeft"))
                {

                    luigi.currentSprite.Update(gametime);

                }
                else
                {
                    luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiCrouchLeft");
                    luigi.UpStuck();
                }

            }

            else
            {
                if (luigi.currentSprite.spriteName.Equals("LuigiCrouchRight"))
                {

                    luigi.currentSprite.Update(gametime);

                }
                else
                {
                    luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiCrouchRight");
                    luigi.UpStuck();
                }
            }
        }
    }
}
