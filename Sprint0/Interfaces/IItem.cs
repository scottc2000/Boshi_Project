using System.Collections.Generic;

namespace Sprint0.Interfaces
{
    public interface IItem : ICollidable, IGameObject
    { 
        void setPosition(List<int> position);
    }
}
