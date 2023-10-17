using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.ComponentModel.Design;

namespace Sprint0.Characters.MarioStates
{
    internal class LuigiThrowState : ICharacterState
    {
        private Luigi luigi;

        public LuigiThrowState(Luigi luigi)
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

        public void Stop()
        {
            luigi.State = new LuigiIdleState(luigi);
        }

        public void Throw()
        {

        }


        public void Die()
        {
            // mario.marioSprite = CharacterSpriteFactory.Instance.CreateDeadMarioSprite();
        }
        public void Update(GameTime gametime)
        {
            luigi.pose = Luigi.LuigiPose.Throwing;

            if (luigi.health == Luigi.LuigiHealth.Fire)
            {
                if (luigi.facingLeft)
                {
                    if (luigi.currentSprite.spriteName.Equals("LuigiThrowLeft"))
                    {

                        luigi.currentSprite.Update(gametime);
                    }
                    else
                    {
                        luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiThrowLeft");
                    }
                }
                else
                {
                    if (luigi.currentSprite.spriteName.Equals("LuigiThrowRight"))
                    {

                        luigi.currentSprite.Update(gametime);
                    }
                    else
                    {
                        luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiThrowRight");
                    }
                }
            }
            
        }
    }
}