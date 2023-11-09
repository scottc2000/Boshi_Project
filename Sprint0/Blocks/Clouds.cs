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
        private NonAnimatedBlockSprite sprite;
        private Vector2 location { get; set; }
        public Rectangle destination { get; set; }
        public Clouds(SpriteBatch spriteBatch, ContentManager content, int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            BlockSpriteFactory.Instance.LoadTextures(content);
            BlockSpriteFactory.Instance.LoadSpriteLocations(content);
            sprite = BlockSpriteFactory.Instance.CreateNonAnimatedBlock(spriteBatch, "clouds", new Vector2(x, y));
            destination = sprite.scaledPosition;
        }

        public void Update(GameTime gameTime)
        {
            destination = sprite.scaledPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //do nothing, clouds are part of background
        }
    }
}