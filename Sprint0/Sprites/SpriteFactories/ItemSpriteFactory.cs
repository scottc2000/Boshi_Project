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
using Sprint0.Sprites.ItemSprites;

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
                System.Diagnostics.Debug.WriteLine("name: " + n.name + "," + spriteName);
                System.Diagnostics.Debug.WriteLine("pos: " + n.spritesheet_pos);
                if (string.Equals(n.name, spriteType))
                    {
                        spriteName = n.name;
                        System.Diagnostics.Debug.WriteLine("spriteName: " + spriteName);
                        currentFrames = generateSprites(n.spritesheet_pos, n.hitbox);
                        //System.Diagnostics.Debug.WriteLine("name: " + spriteName);
                        //spriteName = n.name;
                    }
            }

            return new AniItemSprite(this, item, spriteName, currentFrames);
        }

    }
}