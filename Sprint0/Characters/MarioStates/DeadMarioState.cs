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
            if (mario.health == Mario.MarioHealth.Normal)
            {
                mario.health = Mario.MarioHealth.Dead; // Set Mario's health to Dead
                mario.State = new DeadMarioState(mario); // Set Mario's state to DeadMarioState
                mario.velocity = Vector2.Zero; // Stop Mario's movement for Small Mario
            }
        }
        public void Die()
        {
            if (mario.health == MarioHealth.Dead)
            {
                // Set the sprite to the "Mario dead" sprite
                mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioDead");
            }
        }
        public void Update(GameTime gametime)
        {
            mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioDead");

        }
    }
}