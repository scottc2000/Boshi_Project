using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Sprites
{
    public class BlockSpriteFactory
    {
        private readonly List<BlockSprites> sprites;

        public BlockSpriteFactory()
        {
            sprites = new List<BlockSprites>();
        }

        public void AddSprite(Texture2D spriteSheet, List<Rectangle> spriteRectangles)
        {
            foreach (var spriteRectangle in spriteRectangles)
            {
                var spriteTexture = new Texture2D(spriteSheet.GraphicsDevice, spriteRectangle.Width, spriteRectangle.Height);
                Color[] data = new Color[spriteRectangle.Width * spriteRectangle.Height];
                spriteSheet.GetData(0, spriteRectangle, data, 0, data.Length);
                spriteTexture.SetData(data);

                var sprite = new BlockSprites(spriteTexture)
                {
                    Position = new Vector2(700, 100)
                };

                sprites.Add(sprite);
            }
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, ContentManager content)
        {
            foreach (var sprite in sprites)
            {
                sprite.Draw(spriteBatch, content);
            }
        }
    }
}
