using System;
using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces
{
	public interface ICollidable
	{
        // destination rectangle which contains x, y , hitbox width (x) and height (y)
		public Rectangle destination {get; set;}

        //item will probably have to be split up
        public enum collideAs { player, item, block, enemy }

        //dont need these, dont know how to refactor to get rid of them
		public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }
    }
}

