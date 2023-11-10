using Microsoft.Xna.Framework;
using Sprint0.Characters;
using Sprint0.Sprites.Players;

namespace Sprint0.Interfaces
{
    public interface IMario : ICollidable, IGameObject
    {
        Mario.MarioHealth health { get; set; }
        Mario.MarioPose pose { get; set; }
        AnimatedSpriteMario currentSprite { get; set; }
        Vector2 position { get; set; }
        ICharacterState State { get; set; }
        bool facingLeft { get; set; }
        bool isInvinsible { get; set; }
        int runningTimer { get; set; }
        int flyingTimer { get; set; }
        public void Move();

        public void Jump();
        public void Fly();

        public void Crouch();

        public void Stop();

        public void Die();

        public void Throw();

        void ChangeToFire();

        void ChangeToRaccoon();

        void ChangeToBig();

        void ChangeToNormal();

        void Reverse();


    }
}
