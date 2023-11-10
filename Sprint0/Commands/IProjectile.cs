using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectile;

namespace Sprint0.Interfaces
{
    public interface IProjectile
    {
        List<AnimatedProjectile> projectiles { get; set; }

        public void Update(GameTime gametime);
    }
}