using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.Blocks
{
    internal class YellowBrick : IBlock
    {
        private ISprite sprite;

        public YellowBrick(SpriteBatch spriteBatch, int x, int y, int width, int height) 
        {
            
            sprite = BlockSpriteFactory.Instance.CreateNonAnimatedBlock(spriteBatch, "yellow_brick", new Vector2(x,y));
        }

        public void Update(GameTime gameTime) 
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
