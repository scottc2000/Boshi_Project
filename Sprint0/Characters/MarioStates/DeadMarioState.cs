using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactories;
using System;
using System.ComponentModel.Design;
using static Sprint0.Characters.Mario;

namespace Sprint0.Characters.MarioStates
{
    internal class DeadMarioState : ICharacterState
    {
        private Mario mario;

        public DeadMarioState(Mario mario)
        {
            this.mario = mario;
        }

        public void Move()
        {

        }

        public void Jump()
        {

        }
        public void Fall()
        {

        }

        public void Crouch()
        {

        }

        public void Stop()
        {

        }

        public void Throw()
        {


        }
        public void TakeDamage() 
        {

        }
        public void Die()
        {
             mario.velocity = Vector2.Zero;
        }
        public void Update(GameTime gametime)
        {
            mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioDead");

        }
    }
}