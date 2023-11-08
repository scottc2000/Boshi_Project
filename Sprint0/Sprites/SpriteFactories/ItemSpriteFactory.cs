using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Items;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Sprint0.Sprites.ItemSprites.itemdata;

namespace Sprint0.Sprites.SpriteFactories
{
    internal class ItemSpriteFactory
    {
        public Texture2D texture;
        private Rectangle[] currentFrames;

        private Root deserializedItemData;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();
        public static ItemSpriteFactory Instance { get { return instance; } }

        public ItemSpriteFactory()
        {
            StreamReader r = new StreamReader("JSON/itemdata.json");
            string itemdatajson = r.ReadToEnd();

            deserializedItemData = JsonSerializer.Deserialize<Root>(itemdatajson);
        }

        public void LoadTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>("NES - Super Mario Bros 3 - Level Items Magic Wands and NPCs");
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
            foreach (Sprite n in deserializedItemData.itemJSON.Sprites)
            {
                if (string.Equals(n.name, spriteType))
                {
                    currentFrames = generateSprites(n.spritesheet_pos, n.hitbox);
                }
            }

            return new AniItemSprite(currentFrames);
        }
    }
}