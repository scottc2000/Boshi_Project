using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Projectile;

namespace Sprint0.Interfaces
{
    public interface IProjectile : ICollidable
    {
        List<AnimatedProjectile> projectiles { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}