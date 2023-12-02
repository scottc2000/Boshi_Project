using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces
{
    public interface IEnemyBowserState
    {
        public void Move();

        public void Jump();
        public void Fall();
        public void Look();
        public void Die();
        public void Fireball();
        public void Update(GameTime gametime);
    }
}
