using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Emit;

namespace Sprint0.Sprites
{
    internal class BlockSprites : ISprite
    {
        private Sprint0 game;
        private Texture2D _block;
        
        private readonly int _columns = 74;
        private readonly int _rows = 21;
        private Rectangle[] blockSprite;

        private Vector2 position;
        private Rectangle destination;
        private float rotation = 0, layer = 0;
        SpriteEffects effect = SpriteEffects.None;

        //private static Texture2D[,] blockLocations = new Texture2D[_columns, _rows];

        //public static Texture2D[,] BlockLocations { get => blockLocations; set => blockLocations = value; }

        //public static void GetBlocks()
        //{
        //    _blocks = Content.Load<Texture2D>("SpriteImages/blocks");
        //    Rectangle sourceRect;
        //    Color[] colors = new Color[32 * 32];

        //    for(int i = 0; i < _columns; i++)
        //    {
        //        for(int j = 0; j < _rows; j++)
        //        {

        //        }
        //    }
        //}

        public BlockSprites() 
        {
            
            blockSprite = new Rectangle[] { new Rectangle(2076, 2, 32, 32) };
            position.X = 600;
            position.Y = 240;
            
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content) 
        {
            _block = Content.Load<Texture2D>("SpriteImages/blocks");

            destination = new Rectangle((int)position.X, (int)position.Y, 32, 32);

            spriteBatch.Draw(_block, destination, blockSprite[0], Color.White, rotation, new Vector2(0, 0), effect, layer);
        }
    }
}
