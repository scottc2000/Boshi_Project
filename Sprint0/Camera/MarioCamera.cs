using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Interfaces;

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
        float leftBound;
        float rightBound;

        public MarioCamera(Viewport newview)
        {
            view = newview;
            leftBound = 25;
            rightBound = 200;
        }
        
        public void Update(GameTime gameTime, IMario mario)
        {
            // zoom1: -130, -300
            center = new Vector2(mario.position.X + (mario.destination.Width / 2) - 130, mario.position.Y + (mario.destination.Height / 2) - 300);
            
            var zoom = Matrix.CreateScale(new Vector3((float)1, (float)1, 0));
           
            //System.Diagnostics.Debug.WriteLine("Center2: " + center);
            var translation = Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));

            transform = zoom * translation;
        }
      
    }
}