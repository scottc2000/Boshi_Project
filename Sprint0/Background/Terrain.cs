using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.GameStates;
using Sprint0.Utility;
using System.Data;

namespace Sprint0.Background 
{
    public class Terrain : IGameObject
    {
        private Texture2D terrain;
        private Sprint0 sprint0;
        private ISprite sprite;
        private Vector2 location;
        private FileNames filename;

        public Terrain(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
            filename = new FileNames();
            terrain = sprint0.Content.Load<Texture2D>(filename.terrainSheet);
            sprite = new DrawBackground(terrain, new Rectangle(0, 0, 3163, 626));
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