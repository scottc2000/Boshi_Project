using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using System;
using System.Runtime.CompilerServices;
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
            mario.pose = Mario.MarioPose.Idle;
        }


        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }
        public void UpdateVelocity()
        {
            mario.velocity *= 0;
        }
        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Idle;

            UpdateVelocity();  
        }
    }
}