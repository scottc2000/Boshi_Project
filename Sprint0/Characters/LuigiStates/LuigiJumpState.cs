using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.ComponentModel.Design;

namespace Sprint0.Characters.MarioStates
{
    internal class LuigiJumpState : ICharacterState
    {
        private Luigi luigi;

        public LuigiJumpState(Luigi luigi)
        {
            this.luigi = luigi;
        }

        public void Move()
        {
            luigi.State = new LuigiMoveState(luigi);
        }

        public void Jump()
        {
            // insert jump logic/physics
        }
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
            luigi.State = new LuigiIdleState(luigi);
        }


        public void Die()
        {
            // mario.marioSprite = CharacterSpriteFactory.Instance.CreateDeadMarioSprite();
        }
        public void Update(GameTime gametime)
        {
            luigi.pose = Luigi.LuigiPose.Jump;
            if (luigi.facingLeft)
            {
                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiJumpLeft");
                
            }
            else
            {
                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiJumpRight");
            }
        }
    }
}
