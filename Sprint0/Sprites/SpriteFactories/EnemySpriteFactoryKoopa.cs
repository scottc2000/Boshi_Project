using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.goombaSprite;
using Sprint0.Sprites.Players;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Sprint0.Sprites.EnemySprites.EnemyData;

namespace Sprint0.Sprites.SpriteFactories
{
    public class EnemySpriteFactoryKoopa
    {
        private Enemies.Koopa koopa;
        private Rectangle[] currentFrames;

        private Texture2D texture;
        private JsonElement enemyData;
        private Root deserializedEnemyData;

        GoombaMoveSprite generatedEnemy;

        public EnemySpriteFactoryKoopa(Enemies.Koopa koopa)
        {
            this.koopa = koopa;

            // opens file that contains sprite information and deserializes it
            StreamReader r = new StreamReader("JSON/enemydata.json");
            string enemydatajson = r.ReadToEnd();

            deserializedEnemyData = JsonSerializer.Deserialize<Root>(enemydatajson);


        }
        public void LoadTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>("marioenemy");

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

        public KoopaMoveSprite returnSprite(string spriteType)
        {

            string spriteName = "X";

            Sprite sprite = deserializedEnemyData.koopa.Sprites;
            if (string.Equals(sprite.name, spriteType))
            {
                currentFrames = generateSprites(sprite.spritesheet_pos, sprite.hitbox);
                spriteName = sprite.name;
            }


            return new KoopaMoveSprite(currentFrames, texture, koopa);
        }
    }

}
