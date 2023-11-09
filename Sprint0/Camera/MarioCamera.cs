using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public Matrix transform;    // Used to draw camera to screen
        Viewport view;              // view port
        Vector2 center;         // point to focus on
        float leftBound;        // left bound to prevent mario from moving off level

        public MarioCamera(Viewport newview)
        {
            view = newview;
            leftBound = 3; ;
        }
        
        public void Update(IMario mario)
        {
            // center camera on mario
            center = new Vector2(mario.position.X + (mario.Destination.Width / 2) - 120, mario.position.Y + (mario.Destination.Height / 2) - 200);

            // if mario moves past the left bound, reset the camera
            if (center.X < leftBound)
            {
                center.X = leftBound;
            }

            // zoom camera to mimic final game functionality
            var zoom = Matrix.CreateScale(new Vector3((float)1.5, (float)1.5, 0));
            var translation = Matrix.CreateTranslation(new Vector3((float)(-center.X * 1.5), (float)(-center.Y * 1.5), 0));

            transform = zoom * translation;

        }
      
    }
}