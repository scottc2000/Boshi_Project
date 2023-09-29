using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface ICharacter
    {
        ICharacterState State { get; set; }


        public void MoveRight();

        public void MoveLeft();

        public void Jump();

        public void Crouch();

        public void Stop();

        void ChangeToFire();

        void ChangeToRaccoon();

        void ChangeToBig();

        void ChangeToNormal();

        void Update();

        void Draw(SpriteBatch spritebatch);
    }
}
