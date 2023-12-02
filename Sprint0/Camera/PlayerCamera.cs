using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Camera
{
    /*
     * Code structre inspired from Oyyou youtube channel
     * Video: XNA Tutorial 20 - 2D Camera
     * Needs to be adjusted to match final game funcitonality
     */
    public class PlayerCamera
    {

        public Matrix transform;    // Used to draw camera to screen
        Viewport view;              // view port
        public Vector2 center;         // point to focus on
        CameraNumbers cameraNumbers;
        public PlayerCamera(Viewport newview)
        {
            view = newview;
            cameraNumbers = new CameraNumbers();
        }

        public void Update(IPlayer mario, IPlayer luigi)
        {
            center = Follow(mario, luigi);

            // if mario moves past the world bounds, reset the camera
            if (center.X < cameraNumbers.leftBound)
            {
                center.X = cameraNumbers.leftBound;
            }
            if (center.Y > cameraNumbers.bottomBound)
            {
                center.Y = cameraNumbers.bottomBound;
            }
            if (center.Y < cameraNumbers.upperBound)
            {
                center.Y = cameraNumbers.upperBound;
            }

            // zoom camera to mimic final game functionality
            var zoom = Matrix.CreateScale(new Vector3((float)cameraNumbers.zoom, (float)cameraNumbers.zoom, 0));
            var translation = Matrix.CreateTranslation(new Vector3((float)(-center.X * cameraNumbers.zoom), (float)(-center.Y * cameraNumbers.zoom), 0));

            transform = zoom * translation;

        }

        public Vector2 Follow(IPlayer mario, IPlayer luigi)
        {
            // Set camera to the player who is ahead
            // Note camera snaps due to differences in Y - need to fix
            if (mario.position.X > luigi.position.X)
            {
               center = new Vector2(mario.position.X + (mario.Destination.Width / cameraNumbers.sizeDivider) - cameraNumbers.XCcenterOffset,
               mario.position.Y + (mario.Destination.Height / cameraNumbers.sizeDivider) - cameraNumbers.YCenterXOffset);
            }
            else if (luigi.position.X > mario.position.X)
            {
               center = new Vector2(luigi.position.X + (luigi.Destination.Width / cameraNumbers.sizeDivider) - cameraNumbers.XCcenterOffset,
               luigi.position.Y + (luigi.Destination.Height / cameraNumbers.sizeDivider) - cameraNumbers.YCenterXOffset);
            }

            return center;
        }
    }
}