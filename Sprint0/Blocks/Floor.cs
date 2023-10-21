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
    internal class Floor : IBlock
    {
        private ISprite sprite;
        private Vector2 location { get; set; }
        public Floor(SpriteBatch spriteBatch, ContentManager content, int x, int y, int width, int height)
        {
            BlockSpriteFactory.Instance.LoadTextures(content);
            BlockSpriteFactory.Instance.LoadSpriteLocations(content);
            sprite = BlockSpriteFactory.Instance.CreateNonAnimatedBlock(spriteBatch, "floor", new Vector2(x, y));
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //do nothing, floor is part of background
        }
    }
}