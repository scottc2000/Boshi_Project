using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites
{
    internal class BlockSprites
    {
        private readonly Texture2D _blocks;
        private readonly int _columns = 74;
        private readonly int _rows = 21;

        public static Texture2D[,] blockLocations = new Texture2D[_columns, _rows];

        public static void GetBlocks()
        {
            _blocks = Content.Load<Texture2D>("SpriteImages/blocks");
            Rectangle sourceRect;
            Color[] colors = new Color[32 * 32];

            for(int i = 0; i < _columns; i++)
            {
                for(int j = 0; j < _rows; j++)
                {

                }
            }
        }

        public BlockSprites() 
        { 
            
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            
        }
    }
}
