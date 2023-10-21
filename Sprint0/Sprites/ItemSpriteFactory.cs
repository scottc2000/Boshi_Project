using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Sprint0.Sprites.ItemData;

namespace Sprint0.Sprites
{
    public class ItemSpriteFactory
    {
        Item item;

        public Dictionary<String, Rectangle> itemAndRectangle;
        public Dictionary<String, Rectangle[]> itemAndFrames;
        String spriteType;
        public Texture2D texture;

        //private JsonElement itemData;
        private Root deserializedItemData;

        AniItemSprite generatedItem;

        public ItemSpriteFactory(Item item)
        {
            this.item = item;
            itemAndRectangle = new Dictionary<String, Rectangle>();
            itemAndFrames = new Dictionary<String, Rectangle[]>();

            StreamReader r = new StreamReader("itemdata.json");
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
            string spriteName = "X";

            foreach (Sprite n in deserializedItemData.itemJSON.Sprites)
            {
                System.Diagnostics.Debug.WriteLine("pos: " + n.spritesheet_pos);
                if (string.Equals(n.name, spriteType))
                    {
                        generatedItem.spriteFrames = generateSprites(n.spritesheet_pos, n.hitbox);
                    System.Diagnostics.Debug.WriteLine("name: " + n.name);
                        spriteName = n.name;
                    }
            }

            return new AniItemSprite(this, item, spriteName);
        }

        /*
        public void RegisterSprite()
        {
            //Non-Animated Sprites
            itemAndRectangle.Add("RedMushroom", new Rectangle(1, 24, 16, 16));
            itemAndRectangle.Add("OneUpMushroom", new Rectangle(19, 24, 16, 16));
            itemAndRectangle.Add("FireFlower", new Rectangle(37, 24, 16, 16));
            itemAndRectangle.Add("Leaf", new Rectangle(55, 24, 16, 16));
            itemAndRectangle.Add("Frog", new Rectangle(1, 42, 16, 16));
            itemAndRectangle.Add("Tanooki", new Rectangle(19, 42, 16, 16));
            itemAndRectangle.Add("Hammer", new Rectangle(37, 42, 16, 16));

            //Animated Sprites
            itemAndFrames.Add("Star", new Rectangle[] { new Rectangle(73, 24, 16, 16), new Rectangle(90, 24, 16, 16), new Rectangle(107, 24, 16, 16), new Rectangle(124, 24, 16, 16) });
            itemAndFrames.Add("Shoe", new Rectangle[] { new Rectangle(55, 42, 16, 16), new Rectangle(72, 42, 16, 16) });
        }

        public ISprite createRedMushroom()
        {
            return new NonAniItemSprite(this, item, "RedMushroom");
        }

        public ISprite createOneUpMushroom()
        {
            return new NonAniItemSprite(this, item, "OneUpMushroom");
        }

        public ISprite createFireFlower()
        {
            return new NonAniItemSprite(this, item, "FireFlower");
        }

        public ISprite createLeaf()
        {
            return new NonAniItemSprite(this, item, "Leaf");
        }

        public ISprite createFrog()
        {
            return new NonAniItemSprite(this, item, "Frog");
        }

        public ISprite createTanooki()
        {
            return new NonAniItemSprite(this, item, "Tanooki");
        }

        public ISprite createHammer()
        {
            return new NonAniItemSprite(this, item, "Hammer");
        }

        public ISprite createStar()
        {
            return new AniItemSprite(this, item, "Star");
        }

        public ISprite createShoe()
        {
            return new AniItemSprite(this, item, "Shoe");
        }
        */
    }
}