﻿using System;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectile;
using System.Collections.Generic;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Utility;

namespace Sprint0.Items.Projectiles
{
    public class FireProjectile : IProjectile

    {
        public List<AnimatedProjectile> projectiles { get; set; }
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames fileNames = new FileNames();

        ProjectileSpriteFactory projectileFactory;

        public FireProjectile(ContentManager content)
        {
            projectileFactory = new ProjectileSpriteFactory();

            projectiles = new List<AnimatedProjectile>();

            projectileFactory.LoadTextures(content);
        }

        public void addProjectile(String projectileid, Vector2 position, Boolean facingLeft)
        {
            audioManager.PlaySFX(fileNames.fireballSFX);
            projectiles.Add(projectileFactory.returnSprite("PlayerFireRight", position, facingLeft));
        }

        public void Update(GameTime gametime)
        {
            // checks if projectile is off screen, if so then deletes it
            List<AnimatedProjectile> gone = new List<AnimatedProjectile>();
            foreach (AnimatedProjectile am in projectiles)
            {
                am.Update(gametime);
                if (am.travel > 250 || am.travel < -250)
                {
                    gone.Add(am);
                }
            }

            foreach (AnimatedProjectile item in gone) projectiles.Remove(item);
            gone.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (AnimatedProjectile p in projectiles)
            {
                p.Draw(spriteBatch);
                
            }
        }
    }
}