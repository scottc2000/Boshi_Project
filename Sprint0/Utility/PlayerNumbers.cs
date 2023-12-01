using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Utility
{
    public class PlayerNumbers
    {
        public Vector2 velocity { get; } = new Vector2(0, 0);
        public int sizeDiff { get; } = 25;
        public int reverse { get; } = -1;
        public Vector2 marioOGPosition { get; } = new Vector2(180, 200);
        public float sixth { get; } = (1.0f / 60.0f);
    }
}
