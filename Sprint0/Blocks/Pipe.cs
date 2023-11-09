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
    internal class Pipe : IBlock, IEntity
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        private ISprite sprite;
        private Vector2 location { get; set; }
        public Rectangle destination { get; set; }
        public Pipe(SpriteBatch spriteBatch, Rectangle blockRectangle)
        {
            destination = blockRectangle;
            sprite = BlockSpriteFactory.Instance.CreateNonAnimatedBlock(spriteBatch, "pipe", new Vector2(blockRectangle.X, blockRectangle.Y));
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //do nothing, pipes are part of background
        }
    }
}