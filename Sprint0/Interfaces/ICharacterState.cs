using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces
{
    public interface ICharacterState
    {
        public void Move();

        public void Jump();
        public void Fall();
        public void Crouch();
        public void Stop();
        public void TakeDamage();
        public void Die();
        public void Throw();

        public void Update(GameTime gametime);
    }
}
