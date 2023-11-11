using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Items.Projectiles;
using Sprint0.Sprites.Players;

namespace Sprint0.Interfaces
{
    public interface ILuigi : ICollidable, IGameObject
    {
        ICharacterState State { get; set; }
        public Luigi.LuigiHealth health { get; set; }
        AnimatedSpriteLuigi currentSprite { get; set; }
        public Vector2 position { get; set; }
        bool facingLeft { get; set; }
        bool isInvinsible { get; set; }
        public int flyingTimer { get; set; }
        public bool boosted { get; set; }
        FireProjectile fireProjectile { get; set; }
        public int runningTimer { get; set; }
        public Luigi.LuigiPose pose { get; set; }

        public void Move();

        public void Fall();

        public void Jump();

        public void Crouch();

        public void Stop();

        public void Die();

        public void Throw();

        public void Fly();
      
        void ChangeToFire();

        void ChangeToRaccoon();

        void ChangeToBig();

        void ChangeToNormal();

        void Reverse();

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

    }
}
