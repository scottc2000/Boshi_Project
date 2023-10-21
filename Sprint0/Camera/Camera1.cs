using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using System.Diagnostics.Metrics;

namespace Sprint0.Camera
{
    /*
     * Code structre inspired from Oyyou youtube channel
     * Video: XNA Tutorial 20 - 2D Camera
     * Needs to be adjusted to match final game funcitonality
     */
    public class Camera1
    {
        public Matrix transform;    // Used to draw camera to scree
        Viewport view;              // where camera is looking
        Vector2 center;             // center of camera

        int rightBound;
        int leftBound;

        public Camera1(Viewport newView)
        {
            view = newView;
            rightBound = 600;
            leftBound = 0;
        }

        public void Update(GameTime gameTime, ICharacter mario)
        {
            center = new Vector2(mario.destination.X - 200, 0);

            // Stops screen from scrolling off the background sprite - needs to be fixed (buggy)
            // Mario resets as well
            if (mario.destination.X <= leftBound + 150)
            {
                center.X = 20;
            }

            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}