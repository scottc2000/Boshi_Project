using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.SpriteFactories
{
    // needs a JSON file with HUD sprite data
    public class HUDFactory
    {
        private Texture2D hudSpriteSheet;
        private Sprint0 sprint;

        public HUDFactory(Sprint0 sprint) 
        {
            this.sprint = sprint;
        }

        public void LoadAllTextures(ContentManager content)
        {
            hudSpriteSheet = content.Load<Texture2D>("HUD_transparent1.png");
        }

    }
}
