using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites.GameStates;

namespace Sprint0.Background
{
    public class Win
    {
        private Texture2D fireWorks;
        private SpriteFont font;
        private Sprint0 sprint0;
        private int timer;
        private ISprite sprite;
        private Vector2 location;
        private FileNames filename;
        private string win;
        private string reset;

        public Win(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
            timer = 150;
            filename = new FileNames();
            fireWorks = sprint0.Content.Load<Texture2D>(filename.fireWorkSheet);
            font = sprint0.Content.Load<SpriteFont>(filename.font);
            location = new Vector2(250, 100);
            sprite = new DrawFireWorks(fireWorks, font, new Rectangle(30, 60, 129, 128));
            win = "Congratulations!";
            reset = "Press 0 to reset";
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
