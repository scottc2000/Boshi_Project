using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Blocks
{
    internal class WoodBlocks : IBlock
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        private ISprite sprite;
        private Vector2 location { get; set; }
        public Rectangle Destination { get; set; }
        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }

        public WoodBlocks(SpriteBatch spriteBatch, Rectangle blockRectangle)
        {
            Destination = blockRectangle;
            sprite = BlockSpriteFactory.Instance.CreateAnimatedBlock(spriteBatch, "spinning_coin", new Vector2(blockRectangle.X, blockRectangle.Y));
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //do nothing, wood blocks are part of background
        }
    }
}