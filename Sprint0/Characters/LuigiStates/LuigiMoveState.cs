using Microsoft.Xna.Framework;
using Sprint0.Characters.LuigiStates;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Characters.LuigiStates
{
    public class LuigiMoveState : ICharacterState
    {
        private Luigi luigi;
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
            AudioManager audioManager = AudioManager.Instance;
            audioManager.PlaySFX(FileNames.jumpSFX);
        }
        public void Fly()
        {

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
            luigi.velocityX = 3.0f;
            luigi.velocityY = 0;
        }


        public void Update(GameTime gametime)
        {


            luigi.pose = Luigi.LuigiPose.Walking;

            UpdateVelocity();

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