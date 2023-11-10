using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Sprites.Players;

namespace Sprint0.Interfaces
{
    public interface IMario : ICollidable
    {
        Mario.MarioHealth health { get; set; }
        AnimatedSpriteMario currentSprite { get; set; }
        Vector2 position { get; set; }
        ICharacterState State { get; set; }
        bool facingLeft { get; set; }
        bool isInvinsible { get; set; }

        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }

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
