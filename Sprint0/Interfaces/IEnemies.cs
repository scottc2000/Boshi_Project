using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface IEnemies : ICollidable
    {
        public void SetPosition(List<int> position);
        public Rectangle Destination { get; set; }
        public void ChangeDirection();

        public void BeStomped();

        public void BeFlipped();

        public void Move();

    }
}
