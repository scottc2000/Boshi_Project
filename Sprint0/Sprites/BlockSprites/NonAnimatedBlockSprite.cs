using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;

namespace Sprint0.Sprites.BlockSprites
{
    internal class NonAnimatedBlockSprite : ISprite
    {
        private Texture2D textures;
        private Vector2 position;
        private Rectangle sprite;
        public NonAnimatedBlockSprite(SpriteBatch spriteBatch, Texture2D textures, Rectangle sprite, Vector2 position)
        {
            this.textures = textures;
            this.position = position;
            this.sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(textures, position, sprite, Color.White);
        }
    }
}
