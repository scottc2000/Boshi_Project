using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces
{
    public interface IItem : ICollidable, IGameObject
    { 
        void setPosition(List<int> position);
        public bool moveRight { get; set; }
    }
}
