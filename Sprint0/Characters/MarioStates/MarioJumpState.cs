using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using System;
using System.ComponentModel.Design;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioJumpState : ICharacterState
    {
        private Mario mario;

        private Vector2 marioVelocity;
        float jumpVelocity = -500f; // Initial jump velocity
        bool isJumping = false;

        public MarioJumpState(Mario mario)
        {
            this.mario = mario;

        }

        public void Move()
        {
            mario.State = new MarioMoveState(mario);
        }

        public void Jump()
        {
            mario.pose = Mario.MarioPose.Jump;
            if (mario.facingLeft)
            {
                mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioJumpLeft");

            }
            else
            {
                mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioJumpRight");
            }
        }
        public void Fall()
        {
            if (mario.facingLeft)
            {
                mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioStillLeft");

            }
            else
            {
                mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioStillRight");
            }
        }

        public void Crouch()
        {
            mario.State = new MarioCrouchState(mario);
        }

        public void Throw()
        {
            mario.State = new MarioThrowState(mario);
        }
        public void Stop()
        {
            mario.State = new MarioIdleState(mario);
        }
        public void UpdateGravity()
        {
            mario.gravity = 20f;
        }

        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }
        public void Update(GameTime gametime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && !isJumping)
            {
                marioVelocity.Y = jumpVelocity;
                isJumping = true;
            }

            if (!mario.uphit)
            {
                UpdateGravity();
            }
            else
            {
                isJumping = false;
            }

            // Update Mario's position based on velocity
            mario.position += marioVelocity * (float)gametime.ElapsedGameTime.TotalSeconds;

            // Apply gravity
            marioVelocity.Y += mario.gravity;

            // Check for ground collision
            if (mario.position.Y >= mario.mySprint._graphics.PreferredBackBufferHeight - 100)
            {
                mario.position.Y = mario.mySprint._graphics.PreferredBackBufferHeight - 100;
                marioVelocity.Y = 0;
                isJumping = false;
                Fall();
            }

        }
    }
}