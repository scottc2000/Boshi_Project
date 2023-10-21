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
using Sprint0.Items;
using Sprint0.Sprites.ItemSprites;

namespace Sprint0.Sprites.SpriteFactories
{
    internal class ItemSpriteFactory
    {
        private ContentManager content;
        private GameTime gameTime;
        Item item;

        public Dictionary<string, Rectangle> itemAndRectangle;
        public Dictionary<string, Rectangle[]> itemAndFrames;
        string spriteType;
        public Texture2D texture;
        Vector2 position;

        public ItemSpriteFactory(ContentManager content, Item item, GameTime gameTime)
        {
            this.content = content;
            this.gameTime = gameTime;
            this.item = item;
            itemAndRectangle = new Dictionary<string, Rectangle>();
            itemAndFrames = new Dictionary<string, Rectangle[]>();
        }

        public void LoadTextures()
        {
            texture = content.Load<Texture2D>("NES - Super Mario Bros 3 - Level Items Magic Wands and NPCs");
        }

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
    }
}