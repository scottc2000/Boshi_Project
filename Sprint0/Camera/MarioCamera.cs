using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using Sprint0.Characters;
using Sprint0.Interfaces;
using System;

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
        Viewport view;
        Vector2 center;         // point to focus on
        Vector2 originalCenter;

        public MarioCamera(Viewport newview)
        {
            view = newview;
            /*
            aspectRatio = (float)view.Width / view.Height;
            this.fieldOfView = MathHelper.PiOver2;
            zoom = ((0.5f * view.Height) / MathF.Tan(0.5f * fieldOfView));*/

            originalCenter = new Vector2(3, 288);
        }
        
        public void Update(GameTime gameTime, IMario mario)
        {
            // zoom1: -130, -300
            center = new Vector2(mario.position.X + (mario.destination.Width / 2) - 120, mario.position.Y + (mario.destination.Height / 2) - 200);

            if (center.X < originalCenter.X)
            {
                center.X = originalCenter.X;
            }

            var zoom = Matrix.CreateScale(new Vector3((float)1.5, (float)1.5, 0));
            var translation = Matrix.CreateTranslation(new Vector3((float)(-center.X * 1.5), (float)(-center.Y * 1.5), 0));

            transform = zoom * translation;

        }
      
    }
}