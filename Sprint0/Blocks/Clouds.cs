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
using Sprint0.Sprites.BlockSprites;

namespace Sprint0.Blocks
{
    internal class Clouds : IBlock, IEntity
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        private ISprite sprite;
        public Rectangle destination { get; set; }
        public Clouds(SpriteBatch spriteBatch, Rectangle blockRectangle)
        {
            destination = blockRectangle;
            sprite = BlockSpriteFactory.Instance.CreateNonAnimatedBlock(spriteBatch, "clouds", new Vector2(blockRectangle.X, blockRectangle.Y));
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //do nothing, clouds are part of background
        }
    }
}