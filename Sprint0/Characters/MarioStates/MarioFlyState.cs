using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;

namespace Sprint0.Characters.MarioStates
{
    public class MarioFlyState : ICharacterState
    {
        private Mario mario;
        private float yVelocity = -4f;

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
            yVelocity = 0f;
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
            mario.velocity.X = 2;
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
            if (mario.flyingTimer < 4000)
            {
                mario.velocity.Y = yVelocity;
            }
            else
            {
                mario.velocity.Y = 0;
            }
            mario.flyingTimer += gametime.ElapsedGameTime.Milliseconds;

            if(mario.flyingTimer > 4000)
            {
                mario.boosted = false;
                mario.flyingTimer = 0;
                mario.State = new MarioIdleState(mario);
            }
        }

        public void Update(GameTime gametime)
        {
           mario.pose = Mario.MarioPose.Flying;

           UpdateVelocity(gametime);
            
           SetSprites(gametime);

            if (mario.uphit && mario.flyingTimer > 4000)
            {
                mario.Stop();
            }

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

