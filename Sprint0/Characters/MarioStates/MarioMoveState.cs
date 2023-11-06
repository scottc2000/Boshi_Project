using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System.Threading;

namespace Sprint0.Characters.MarioStates
{
    public class MarioMoveState : ICharacterState
    {
        private Mario mario;
        private bool boosted;

        public MarioMoveState(Mario mario)
        {
            this.mario = mario;
            boosted = false;
        }

        public void Move()
        {
            mario.State = new MarioMoveState(mario);
        }

        public void Jump()
        {
            //mario.State = new MarioJumpState(mario);
        }
        public void Fly()
        {
            mario.State = new MarioFlyState(mario);
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
            if (mario.runningTimer < 75)
                mario.velocity.X = 3.0f;
            else if (mario.runningTimer > 75)
            {
                mario.velocity.X = 4.0f;
                boosted = true;
            }

            mario.velocity.Y *= 0;
        }


        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Walking;

            UpdateVelocity();

            // Sprites if mario isn't in racoon boost mode
            if (mario.facingLeft && !boosted)
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
            else if (!mario.facingLeft && !boosted)
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

            // Sprites when mario's raccoon is in boost mode
            if (mario.facingLeft && boosted)
            {
                if (mario.currentSprite.spriteName.Equals("MarioBoostLeft"))
                {
                    mario.currentSprite.Update(gametime);
                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioBoostLeft");
                }
            }
            else if (!mario.facingLeft && boosted)
            {
                if (mario.currentSprite.spriteName.Equals("MarioBoostRight"))
                {
                    mario.currentSprite.Update(gametime);
                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioBoostRight");
                }
            }
        }
    }
}