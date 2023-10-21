﻿using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using System;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioMoveState : ICharacterState
    {
        private Mario mario;
        float moveSpeed = 200f; // Mario's horizontal movement speed

        public MarioMoveState(Mario mario)
        {
            this.mario = mario;
        }

        public void Move()
        {
            mario.State = new MarioMoveState(mario);
        }

        public void Jump()
        {
            mario.State = new MarioJumpState(mario);
        }
        public void Fall()
        {

        }
        public void Crouch()
        {
            mario.State = new MarioCrouchState(mario);
        }

        public void Stop()
        {
            mario.State = new MarioIdleState(mario);
        }
        public void Throw()
        {
            mario.State = new MarioThrowState(mario);
        }
        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }
        public void UpdateVelocity()
        {
            mario.velocity = 1.0f;
        }

        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Walking;

            if (!(mario.lefthit))
            {
                UpdateVelocity();
            }
            if (!(mario.righthit))
            {
                UpdateVelocity();
            }

            if (mario.facingLeft)
            {
                if (mario.currentSprite.spriteName.Equals("MarioMoveLeft"))
                {
                    mario.currentSprite.Update(gametime);
                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioMoveLeft");
                }
            }
            else
            {
                if (mario.currentSprite.spriteName.Equals("MarioMoveRight"))
                {
                    mario.currentSprite.Update(gametime);
                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioMoveRight");
                }

            }

        }

    }
}

