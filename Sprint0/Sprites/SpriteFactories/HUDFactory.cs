using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Sprint0.Interfaces;
using Sprint0.Sprites.Hud;
using System.Collections.Generic;
using System.Drawing;
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

        public ISprite CreateHud(string name)
        {
            return new StaticHUD(hudSpriteSheet, new Vector2(deserializedGameData[0].spritesheetpos[0], deserializedGameData[0].spritesheetpos[1]), new Vector2(deserializedGameData[0].size[0], deserializedGameData[0].size[1]));
        }
        public ISprite UpdateCoins(int coins)
        {
            // Find the element with the matching 'number' property
            Root matchingElement = deserializedGameData.FirstOrDefault(item => item.number == coins);
            return new CoinStats(hudSpriteSheet, new Vector2(matchingElement.spritesheetpos[0], matchingElement.spritesheetpos[1]), new Vector2(matchingElement.size[0], matchingElement.size[1]));
        }
        public ISprite UpdateLives(int lives)
        {
            Root matchingElement = deserializedGameData.FirstOrDefault(item => item.number == lives);
            return new LifeStats(hudSpriteSheet, new Vector2(matchingElement.spritesheetpos[0], matchingElement.spritesheetpos[1]), new Vector2(matchingElement.size[0], matchingElement.size[1]));
        }
    }
}
