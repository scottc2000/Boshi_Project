﻿using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Characters.LuigiStates
{
    internal class LuigiCrouchState : ICharacterState
    {
        private Luigi luigi;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames FileNames = new FileNames();

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
            audioManager.PlaySFX(FileNames.jumpSFX);
        }
        public void Fly() { }
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
            luigi.State = new DeadLuigiState(luigi);
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
