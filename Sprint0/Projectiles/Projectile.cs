using System;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectile;
using System.Collections.Generic;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Items.Projectiles
{
    public class Projectile : IProjectile

    {
        public List<AnimatedProjectile> projectiles { get; set; }
        ProjectileSpriteFactory projectileFactory;

        public Projectile(ContentManager content)
        {
            projectileFactory = new ProjectileSpriteFactory();

            projectiles = new List<AnimatedProjectile>();

            projectileFactory.LoadTextures(content);
        }

        public void addProjectile(String projectileid, Vector2 position, Boolean facingLeft)
        {
            projectiles.Add(projectileFactory.returnSprite(projectileid, position, facingLeft));
        }

        public void Update(GameTime gametime)
        {
            // checks if projectile is off screen, if so then deletes it
            List<AnimatedProjectile> gone = new List<AnimatedProjectile>();
            foreach (AnimatedProjectile am in projectiles)
            {
                am.Update(gametime);
                if (am.pos.X > 850 || am.pos.X < -50)
                {
                    gone.Add(am);
                }
            }

            foreach (AnimatedProjectile item in gone) projectiles.Remove(item);
            gone.Clear();
        }
    }
}