using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0.Sprites.Hud
{
    public class CoinStats : ISprite
    {
        private Texture2D texture;

        private Rectangle[] spriteFrames;
        private Rectangle[] destination;
        private int count;

        public CoinStats(Texture2D texture, List<Rectangle> frames) 
        { 
            this.texture = texture;
            count = frames.Count;
            spriteFrames = new Rectangle[count];
            destination = new Rectangle[count];

            for(int i = frames.Count - 1; i >= 0; i--) 
            {
                spriteFrames[i] = frames[i];
            }
        }
        public void Update(GameTime gametime) { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location) 
        {
            int offset = 16; // afte testing, move magin number to HudNumbers
            for (int i = spriteFrames.Count() - 1; i >= 0;i--) 
            {
               destination[i] = new Rectangle((int)location.X - (offset * i), (int)location.Y, spriteFrames[i].Width * 2, spriteFrames[i].Height * 2);
            }

            for (int i = 0; i < spriteFrames.Count(); i++)
            {
                spriteBatch.Draw(texture, destination[i], spriteFrames[i], Color.White);
            }
        }
    }
}
