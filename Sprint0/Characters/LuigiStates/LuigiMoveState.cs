using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;

namespace Sprint0.Characters.MarioStates
{
    internal class LuigiMoveState : ICharacterState
    {
        private Luigi luigi;

        public LuigiMoveState(Luigi luigi)
        {
            this.luigi = luigi;
        }

        public void Move()
        {
            if (luigi.facingLeft)
            {
                luigi.position.X -= 1;
            }
            else
            {
                luigi.position.X += 1;
            }
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

        }

        public void Update(GameTime gametime)
        {

            luigi.pose = Luigi.LuigiPose.Walking;

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
