using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Utility;
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

        public Matrix transform;    // Used to draw camera to screen
        Viewport view;              // view port
        Vector2 center;         // point to focus on
        float leftBound;        // left bound to prevent mario from moving off level
        CameraNumbers cameraNumbers = new CameraNumbers();
        public MarioCamera(Viewport newview)
        {
            view = newview;
            leftBound = 3; ;
        }
        
        public void Update(IMario mario)
        {
            int marioSize = cameraNumbers.normalMarioSize;
            if (mario.health.Equals(Mario.MarioHealth.Normal) || mario.health.Equals(Mario.MarioHealth.Dead) )
            {
                marioSize = cameraNumbers.normalMarioSize;
            } else
            {
                marioSize = cameraNumbers.bigMarioSize;
            }
            // center camera on mario
            center = new Vector2(mario.position.X + (marioSize / cameraNumbers.sizeDivider) - cameraNumbers.XCcenterOffset, mario.position.Y + (marioSize / 2) - cameraNumbers.YCenterXOffset);

            // if mario moves past the left bound, reset the camera
            if (center.X < leftBound)
            {
                center.X = leftBound;
            }

            // zoom camera to mimic final game functionality
            var zoom = Matrix.CreateScale(new Vector3((float)cameraNumbers.zoom, (float)cameraNumbers.zoom, 0));
            var translation = Matrix.CreateTranslation(new Vector3((float)(-center.X * cameraNumbers.zoom), (float)(-center.Y * cameraNumbers.zoom), 0));

            transform = zoom * translation;

        }
    }
}