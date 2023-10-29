using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.ItemSprites
{
    internal class itemdata
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class ItemJSON
        {
            public List<Sprite> Sprites { get; set; }
        }

        public class Root
        {
            public ItemJSON itemJSON { get; set; }
        }

        public class Sprite
        {
            public string name { get; set; }
            public List<List<int>> spritesheet_pos { get; set; }
            public List<int> hitbox { get; set; }
            public bool moveRight { get; set; }
        }
    }
}
