using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.ComponentModel.Design;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioThrowState : ICharacterState
    {
        private Mario mario;

        public MarioThrowState(Mario mario)
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


        }

        public void Die()
        {
            mario.State = new DeadMarioState(mario); // big mario falls -> KO
        }
        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Throwing;
            if (mario.facingLeft && mario.health == Mario.MarioHealth.Fire)
            {
                
            }
            else
            {

            }
        }
    }
}