using Microsoft.Xna.Framework;
using Sprint0.Characters;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class Camera
    {
        public Matrix transform {  get; private set; }
        public Matrix offset { get; private set; }
        public Rectangle hitBox { get; private set; }

        public Camera()
        {
            hitBox = new Rectangle(1, 2, 3, 4); //needs actual hitBox
            offset = Matrix.CreateTranslation(Sprint0.ScreenWidth / 2, Sprint0.ScreenHeight / 2, 0);
        }

        public void follow(ICharacter player)
        {
            transform = Matrix.CreateTranslation(
                -player.position.X - (hitBox.Width / 2),
                -player.position.Y - (hitBox.Height / 2),
                0) * offset;
        }
    }
}
