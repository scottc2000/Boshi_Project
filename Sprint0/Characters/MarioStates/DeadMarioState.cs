using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.ComponentModel.Design;

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

        public void Crouch()
        {
           
        }

        public void Stop()
        {
          
        }

        public void Throw()
        {
            

        }

        public void Die()
        {
            //death movement
        }
        public void Update(GameTime gametime)
        {
               mario.currentSprite = mario.mySpriteFactory.returnSprite("DeadMario"); //need to reset game after death

        }
    }
}