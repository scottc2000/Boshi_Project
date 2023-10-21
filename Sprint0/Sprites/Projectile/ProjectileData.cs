using System;
using System.Collections.Generic;

namespace Sprint0.Sprites.Projectile
{
    public class ProjectileData
    {
        public class Projectilesprite
        {
            public string name { get; set; }
            public List<List<int>> spritesheet_pos { get; set; }
            public List<int> hitbox { get; set; }
            public bool facingLeft { get; set; }
        }

        public class ProjRoot
        {
            public List<Projectilesprite> projectilesprites { get; set; }
        }
    }
}

