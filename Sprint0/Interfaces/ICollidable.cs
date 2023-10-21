﻿using System;
using Microsoft.Xna.Framework;

namespace Sprint0.Interfaces
{
	public interface ICollidable
	{
		public Rectangle destination {get; set;}

		public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool stuck { get; set; }
    }
}

