using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioJumpState : ICharacterState
    {
        private Mario mario;
        private float yVelocity = -3.0f;

        public MarioJumpState(Mario mario)
        {
            this.mario = mario;
           
        }

        public void Move()
        {
            mario.velocityX = 2;
        }

        public void Jump()
        {
            mario.State = new MarioJumpState(mario);
        }
        public void Fly()
        {
            mario.State = new MarioFlyState(mario);
        }
        public void Fall()
        {
            yVelocity = 0f;
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

        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }

        public void UpdateVelocity(GameTime gametime)
        {
            if (mario.timeGap < 500)
            {
                mario.velocityY = yVelocity;
            }
            else
            {
                mario.velocityY = 0;
            }

            mario.timeGap += gametime.ElapsedGameTime.Milliseconds;
        }

        public void Update(GameTime gametime)
        {

            mario.pose = Mario.MarioPose.Jump;

            UpdateVelocity(gametime);

            if (mario.facingLeft)
            {
                if (mario.currentSprite.spriteName.Equals("MarioJumpLeft"))
                {

                    mario.currentSprite.Update(gametime);

                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioJumpLeft");
                }

            }

            else
            {
                if (mario.currentSprite.spriteName.Equals("MarioJumpRight"))
                {

                    mario.currentSprite.Update(gametime);

                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioJumpRight");
                }
            }

            if (mario.uphit && mario.timeGap > 50)
            {
                mario.Stop();
            }

        }
    }

}