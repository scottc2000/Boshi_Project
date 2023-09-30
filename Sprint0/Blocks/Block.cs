using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Blocks
{
    public class Block: IBlock
    {
        private Sprint0 game;
        private ISprite sprite;
        
        public Vector2 Location { get; set; }
        

        public Block(Sprint0 game, ISprite sprite)
        {
            this.game = game;
            this.sprite = sprite;
            
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, ContentManager content)
        {
            
        }
    }
}
