using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface ICharacter : ICollidable
    {
        ICharacterState State { get; set; }
        bool facingLeft { get; set; }
        bool isInvinsible { get; set; }

        public void Move();

        public void Jump();

        public void Crouch();

        public void Stop();

        public void Die();

        public void Throw();
      
        void ChangeToFire();

        void ChangeToRaccoon();

        void ChangeToBig();

        void ChangeToNormal();

        void Reverse();

        void Update(GameTime gametime);

        void Draw(SpriteBatch spritebatch);
    }
}
