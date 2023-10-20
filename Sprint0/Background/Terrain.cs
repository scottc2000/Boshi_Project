using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System.Data;

namespace Sprint0.Background 
{
    public class Terrain
    {
        private Texture2D terrain;
        private Sprint0 sprint0;
        private ISprite sprite;
        private Vector2 location;

        public Terrain(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
            terrain = sprint0.Content.Load<Texture2D>("level1_1");
            sprite = new DrawBackground(terrain, new Rectangle(0, 0, 4000, 700));

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