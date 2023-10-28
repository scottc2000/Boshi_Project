using Microsoft.Xna.Framework;
using System;

namespace SprintZero.ScreenCamera
{
    /*
     * The Outline for this class is based on an outline provided by Peter Henry from the 
     * youtube channel CodingMadeEasy. The specific video that inspired this code is:
     * https://youtu.be/OULYMsb6olk his website is: http://www.codingmadeeasy.ca
     */
    public class MarioCamera
    {
        private static MarioCamera instance;
        public int RightBound { get; set; }
        public int LeftBound { get; set; }
        public int ViewPoint { get; set; }
        public int UpperBound { get; set; }
        public int VerticalView { get; set; }
        public Matrix View => Matrix.CreateTranslation(new Vector3(ViewPoint, VerticalView, 0));

        public static MarioCamera Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MarioCamera
                    {
                        RightBound = 600,
                        LeftBound = 0,
                        VerticalView = 0,
                        ViewPoint = 0,
                        UpperBound = 120,
                    };
                }
                return instance;
            }
        }

        private MarioCamera()
        {
        }

        public void SetView(Vector2 marioPos)
        {
            if (marioPos.X >= RightBound)
            {
                LeftBound += (int)marioPos.X - RightBound;
                ViewPoint -= (int)marioPos.X - RightBound;
                RightBound += (int)marioPos.X - RightBound;
            }
            if (marioPos.X <= LeftBound + 100)
            {
                ViewPoint += -1 * ((int)marioPos.X - (LeftBound + 100));
                RightBound -= -1 * ((int)marioPos.X - (LeftBound + 100));
                LeftBound = RightBound - 600;
            }

            if (marioPos.Y <= UpperBound)
            {
                VerticalView += UpperBound - (int)marioPos.Y;
                UpperBound -= UpperBound - (int)marioPos.Y;
            }
            if (marioPos.Y > UpperBound + 472)
            {
                VerticalView -= (int)marioPos.Y - (UpperBound + 472);
                UpperBound += (int)marioPos.Y - (UpperBound + 472);
                if (VerticalView < 0)
                {
                    VerticalView = 0;
                    UpperBound = 120;
                }
            }
        }

        public void Update()
        {
        }
        public void Reset()
        {
            instance.RightBound = 600;
            instance.LeftBound = 0;
            instance.ViewPoint = 0;
            instance.VerticalView = 0;
            instance.UpperBound = 120;
        }
    }
}