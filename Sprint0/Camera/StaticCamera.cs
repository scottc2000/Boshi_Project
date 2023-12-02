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
    public class StaticCamera : ICamera
    {

        public Matrix transform;    // Used to draw camera to screen
        Viewport view;              // view port
        public Vector2 center;         // point to focus on
        CameraNumbers cameraNumbers;
        int positionX;
        int positionY;
        public StaticCamera(Viewport newview, int posX, int posY)
        {
            view = newview;
            cameraNumbers = new CameraNumbers();
            positionX = posX;
            positionY = posY;
        }
        
        public void Update(IPlayer mario, IPlayer luigi)
        {
            Matrix positionMatrix = Matrix.CreateTranslation(
    -positionX + (view.Width / 2),
    -positionY + (view.Height / 2),
    0);

            transform = positionMatrix;

        }
    }
}