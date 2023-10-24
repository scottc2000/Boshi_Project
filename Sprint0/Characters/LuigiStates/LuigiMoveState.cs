﻿using Microsoft.Xna.Framework;
using Sprint0.Characters.LuigiStates;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.LuigiStates
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
            
            luigi.State = new LuigiMoveState(luigi);
        }

        public void Jump()
        {
            luigi.timeGap = 0;
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
            luigi.timeGap = 0;
            luigi.State = new LuigiIdleState(luigi);
        }
        public void Throw()
        {
            luigi.State = new LuigiThrowState(luigi);
        }
        public void Die()
        {

        }

        public void UpdateVelocity()
        {
            luigi.velocityX = 1.0f;
            luigi.velocityY *= 0;
        }


        public void Update(GameTime gametime)
        {

            

            if (!(luigi.lefthit))
            {
                UpdateVelocity();
            }
            if (!(luigi.righthit))
            {
                UpdateVelocity();
            }

            if (luigi.facingLeft)
            {
                if (luigi.currentSprite.spriteName.Equals("LuigiMoveLeft"))
                {
                    luigi.currentSprite.Update(gametime);
                }
                else
                {
                    luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiMoveLeft");
                    luigi.UpStuck();
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
                    luigi.UpStuck();

                }

            }
        }
    }
}