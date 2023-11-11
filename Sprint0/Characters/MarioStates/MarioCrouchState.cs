using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Utility;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioCrouchState : ICharacterState
    {
        private Mario mario;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames FileNames = new FileNames();

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
            audioManager.PlaySFX(FileNames.jumpSFX);
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
        public void TakeDamage() 
        {
        }
        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }
        public void UpdateVelocity()
        {
            mario.velocityX *= mario.decay;
        }

        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Crouch;

            UpdateVelocity();

            if (mario.facingLeft)
            {
                if (mario.currentSprite.spriteName.Equals("marioCrouchLeft"))
                {

                    mario.currentSprite.Update(gametime);

                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("marioCrouchLeft");
                    mario.UpStuck();
                }

            }

            else
            {
                if (mario.currentSprite.spriteName.Equals("marioCrouchRight"))
                {

                    mario.currentSprite.Update(gametime);

                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("marioCrouchRight");
                    mario.UpStuck();
                }
            }
        }
    }
}
