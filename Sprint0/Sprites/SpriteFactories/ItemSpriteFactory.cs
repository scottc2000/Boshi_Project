using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Items;
using static Sprint0.Sprites.ItemData;
using Sprint0.Items.ItemClasses;
using System.IO;
using System.Text.Json;

namespace Sprint0.Sprites.SpriteFactories
{
    public class ItemSpriteFactory
    {
        Item item;

        public Dictionary<string, Rectangle> itemAndRectangle;
        public Dictionary<string, Rectangle[]> itemAndFrames;
        string spriteType;
        string spriteName;
        public Texture2D texture;
        private Rectangle[] currentFrames;

        //private JsonElement itemData;
        private Root deserializedItemData;

        AniItemSprite generatedItem;

        public ItemSpriteFactory(Item item)
        {
            this.item = item;
            itemAndRectangle = new Dictionary<string, Rectangle>();
            itemAndFrames = new Dictionary<string, Rectangle[]>();

            StreamReader r = new StreamReader("itemdata.json");
            string itemdatajson = r.ReadToEnd();

            deserializedItemData = JsonSerializer.Deserialize<Root>(itemdatajson);
            spriteName = "";
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
                        spriteName = n.name;
                        currentFrames = generateSprites(n.spritesheet_pos, n.hitbox);
                    }
            }

            return new AniItemSprite(this, item, spriteName, currentFrames);
        }

    }
}