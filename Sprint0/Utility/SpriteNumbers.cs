using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Utility
{
    public class SpriteNumbers
    {
        /*__________ Universal Sprite Data ___________________*/
        public int millisecondsPerFrame = 100;

        public float frameInterval = 0.1f;

        public int itemInterval = 50;

        /*__________ HammerBro Data ___________________*/
        public int HammerBroTotalFrames = 4;

        public double HammerBroFrameSpeed = 0.2;

        /*__________ Block Sheets ___________________*/
        public int blockScaledPosRectangle = 16;

        /*__________ Item Data ___________________*/
        public int itemUpdateDivider = 2;

        /*__________ Projectile Data ___________________*/
        public int projectileTravelDif = 10;

        public int projectileLeftOffset = -3;

        public int projectileRightOffset = 3;

        public int projectileDrawMultiplier = 2;

        /*__________ HUD Data ___________________*/
        public int HUDDrawMultiplier = 2;

        public Microsoft.Xna.Framework.Rectangle HUDBackground = new Microsoft.Xna.Framework.Rectangle(0, 435, 537, 120);

        public int blankTextureWidth = 1;

        public int blankTextureHeight = 1;
    }
}
