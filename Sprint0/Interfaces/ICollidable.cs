using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
	public interface ICollidable
	{
        // destination rectangle which contains x, y , hitbox width (x) and height (y)
		public Rectangle Destination {get; set;}
    }
}

