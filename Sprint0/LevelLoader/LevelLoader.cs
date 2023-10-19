using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Text.Json;
using Sprint0.Characters;

namespace Sprint0
{

    public class LevelLoader
    {
        private Mario mario;
        private Texture2D background;
        private Sprint0 sprint0;


        public LevelLoader(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Load()
        {
            LoadCharacters();
            LoadBackground();
            LoadEnemies();
        }

        public void LoadCharacters()
        {
            /*
            string marioFile = "Mario.json";
            string marioString = File.ReadAllText(marioFile);
            mario = JsonSerializer.Deserialize<Mario>(marioString)!;
            */
        }

        public void LoadBackground()
        {
            // Fix later, can't access spriteBatch might need its own object class
         //  background = sprint0.Content.Load<Texture2D>("Level 1-1 Background.png");
          //  Rectangle initialCamPos = new Rectangle(0, 0, 432, 632);
           // sprint0._spriteBatch.Draw(background, initialCamPos, Color.White);
        }

        public void LoadEnemies()
        {

        }

        public void LoadBlocks()
        {

        }
    }
}
