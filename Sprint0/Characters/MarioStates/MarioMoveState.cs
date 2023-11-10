using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Characters.MarioStates
{
    public class MarioMoveState : ICharacterState
    {
        private Mario mario;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames FileNames = new FileNames();

        public MarioMoveState(Mario mario)
        {
            this.mario = mario;
            mario.boosted = false;    // initially mario does not have the boost
        }

        public void Move()
        {
            mario.State = new MarioMoveState(mario);
        }

        public void Jump()
        {
            mario.State = new MarioJumpState(mario);
            audioManager.PlaySFX(FileNames.jumpSFX);
        }
        public void Fly()
        {
            mario.State = new MarioFlyState(mario);
        }
        public void Fall()
        {
            // may be removed - unsure if needed for raccoon flight
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
            // if raccoon mario runs for certain amount of time, flight boost is given
            if (mario.runningTimer < 75)
            {
                mario.velocityX = 2.0f;
                mario.boosted = false;
            }
            else if (mario.runningTimer > 75)
            {
                mario.velocityX = 3.0f;
                mario.boosted = true;
            }

            mario.velocityY *= 0;
        }


        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Walking;

            UpdateVelocity();

            // Sprites if mario isn't in racoon boost mode
            if (mario.facingLeft && !mario.boosted)
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
            else if (!mario.facingLeft && !mario.boosted)
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
            if (mario.facingLeft && mario.boosted)
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
            else if (!mario.facingLeft && mario.boosted)
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