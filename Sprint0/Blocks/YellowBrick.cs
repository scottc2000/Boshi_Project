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
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.Blocks
{
    internal class YellowBrick : IBlock, IEntity
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        private ISprite sprite;
        private Vector2 location;
        public Rectangle destination { get; set; }

        public YellowBrick(SpriteBatch spriteBatch, Rectangle blockRectangle)
        {
            destination = blockRectangle;
            sprite = BlockSpriteFactory.Instance.CreateNonAnimatedBlock(spriteBatch, "yellow_brick", new Vector2(blockRectangle.X, blockRectangle.Y));
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);

        }
    }
}