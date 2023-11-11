using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Interfaces
{
	public interface ICollidableCommand
	{
		public void Execute(Rectangle hitbox);
	}
}

