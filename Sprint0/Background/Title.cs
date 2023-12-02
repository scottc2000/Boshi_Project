using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Utility;
using System.Data;

namespace Sprint0.Background 
{
    public class Title : IGameObject
    {
        private Texture2D title;
        private Sprint0 sprint0;
        private ISprite sprite;
        private Vector2 location;
        private FileNames filename;

        public Title(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
            filename = new FileNames();
            title = sprint0.Content.Load<Texture2D>(filename.titleSheet);
            sprite = new DrawBackground(title, new Rectangle(0, 0, 800, 500));
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