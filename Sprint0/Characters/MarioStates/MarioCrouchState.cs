using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioCrouchState : ICharacterState
    {
        private Mario mario;

        public MarioCrouchState(Mario mario)
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
            AudioManager audioManager = AudioManager.Instance;
            audioManager.PlaySFX("jump");
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
        public void TakeDamage() 
        {
        }
        public void UpdateVelocity()
        {
            mario.velocity = Vector2.Zero;
        }
        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }
        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Crouch;
            if (mario.facingLeft)
            {
                mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioCrouchLeft");
            }
            else
            {
                mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioCrouchRight");


            }
        }
    }
}
