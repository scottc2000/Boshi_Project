using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Sprint0.Interfaces;
using Sprint0.Sprites.Hud;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sprint0.Sprites.SpriteFactories
{
    // needs a JSON file with HUD sprite data
    public class HUDFactory
    {
        private Texture2D hudSpriteSheet;
        private Sprint0 sprint;
        private List<Root> deserializedGameData;

        public class Root
        {
            public string name { get; set; }
            public List<int> spritesheetpos { get; set; }
            public List<int> size { get; set; }
            public int? number { get; set; }
        }
        public HUDFactory(Sprint0 sprint) 
        {
            this.sprint = sprint;

            StreamReader r = new StreamReader("JSON/HUDdata.json");
            string data = r.ReadToEnd();

            deserializedGameData = JsonConvert.DeserializeObject<List<Root>>(data);
        }

        public void LoadAllTextures(ContentManager content)
        {
            hudSpriteSheet = content.Load<Texture2D>("HUD_transparent1");
        }

        /*---------------------------- Create Hud Background -------------------------------*/
        public ISprite CreateHud(string name)
        {
            Root element = deserializedGameData.FirstOrDefault(item =>  item.name == name);
            return new StaticHUD(hudSpriteSheet, new Vector2(element.spritesheetpos[0], element.spritesheetpos[1]), new Vector2(element.size[0], element.size[1]));
        }

        /*--------------------------- Update Coin Sprites ------------------------------------*/
        public ISprite UpdateCoins(int coins)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            // check for 0 coins
            if (coins == 0)
            {
                Root element = deserializedGameData.FirstOrDefault(item => item.number == coins);
                rectangles.Add(new Rectangle(element.spritesheetpos[0], element.spritesheetpos[1], element.size[0], element.size[1]));
            }

            // draw each digit sprite for coins 1 - 99
            while (coins > 0)
            {
                int digit = coins % 10;
                coins = coins / 10;
                Root element = deserializedGameData.FirstOrDefault(item => item.number == digit);
                rectangles.Add(new Rectangle(element.spritesheetpos[0], element.spritesheetpos[1], element.size[0], element.size[1]));
            }
           
            return new CoinStats(hudSpriteSheet, rectangles);
        }

        /*--------------------------- Update Life Sprites ------------------------------------*/
        public ISprite UpdateLives(int lives)
        {
            Root matchingElement = deserializedGameData.FirstOrDefault(item => item.number == lives);
            return new LifeStats(hudSpriteSheet, new Vector2(matchingElement.spritesheetpos[0], matchingElement.spritesheetpos[1]), new Vector2(matchingElement.size[0], matchingElement.size[1]));
        }
    }
}
