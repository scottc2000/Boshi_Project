using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;

namespace Sprint0.Camera
{
    /*
     * Code structre inspired from Oyyou youtube channel
     * Video: XNA Tutorial 20 - 2D Camera
     * Needs to be adjusted to match final game funcitonality
     */
    public class MarioCamera
    {
        public Matrix transform;// Used to draw camera to screen
        Viewport view;
        Vector2 center;

        public MarioCamera(Viewport newview)
        {
            view = newview;
        }
        
        public void Update(GameTime gameTime, Mario mario)
        {
            center = new Vector2(mario.position.X + (mario.destination.Width / 2) - 305, mario.position.Y + (mario.destination.Height / 2) - 50);
            var zoom = Matrix.CreateScale(new Vector3((float)1.5, (float)1.5, 0));
            var translation = Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));

            transform = zoom * translation;
        }
      
    }
}