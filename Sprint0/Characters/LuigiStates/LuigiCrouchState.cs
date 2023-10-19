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
        public void Fall()
        {

        }
        public void Crouch()
        {
   
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
    
        }
        public void Update(GameTime gametime)
        {
            luigi.pose = Luigi.LuigiPose.Crouch;
            if (luigi.facingLeft)
            {
                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiCrouchLeft");
            }
            else
            {    
                 luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiCrouchRight");
                           
                     
            }
        }
    }
}
