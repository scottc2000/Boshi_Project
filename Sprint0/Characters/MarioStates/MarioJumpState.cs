using Microsoft.Xna.Framework;
using Sprint0.Interfaces;


namespace Sprint0.Characters.MarioStates
{
    internal class MarioJumpState : ICharacterState
    {
        private Mario mario;

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
            mario.State = new MarioJumpState(mario);
        }

        public void Fall()
        {

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
            mario.velocity.Y = 0;
            mario.State = new MarioIdleState(mario);
        }

        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }

        public void UpdateVelocity(GameTime gametime)
        {
            if (!mario.downhit && mario.timeGap < 500)
                mario.velocity.Y = -4.0f;
            else
                mario.velocity.Y = 0;

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
                    mario.UpStuck();
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
                    mario.UpStuck();
                }
            }


        }
    }

}