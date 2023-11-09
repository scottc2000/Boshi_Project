using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface IBlock : ICollidable, IGameObject
    {
        public int x {  get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }

    }
}
