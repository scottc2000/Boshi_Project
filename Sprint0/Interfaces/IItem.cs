using System.Collections.Generic;

namespace Sprint0.Interfaces
{
    public interface IItem : ICollidable
    { 
        void setPosition(List<int> position);
        public bool moveRight { get; set; }
    }
}
