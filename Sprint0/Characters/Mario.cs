using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
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
        public ICharacterState State { get; set; }
        public bool isJumping { get; set; }
        public bool isFalling { get; set; }
        public Vector2 position;
        public Sprint0 mySprint;
        public int direction;
        public Mario(Sprint0 sprint0, Vector2 location)
        {
            this.health = MarioHealth.Normal;
            this.facingLeft = true;
            this.State = new MarioFaceLeft(this);
            this.mySprint = sprint0;
            this.position = location;
            this.direction = -1;

        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void MoveRight()
        {
            if (facingLeft)
            {
                State.ChangeDirection();
                facingLeft = false;
                direction = 1;
            }
            State = new MarioMoveRight(this);
        }

        public void MoveLeft()
        {
            if (!facingLeft)
            {
                State.ChangeDirection();
                facingLeft = true;
                direction = -1;
            }
            State = new MarioMoveLeft(this);
        }

        public void Jump()
        {
            if (facingLeft)
            {
                direction = -1;
                State = new MarioJumpFaceLeft(this);
            }
            else
            {
                direction = 1;
                State = new MarioJumpFaceRight(this);
            }
        }

        public void Crouch()
        {
            if (facingLeft) {
                direction = -1;
                State = new MarioCrouchFaceLeft(this);
            } else
            {
                direction = 1;
                State = new MarioCrouchFaceRight(this);
            }
        }

        public void Stop()
        {
            if(facingLeft)
            {
                direction = -1;
                State = new MarioFaceLeft(this);
            } else
            {
                direction = 1;
                State = new MarioFaceRight(this);
            }

        }

        public void ChangeToFire()
        {
            health = MarioHealth.Fire;
        }

        public void ChangeToBig()
        {
            health = MarioHealth.Big;
        }

        public void ChangeToNormal()
        {
            health = MarioHealth.Normal;
        }

        public void Update()
        {
           // this.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            State.Draw(spritebatch, position);
        }
    }
}
