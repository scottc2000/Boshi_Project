using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Projectile;
using Sprint0.Utility;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Sprint0.Sprites.Projectile.ProjectileData;

namespace Sprint0.Sprites.SpriteFactories
{
    public class ProjectileSpriteFactory
    {
        private ProjRoot deserializedData;
        private Texture2D texture;

        AnimatedProjectile returnedSprite;
        Rectangle[] sprites;
        private FileNames filenames;

        public ProjectileSpriteFactory()
        {
            filenames = new FileNames();
            StreamReader r = new StreamReader(filenames.projectileData);
            string projdatajson = r.ReadToEnd();

            deserializedData = JsonSerializer.Deserialize<ProjRoot>(projdatajson);
        }

        public void LoadTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>(filenames.enemySheet);

        }

        public Rectangle[] generateSprites(List<List<int>> sheetpos, List<int> hitbox)
        {
            Rectangle[] myRect = new Rectangle[sheetpos.Count];

            for (int i = 0; i < sheetpos.Count; i++)
            {
                myRect[i] = new Rectangle(sheetpos[i][0], sheetpos[i][1], hitbox[0], hitbox[1]);

            }
            return myRect;
        }

        public AnimatedProjectile returnSprite(string spriteType, Vector2 spawnpos, bool facingLeft)
        {


            foreach (Projectilesprite s in deserializedData.projectilesprites)
            {
                if (string.Equals(spriteType, s.name))
                {
                    sprites = generateSprites(s.spritesheet_pos, s.hitbox);
                    returnedSprite = new AnimatedProjectile(sprites, texture, facingLeft, spawnpos);
                    break;
                }
            }

            return returnedSprite;
        }
    }
}

