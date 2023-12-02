using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Sprint0.Sprites.EnemySprites.EnemyData;

namespace Sprint0.Sprites.SpriteFactories
{
    public class EnemySpriteFactoryBowser
    {
        private Enemies.Bowser bowser;
        private Rectangle[] currentFrames;

        private Texture2D texture;
        private SpriteEffects effect;
        private Root deserializedEnemyData;
        private FileNames filename;

        public EnemySpriteFactoryBowser(Enemies.Bowser bowser)
        {
            this.bowser = bowser;
            filename = new FileNames();

            // opens file that contains sprite information and deserializes it
            StreamReader r = new StreamReader(filename.enemyData);
            string enemydatajson = r.ReadToEnd();

            deserializedEnemyData = JsonSerializer.Deserialize<Root>(enemydatajson);
        }
        public void LoadTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>(filename.bossSheet);
        }
        public Rectangle[] generateSprites(List<List<int>> sheetpos, List<int> hitbox)
        {
            // genereates list of sprite rectangles from the json locations
            Rectangle[] myRect = new Rectangle[sheetpos.Count];

            for (int i = 0; i < sheetpos.Count; i++)
            {
                myRect[i] = new Rectangle(sheetpos[i][0], sheetpos[i][1], hitbox[0], hitbox[1]);

            }
            return myRect;
        }


        public AnimatedSpriteBowser returnSprite(string spriteType)
        {
            string spriteName = "X";

            foreach (Sprite sprite in deserializedEnemyData.bowser.Sprites)
            {
                if (string.Equals(sprite.name, spriteType))
                {
                    currentFrames = generateSprites(sprite.spritesheet_pos, sprite.hitbox);
                    spriteName = sprite.name;
                }
            }

            return new AnimatedSpriteBowser(currentFrames, texture, effect, spriteName);
        }
    }
}
