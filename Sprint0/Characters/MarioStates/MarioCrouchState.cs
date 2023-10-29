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
                        mario.State = new MarioCrouchState(mario); // Transition back to MarioMoveState
                        UpdateVelocity();
                        break;
                    case Mario.MarioHealth.Raccoon:
                        mario.health = Mario.MarioHealth.Big;
                        mario.State = new MarioCrouchState(mario); // Transition back to MarioMoveState
                        UpdateVelocity();
                        break;
                    case Mario.MarioHealth.Big:
                        mario.health = Mario.MarioHealth.Normal;
                        mario.State = new MarioCrouchState(mario); // Transition back to MarioMoveState
                        UpdateVelocity();
                        break;
                }
            }
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
