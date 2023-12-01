using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Sprint0.Interfaces;
using Sprint0.Sprites.Hud;
using Sprint0.Utility;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sprint0.Sprites.SpriteFactories
{
    // needs a JSON file with HUD sprite data
    public class HUDFactory
    {
        private Texture2D hudSpriteSheet;
        private Sprint0 sprint;
        private List<Root> deserializedGameData;
        private FileNames filenames;

        public class Root
        {
            public string name { get; set; }
            public List<int> spritesheetpos { get; set; }
            public List<int> size { get; set; }
            public int? number { get; set; }
        }
        public HUDFactory(Sprint0 sprint) 
        {
            filenames = new FileNames();
            this.sprint = sprint;

            StreamReader r = new StreamReader(filenames.hudData);
            string data = r.ReadToEnd();

            deserializedGameData = JsonConvert.DeserializeObject<List<Root>>(data);
        }

        public void LoadAllTextures(ContentManager content)
        {
            hudSpriteSheet = content.Load<Texture2D>(filenames.hudSheet);
        }

        /*---------------------------- Create Hud Background -------------------------------*/
        public ISprite CreateHud(string name)
        {
            Root element = deserializedGameData.FirstOrDefault(item =>  item.name == name);
            return new StaticHUD(hudSpriteSheet, new Vector2(element.spritesheetpos[0], element.spritesheetpos[1]), new Vector2(element.size[0], element.size[1]));
        }

        /*--------------------------- Update Digit Sprites ------------------------------------*/
        public ISprite UpdateDigits(int value)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            // check for 0
            if (value == 0)
            {
                Root element = deserializedGameData.FirstOrDefault(item => item.number == value);
                rectangles.Add(new Rectangle(element.spritesheetpos[0], element.spritesheetpos[1], element.size[0], element.size[1]));
            }

            // draw each digit sprite
            while (value > 0)
            {
                int digit = value % 10;
                value = value / 10;
                Root element = deserializedGameData.FirstOrDefault(item => item.number == digit);
                rectangles.Add(new Rectangle(element.spritesheetpos[0], element.spritesheetpos[1], element.size[0], element.size[1]));
            }
            System.Diagnostics.Debug.WriteLine("hudSpriteSheet: " + hudSpriteSheet);
            return new Digits(hudSpriteSheet, rectangles);
        }

        /*___________________________ Accessories ____________________________________________*/
        public ISprite Letter(string name)
        {
            Root element = deserializedGameData.FirstOrDefault(item => item.name == name);
            return new Letter(hudSpriteSheet, new Vector2(element.spritesheetpos[0], element.spritesheetpos[1]), new Vector2(element.size[0], element.size[1]));
        }
        public ISprite World()
        {
            return new World(hudSpriteSheet, new Vector2(deserializedGameData[1].spritesheetpos[0], deserializedGameData[1].spritesheetpos[1]), new Vector2(deserializedGameData[1].size[0], deserializedGameData[1].size[1]));
        }
        public ISprite Cards(string name)
        {
            Root element = deserializedGameData.FirstOrDefault(item => item.name == name);
            return new Cards(hudSpriteSheet, new Vector2(element.spritesheetpos[0], element.spritesheetpos[1]), new Vector2(element.size[0], element.size[1]));
        }
    }
}
