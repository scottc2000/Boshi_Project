using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.Collisions
{
    internal class CItemBlockY : ICommand
    {
        private IItem item;
        private Rectangle hitbox;
        public CItemBlockY(IItem item, Rectangle hitbox)
        {
            this.item = item;
            this.hitbox = hitbox;
        }

        public void Execute()
        {
            Rectangle hitarea = Rectangle.Intersect(hitbox, item.Destination);
            if (hitarea.Width >= hitarea.Height)
            {
                if (hitbox.Y <= item.Destination.Y)
                {
                    item.Destination = new Rectangle(item.Destination.X, item.Destination.Y + hitarea.Height,
                        item.Destination.Width, item.Destination.Height);

                }
            }
        }
    }
}
