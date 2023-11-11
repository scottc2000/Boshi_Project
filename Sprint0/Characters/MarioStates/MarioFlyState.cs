using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
            mario.State = new MarioFlyState(mario);
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

        public void UpdateVelocity(GameTime gametime)
        {
            if (mario.boosted)
            {
                mario.velocityY = -1.0f; // Ascend
                mario.flyingTimer++;
            }
            else
            {
                mario.velocityY = 1.0f; // Gradually descend
            }
            if (mario.flyingTimer >= 100)
            {
                mario.velocityY = 0;
            }
        }
        public void Update(GameTime gametime)
        {
           mario.pose = Mario.MarioPose.Flying;

           UpdateVelocity(gametime);
            
           SetSprites(gametime);
        }
        public void SetSprites(GameTime gametime)
            {
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

