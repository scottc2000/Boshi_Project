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
        public int millisecondsPerFrame { get; } = 100;

        public float frameInterval { get; } = 0.1f;

        public int itemInterval { get; } = 50;

        /*__________ HammerBro Data ___________________*/
        public int HammerBroTotalFrames { get; } = 4;

        public double HammerBroFrameSpeed { get; } = 0.2;

        /*__________ Block Sheets ___________________*/
        public int blockScaledPos { get; } = 16;

        /*__________ Item Data ___________________*/
        public int itemUpdateDivider { get; } = 2;

        /*__________ Projectile Data ___________________*/
        public int projectileTravelDif { get; } = 10;

        public int projectileLeftOffset { get; } = -3;

        public int projectileRightOffset { get; } = 3;

        public int projectileDrawMultiplier { get; } = 2;

        /*__________ HUD Data ___________________*/
        public int HUDDrawMultiplier { get; } = 2;
        public int digitOffset { get; } = 16;

        public Microsoft.Xna.Framework.Rectangle HUDBackground = new Microsoft.Xna.Framework.Rectangle(0, 435, 537, 120);

        public int blankTextureWidth { get; } = 1;

        public int blankTextureHeight { get; } = 1;
    }
}
