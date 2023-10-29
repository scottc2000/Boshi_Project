using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using static Sprint0.Characters.Mario;

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
        public void TakeDamage()
        {
            if (mario.health == Mario.MarioHealth.Normal)
            {
                mario.health = Mario.MarioHealth.Dead; // Set Mario's health to Dead
                mario.State = new DeadMarioState(mario); // Set Mario's state to DeadMarioState
                mario.velocity = Vector2.Zero; // Stop Mario's movement for Small Mario
            }
            else if (mario.gothit)
            {
                // Handle other health states
                switch (mario.health)
                {
                    case Mario.MarioHealth.Fire:
                        mario.health = Mario.MarioHealth.Big;
                        mario.State = new MarioMoveState(mario); // Transition back to MarioMoveState
                        UpdateVelocity();
                        break;
                    case Mario.MarioHealth.Raccoon:
                        mario.health = Mario.MarioHealth.Big;
                        mario.State = new MarioMoveState(mario); // Transition back to MarioMoveState
                        UpdateVelocity();
                        break;
                    case Mario.MarioHealth.Big:
                        mario.health = Mario.MarioHealth.Normal;
                        mario.State = new MarioMoveState(mario); // Transition back to MarioMoveState
                        UpdateVelocity();
                        break;
                }
            }
            System.Diagnostics.Debug.WriteLine("MarioHealth in MarioMoveState: " + mario.health);
        }
        public void Die()
        {
            if (mario.health == MarioHealth.Dead)
            {
                // Set the sprite to the "Mario dead" sprite
                mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioDead");
            }
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