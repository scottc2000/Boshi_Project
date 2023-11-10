using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision
{
    public class CollisionData
    {
        public Rectangle collisionRectangle;
        public CollisionDictionraryRegister.Side side;
        public CollisionData(Rectangle collisionRectangle, CollisionDictionraryRegister.Side side)
        {
            this.collisionRectangle = collisionRectangle;
            this.side = side;
        }
    }
}
