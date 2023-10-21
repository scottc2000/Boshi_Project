using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.EnemySprites
{
    public class EnemyData
    {
        public class Goomba
        {
            public Sprite Sprites { get; set; }
        }

        public class HammerBro
        {
            public Sprite Sprites { get; set; }
        }

        public class Koopa
        {
            public Sprite Sprites { get; set; }
        }

        public class Root
        {
            public Goomba goomba { get; set; }
            public Koopa koopa { get; set; }
            public HammerBro hammerBro { get; set; }
        }

        public class Sprite
        {
            public string name { get; set; }
            public List<List<int>> spritesheet_pos { get; set; }
            public List<int> hitbox { get; set; }
            public bool facingLeft { get; set; }
        }
    }
}
