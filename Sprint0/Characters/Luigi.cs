using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.MarioStates;
using Sprint0.Commands;
using Sprint0.Commands.Mario;
using Sprint0.Commands.Luigi;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Characters.LuigiStates;

namespace Sprint0.Characters
{
    public class Luigi : ICharacter
    {
        private bool facingLeft; // no longer needed i think, myDirection can be used instead
        public enum LuigiHealth { Normal, Star, Fire, Big};
        public LuigiHealth health = LuigiHealth.Normal; // normal by default

        public ICharacterState luigiState; // states and sprites which can be modified from the outside.
        public ISprite currentSprite;

        public Vector2 position; 
        public Sprint0 mySprint;
        public int myDirection;

        public Luigi(Sprint0 sprint0)
        {
            health = LuigiHealth.Normal;
            myDirection = -1; // facing left by default
            facingLeft = true;
            position.X = 400; // center of screen by default
            position.Y = 240;
            luigiState = new LuigiFaceLeft(this); // facing left still is default state machine
            
            mySprint = sprint0;

        }

        // unsure how to implement these, right now I just have commands that change the directions and jump/crouch using sprite class
        public void ChangeDirection()
        {
            luigiState.ChangeDirection();
        }

        public void MoveRight()
        {
            
            if (facingLeft)
            {
                luigiState.ChangeDirection();
                facingLeft = false;
            }
            luigiState.Move();
        }

        public void MoveLeft()
        {
            if (!facingLeft)
            {
                luigiState.ChangeDirection();
                facingLeft = true;
            }
            luigiState.Move();
        }

        public void Jump()
        {
            luigiState = new LuigiJumpState(this);
        }

        public void Crouch()
        {
            
            luigiState = new LuigiCrouchState(this);
        }

        // stop is the only method currently used by keyboard currently
        public void Stop()
        {
            if(facingLeft)
            {
                luigiState = new LuigiFaceLeft(this);
            } else
            {
                luigiState = new LuigiFaceRight(this);
            }

        }

        public void Update()
        {
           
        }

        public void Draw(SpriteBatch spritebatch, ContentManager content)
        {
            // draws current sprite (determined by state machine) to screen
            currentSprite.Draw(spritebatch, content);
        }
    }
}
