﻿using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Characters.LuigiStates
{
    internal class LuigiJumpState : ICharacterState
    {
        private Luigi luigi;
        private float yVelocity = -3.0f;

        public LuigiJumpState(Luigi luigi)
        {
            this.luigi = luigi;
        }

        public void Move()
        {
            luigi.velocityX = 2;
            
        }

        public void Jump()
        {
            luigi.State = new LuigiJumpState(luigi);
        }
        public void Fly() {
            //luigi.State = new LuigiFlyState(luigi);
            }
        public void Fall()
        {
            yVelocity = 0f;
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
            luigi.State = new DeadLuigiState(luigi);
        }

        public void UpdateVelocity(GameTime gametime)
        {
            if (luigi.timeGap < 500 )
            {
                luigi.velocityY = yVelocity;
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

            if (luigi.uphit && luigi.timeGap > 50)
            {
                luigi.Stop();
            }

            
        }
    }
    
}