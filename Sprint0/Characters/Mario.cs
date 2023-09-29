using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.MarioStates;
using Sprint0.Commands;
using Sprint0.Commands.Mario;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters
{
    internal class Mario : ICharacter
    {
        private bool facingLeft;
        public enum MarioHealth { Normal, Star, Fire, Big};
        public MarioHealth health = MarioHealth.Normal;
        public ICharacterState marioState;
        public Vector2 position { get; set; }
        public Sprint0 mySprint;
        public Mario(Sprint0 sprint0)
        {
            health = MarioHealth.Normal;
            facingLeft = true;
            marioState = new MarioFaceLeft(this);
            mySprint = sprint0;

        }

        public void ChangeDirection()
        {
            marioState.ChangeDirection();
        }

        public void MoveRight()
        {
            if (facingLeft)
            {
                marioState.ChangeDirection();
                facingLeft = false;
            }
            marioState.Move();
        }

        public void MoveLeft()
        {
            if (!facingLeft)
            {
                marioState.ChangeDirection();
                facingLeft = true;
            }
            marioState.Move();
        }

        public void Jump()
        {
            if (facingLeft)
            {
                marioState = new MarioJumpFaceLeft(this);
            }
            else
            {
                marioState = new MarioJumpFaceRight(this);
            }
        }

        public void Crouch()
        {
            if (facingLeft) { 
                marioState = new MarioCrouchFaceLeft(this);
            } else
            {
                marioState = new MarioCrouchFaceRight(this);
            }
        }



        public void Stop()
        {
            if(facingLeft)
            {
                marioState = new MarioFaceLeft(this);
            } else
            {
                marioState = new MarioFaceRight(this);
            }

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spritebatch, ContentManager content)
        {
           // marioState.Draw();
        }

        public void ChangeToFire()
        {
            throw new NotImplementedException();
        }

        public void ChangeToBig()
        {
            throw new NotImplementedException();
        }

        public void ChangeToNormal()
        {
            throw new NotImplementedException();
        }
    }
}
