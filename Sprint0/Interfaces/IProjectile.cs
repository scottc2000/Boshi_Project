using Sprint0.Sprites.Projectile;
using System.Collections.Generic;

namespace Sprint0.Interfaces
{
    public interface IProjectile : ICollidable, IGameObject
    {
        List<AnimatedProjectile> projectiles { get; set; }
    }
}