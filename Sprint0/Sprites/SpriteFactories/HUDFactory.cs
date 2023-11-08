using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Sprint0.Interfaces;
using Sprint0.Sprites.Hud;
using System.Collections.Generic;
using System.IO;

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
            return new StaticHUD(sprint, hudSpriteSheet, new Vector2(deserializedGameData[0].spritesheetpos[0], deserializedGameData[0].spritesheetpos[1]), new Vector2(deserializedGameData[0].size[0], deserializedGameData[0].size[1]));
        }
        public ISprite UpdateCoins(int coins)
        {
            //deserializedGameData.number = coins;
            return null;
            //return new CoinSprite(hudSpriteSheet, new Vector2(deserializedGameData.spritesheetpos[0], deserializedGameData.spritesheetpos[1]), new Vector2(deserializedGameData.size[0], deserializedGameData.size[1]));
        }
    }
}
