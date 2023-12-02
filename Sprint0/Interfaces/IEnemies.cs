using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Sprint0.Interfaces
{
    public interface IEnemies : ICollidable, IGameObject
    {
        public void SetPosition(List<int> position);
        public Rectangle Destination { get; set; }
        public void ChangeDirection();

        public void BeStomped();

        public void BeFlipped();

        public void StartSwarm();

        public void Move();

    }
}
