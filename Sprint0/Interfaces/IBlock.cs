using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface IBlock
    {
        public int x {  get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public enum Spawnable { none, redmushroom, greenmushroom, fireflower, leaf, star, tanooki, frog, hammer, shoe, coin }
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
