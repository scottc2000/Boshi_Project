using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Characters.MarioStates
{
    public class MarioIdleState : ICharacterState
    {
        private Mario mario;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames FileNames = new FileNames();
        public MarioIdleState(Mario mario)
        {
            this.mario = mario;
        }

        public void Move()
        {
            mario.State = new MarioMoveState(mario);
        }

        public void Jump()
        {
            if (mario.timeGap == 0)
            {
                mario.State = new MarioJumpState(mario);
                audioManager.PlaySFX(FileNames.jumpSFX);
            }
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


        public void Throw()
        {

            mario.State = new MarioThrowState(mario);

        }

        public void Stop()
        {
            mario.timeGap = 0;
            mario.pose = Mario.MarioPose.Idle;
        }
        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }
        public void UpdateVelocity()
        {
            mario.velocity.X *= 0;
            mario.velocity.Y *= 0;
        }
        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Idle;

            UpdateVelocity();
            if (mario.facingLeft)
            {
                if (mario.currentSprite.spriteName.Equals("MarioStillLeft"))
                {
                    mario.currentSprite.Update(gametime);
                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioStillLeft");
                }
            }
            else
            {
                if (mario.currentSprite.spriteName.Equals("MarioStillRight"))
                {
                    mario.currentSprite.Update(gametime);
                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioStillRight");
                }
            }
        }
    }
}