using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioMoveState : ICharacterState
    {
        private Mario mario;

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
            mario.timeGap = 0;
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
            mario.timeGap = 0;
            mario.State = new MarioIdleState(mario);
        }
        public void Throw()
        {
            mario.State = new MarioThrowState(mario);
        }
        public void Die()
        {

        }

        public void UpdateVelocity()
        {
            mario.velocity.X = 1.0f;
            mario.velocity.Y *= 0;
        }


        public void Update(GameTime gametime)
        {



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
                    mario.UpStuck();
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
                    mario.UpStuck();

                }

            }
        }
    }
}