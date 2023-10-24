using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;

namespace Sprint0.Characters.LuigiStates
{
    internal class LuigiJumpState : ICharacterState
    {
        private Luigi luigi;

        private Vector2 luigiVelocity;
        float jumpVelocity = -500f; // Initial jump velocity
        bool isJumping = false;

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
        public void Fall()
        {
            if (luigi.facingLeft)
            {
                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillLeft");

            }
            else
            {
                luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiStillRight");
            }
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
        public void UpdateGravity()
        {
            luigi.gravity = 20f;
        }
        public void Die()
        {
            // mario.marioSprite = CharacterSpriteFactory.Instance.CreateDeadMarioSprite();
        }
        public void Update(GameTime gametime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && !isJumping)
            {
                luigiVelocity.Y = jumpVelocity;
                isJumping = true;
            }
            if (!(luigi.uphit))
            {
                UpdateGravity();
            }
            else
            {
                isJumping = false;
            }

            // Update Luigi's position based on velocity
            luigi.position += luigiVelocity * (float)gametime.ElapsedGameTime.TotalSeconds;

            // Apply gravity
            luigiVelocity.Y += luigi.gravity;

            // Check for ground collision
            if (luigi.position.Y >= luigi.mySprint._graphics.PreferredBackBufferHeight - 100)
            {
                luigi.position.Y = luigi.mySprint._graphics.PreferredBackBufferHeight - 100;
                luigiVelocity.Y = 0;
                isJumping = false;
                Fall();
            }
        }
    }
}