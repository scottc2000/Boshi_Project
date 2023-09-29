using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface ICharacter
    {
        ICharacterState State { get; set; }
        bool facingLeft { get; set; }

        public void Move();

        public void Jump();

        public void Crouch();

        public void Stop();

        public void Die();

        void ChangeToFire();

        void ChangeToRaccoon();

        void ChangeToBig();

        void ChangeToNormal();

        void Update(GameTime gametime);

        void Draw(SpriteBatch spritebatch);
    }
}
