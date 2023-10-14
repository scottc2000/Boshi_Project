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
                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillLeft");
            }
            
            else
            {
                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillRight");
            }
        }
    }
}