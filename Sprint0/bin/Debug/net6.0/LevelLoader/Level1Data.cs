using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.LevelLoader
{
    public class Level1Data
    {
        public class Block
        {
            public string Name { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string item { get; set; }
        }

        public class Item
        {
            public string Name { get; set; }
            public List<int> Hitbox { get; set; }
            public List<int> Position { get; set; }
        }

        public class Enemy
        {
            public string Name { get; set; }
            public List<int> Hitbox { get; set; }
            public List<int> Position { get; set; }
        }

        public class Music
        {
            public string Name { get; set; }
        }

        public class Root
        {
            public List<Block> Blocks { get; set; }
            public List<Item> Items { get; set; }
            public List<Enemy> Enemies { get; set; }
            public List<Music> Songs { get; set; }
        }
    }
}
