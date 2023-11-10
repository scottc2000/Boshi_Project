using System;
using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces
{
	public interface ICollidable : IEntity
	{
        //item will probably have to be split up
        public enum collideAs { player, item, block, enemy }

    }
}

