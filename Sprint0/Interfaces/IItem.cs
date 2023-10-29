﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface IItem
    {
        public Rectangle itemRectangle { get; set; }
        void setPosition(List<int> pos);
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
