using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Items.Projectiles;
using Sprint0.Sprites.Players;

namespace Sprint0.Interfaces
{
    public interface IPlayer : ICollidable, IGameObject
    {
        ICharacterState State { get; set; }
        public Player.PlayerHealth health { get; set; }
        public Player.PlayerPose pose { get; set; }
        AnimatedSpritePlayer currentSprite { get; set; }
        Vector2 position { get; set; }
        int number { get; set; }
        bool facingLeft { get; set; }
        bool isInvinsible { get; set; }
        int flyingTimer { get; set; }
        bool boosted { get; set; }
        bool fired { get; set; }

        bool upHit { get; set; }
        FireProjectile fireProjectile { get; set; }
        int runningTimer { get; set; }

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

    }
}
