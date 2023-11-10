using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Characters.LuigiStates
{
    internal class LuigiJumpState : ICharacterState
    {
        private Luigi luigi;

        public LuigiJumpState(Luigi luigi)
        {
            luigi.velocityY = -3.0f;
            this.luigi = luigi;
        }

        public void Move()
        {
            if (luigi.facingLeft)
            {
                luigi.velocityX = -2;
            }
            else
            {
                luigi.velocityX = 2;
            }

            // luigi.State = new LuigiMoveState(luigi);
        }

        public void Jump()
        {
            luigi.State = new LuigiJumpState(luigi);
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
            luigi.velocityY = 0;
            luigi.State = new LuigiIdleState(luigi);
        }

        public void Die()
        {
            luigi.State = new DeadLuigiState(luigi);
        }

        public void UpdateVelocity(GameTime gametime)
        {
            if (luigi.timeGap < 500 )
            {
                //luigi.velocityY = -3.0f;
            }
            else
            {
                luigi.velocityY = 0;
            }

            
            luigi.timeGap += gametime.ElapsedGameTime.Milliseconds;

        }

        public void Update(GameTime gametime)
        {

            luigi.pose = Luigi.LuigiPose.Jump;

            UpdateVelocity(gametime);

            if (luigi.facingLeft)
            {
                if (luigi.currentSprite.spriteName.Equals("LuigiJumpLeft"))
                {

                    luigi.currentSprite.Update(gametime);

                }
                else
                {
                    luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiJumpLeft");
                    
                }

            }

            else 
            {
                if (luigi.currentSprite.spriteName.Equals("LuigiJumpRight"))
                {

                    luigi.currentSprite.Update(gametime);

                }
                else
                {
                    luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiJumpRight");
                    
                }
            }

            
        }
    }
    
}