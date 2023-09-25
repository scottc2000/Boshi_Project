using Sprint0.Characters.MarioStates;
using Sprint0.Commands;
using Sprint0.Commands.Mario;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Mario()
        {
            health = MarioHealth.Normal;
            facingLeft = true;
            marioState = new MarioFaceLeft(this);
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

        public void Update()
        {

        }

        public void Draw()
        {
            marioState.Draw();
        }
    }
}
