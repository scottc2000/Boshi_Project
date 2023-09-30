using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces
{
    public interface ICharacterState
    {
        public void Move();

        public void Jump();
        public void Crouch();
        public void Stop();
        public void Throw();

        public void Die();

        public void Update(GameTime gametime);
    }
}
