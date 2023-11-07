using System;
using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces
{
	public interface ICollidableCommand
	{
		public void Execute(Rectangle hitbox);
	}
}

