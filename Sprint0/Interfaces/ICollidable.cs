using System;
using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces
{
	public interface ICollidable
	{
        // destination rectangle which contains x, y , hitbox width (x) and height (y)
		public Rectangle Destination {get; set;}
		public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }
    }
}

