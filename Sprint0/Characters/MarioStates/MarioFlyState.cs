using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Characters.MarioStates
{
    public class MarioFlyState : ICharacterState
    {
        private Mario mario;
        public MarioFlyState(Mario mario) 
        {
            this.mario = mario;
        }
        public void Crouch()
        {
            mario.State = new MarioCrouchState(mario);
        }

        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }

        public void Fall()
        {
            
        }

        public void Fly()
        {
            // insert logic 
        }

        public void Jump()
        {
            mario.State = new MarioJumpState(mario);
        }

        public void Move()
        {
            mario.State = new MarioMoveState(mario);
        }

        public void Stop()
        {
            
        }

        public void Throw()
        {
            mario.State = new MarioThrowState(mario);
        }

        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Flying;

            if (mario.facingLeft)
            {
                if (mario.currentSprite.spriteName.Equals("MarioFlyLeft"))
                {
                    mario.currentSprite.Update(gametime);
                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioFlyLeft");
                }
            }
            else
            {
                if (mario.currentSprite.spriteName.Equals("MarioFlyRight"))
                {
                    mario.currentSprite.Update(gametime);
                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioFlyRight");
                }

            }
        }
    }
}
