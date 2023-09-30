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
using Sprint0.Sprites;

namespace Sprint0.Characters
{
    public class Luigi : ICharacter
    {
        private bool facingLeft; // no longer needed i think, myDirection can be used instead
        public enum LuigiHealth { Normal, Star, Fire, Big};
        public LuigiHealth health; // big by default

        public ICharacterState luigiState; // states and sprites which can be modified from the outside.
        public AnimatedSprite currentSprite;

        public Vector2 position; 
        public Sprint0 mySprint;
        public int myDirection;
        public CharacterSpriteFactory mySpriteFactory;

        public Luigi(Sprint0 sprint0)
        {
            health = LuigiHealth.Big;
            myDirection = -1; // facing left by default
            facingLeft = true;
            position.X = 400; // center of screen by default
            position.Y = 240;
            mySprint = sprint0;
            mySpriteFactory = sprint0.spriteFactory;
            currentSprite = mySpriteFactory.returnSprite("BigLuigiStill", mySprint.myGameTime);
            luigiState = new LuigiFaceLeft(this);
            
            
            

        }

        // unsure how to implement these , right now I just have commands that change the directions and jump/crouch using sprite class
        public void ChangeDirection(int dir)
        {
            myDirection = dir;
        }

        // unsure how to implement these , right now I just have commands that change the directions and jump/crouch using sprite class
        public void MoveRight()
        {
            
            if (facingLeft)
            {
                luigiState.ChangeDirection();
                facingLeft = false;
            }
            luigiState.Move();
        }

        // unsure how to implement these , right now I just have commands that change the directions and jump/crouch using sprite class
        public void MoveLeft()
        {
            if (!facingLeft)
            {
                luigiState.ChangeDirection();
                facingLeft = true;
            }
            luigiState.Move();
        }

        // unsure how to implement these , right now I just have commands that change the directions and jump/crouch using sprite class
        public void Jump()
        {
            luigiState = new LuigiJumpState(this);
        }

        // unsure how to implement these , right now I just have commands that change the directions and jump/crouch using sprite class
        public void Crouch()
        {
            
            luigiState = new LuigiCrouchState(this);
        }

        // stop is the only method currently used by keyboard currently
        public void Stop()
        {
            luigiState.Stop();

        }

        // Character state class should handle updating I reckon
        public void Update()
        {
            luigiState.Update(mySprint.myGameTime);
        }

        public void Draw(SpriteBatch spritebatch, ContentManager content)
        {
            // draws current sprite (determined by state machine) to screen
            currentSprite.Draw(spritebatch, content, position);
        }

        public void ChangeToFire()
        {
            health = LuigiHealth.Fire;
        }

        public void ChangeToBig()
        {
            health = LuigiHealth.Big;
        }

        public void ChangeToNormal()
        {
            health = LuigiHealth.Normal;
        }

        public void ChangeDirection()
        {
            throw new NotImplementedException();
        }
    }
}
