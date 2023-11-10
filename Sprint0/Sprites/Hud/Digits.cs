using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Utility;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0.Sprites.Hud
{
    public class Digits : ISprite
    {
        private Texture2D texture;
        private HudNumbers numbers;

        private Rectangle[] spriteFrames;
        private Rectangle[] destination;
        private int count;

        public Digits(Texture2D texture, List<Rectangle> frames) 
        { 
            this.texture = texture;
            numbers = new HudNumbers();

            count = frames.Count;
            spriteFrames = new Rectangle[count];
            destination = new Rectangle[count];

            for(int i = frames.Count - 1; i >= 0; i--) 
            {
                spriteFrames[i] = frames[i];
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location) 
        {
            for (int i = spriteFrames.Count() - 1; i >= 0;i--) 
            {
               destination[i] = new Rectangle((int)location.X - (numbers.digitOffset * i), (int)location.Y, spriteFrames[i].Width * 2, spriteFrames[i].Height * 2);
            }

            for (int i = 0; i < spriteFrames.Count(); i++)
            {
                spriteBatch.Draw(texture, destination[i], spriteFrames[i], Color.White);
            }
        }
        public void Update(GameTime gametime) {  /* Nothing needed */ }
    }
}
