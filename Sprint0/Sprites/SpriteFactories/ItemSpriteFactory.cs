using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Sprint0.Sprites.ItemSprites.itemdata;
using System.Text.Json;
using Sprint0.Sprites.ItemSprites;
using Sprint0.Utility;

namespace Sprint0.Sprites.SpriteFactories
{
    internal class ItemSpriteFactory
    {
        public Texture2D texture;
        private Rectangle[] currentFrames;

        private Root deserializedItemData;
        private FileNames filenames;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();
        public static ItemSpriteFactory Instance { get { return instance; } }

        public ItemSpriteFactory()
        {
            filenames = new FileNames();
            StreamReader r = new StreamReader(filenames.itemData);
            string itemdatajson = r.ReadToEnd();

            deserializedItemData = JsonSerializer.Deserialize<Root>(itemdatajson);
        }

        public void LoadTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>(filenames.itemSheet);
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

        public AniItemSprite returnSprite(string spriteType)
        {
            string spriteName = "";

            foreach (Sprite n in deserializedItemData.itemJSON.Sprites)
            {
                if (string.Equals(n.name, spriteType))
                {
                    spriteName = n.name;
                    currentFrames = generateSprites(n.spritesheet_pos, n.hitbox);
                }
            }

            return new AniItemSprite(currentFrames);
        }
    }
}