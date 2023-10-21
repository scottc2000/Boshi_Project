using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Blocks
{
    internal class WoodBlocks : IBlock
    {
        public WoodBlocks(int x, int y, int width, int height) 
        {
            
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
