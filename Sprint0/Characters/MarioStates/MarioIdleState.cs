using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioIdleState : ICharacterState
    {
        private Mario mario;
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
            mario.State = new MarioJumpState(mario);
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
                        mario.State = new MarioIdleState(mario); // Transition back to MarioMoveState
                        UpdateVelocity();
                        break;
                    case Mario.MarioHealth.Raccoon:
                        mario.health = Mario.MarioHealth.Big;
                        mario.State = new MarioIdleState(mario); // Transition back to MarioMoveState
                        UpdateVelocity();
                        break;
                    case Mario.MarioHealth.Big:
                        mario.health = Mario.MarioHealth.Normal;
                        mario.State = new MarioIdleState(mario); // Transition back to MarioMoveState
                        UpdateVelocity();
                        break;
                }
            }
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