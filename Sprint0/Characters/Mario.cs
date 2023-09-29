using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Characters
{
    internal class Mario : ICharacter
    {
        public enum MarioHealth { Normal, Star, Fire, Big};
        public MarioHealth health = MarioHealth.Normal;
        public ICharacterState State { get; set; }

        public bool isJumping;
        public bool isFalling;
        public bool facingLeft;

        public Vector2 position;
        public Sprint0 mySprint;

        public ISprite marioSprite;
        public Texture2D marioTexture;

        public Mario(Sprint0 sprint0)
        {
            this.health = MarioHealth.Normal;
            this.State = new MarioFaceLeft(this);

            this.facingLeft = true;
            this.isFalling = false;
            this.isJumping = false;

            this.position.X= 150;
            this.position.Y = 150;
            this.mySprint = sprint0;

            this.marioSprite = new MarioLeftIdleSprite(mySprint, this);
            marioTexture = mySprint.Content.Load<Texture2D>("SpriteImages/playerssclear");

        }


        public void MoveRight()
        {
            State.MoveRight();
        }

        public void MoveLeft()
        {
            State.MoveLeft();
        }

        public void Jump()
        {
            if (facingLeft)
            {
                State.JumpLeft();
            } else
            {
                State.JumpRight();
            }
        }

        public void Crouch()
        {
            if (facingLeft)
            {
                State.CrouchLeft();
            } else
            {
                State.CrouchRight();
            }
        }

        public void Stop()
        {
            if (facingLeft)
            {
                State.StopLeft();
            } else
            {
                State.StopRight();
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
           State.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            marioSprite.Draw(spritebatch);
        }
    }
}
