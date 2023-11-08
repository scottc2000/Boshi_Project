using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using MonoGame.Extended.Screens;
using System.Data;

namespace Sprint0.Background 
{
    public class DeathScreen : IScreen
    {
        private ScreenManager screenManager;
        private Texture2D terrain;
        private Sprint0 sprint0;
        private ISprite sprite;
        private Vector2 location;
        private string file;

        public DeathScreen(Sprint0 sprint0, ScreenManager screenManager)
        {
            this.screenManager = screenManager;
            this.sprint0 = sprint0;
            terrain = sprint0.Content.Load<Texture2D>("level1_1");
            sprite = new DrawBackground(terrain, new Rectangle(0, 0, 2816, 626));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Death()
        {
            //Already on Death Screen
        }

        public void Home()
        {
            screenManager.state = new HomeScreen(sprint0, screenManager);
        }

        public void Level1()
        {
            screenManager.state = new Level1Screen(sprint0, screenManager);
        }
    }
}   