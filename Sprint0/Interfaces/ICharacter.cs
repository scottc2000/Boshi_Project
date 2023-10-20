using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface ICharacter
    {
        ICharacterState State { get; set; }
        public enum Health{Normal, Raccoon, Fire, Big, Dead}
        bool facingLeft { get; set; }
        public Vector2 position { get; set; }

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

        void Update(GameTime gametime);

        void Draw(SpriteBatch spritebatch);
    }
}
