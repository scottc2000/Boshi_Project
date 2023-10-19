using Sprint0.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision
{
    internal class ZoneChecker
    {
        int marioXPosition;
        public ZoneChecker()
        {
            //gets zonedata from json
            marioXPosition = 0;//temp variable
        }

        public int CheckMarioPosition()
        {
            int marioZone=0;
            switch (marioXPosition)
            {
                case >= 0 and < 200:
                    marioZone = 1; break;
                case <= 200 and < 400:
                    marioZone = 2; break;
                case <= 400 and < 600:
                    marioZone = 3; break;
                case <= 600 and < 800:
                    marioZone = 4; break;
                case <= 800 and < 1000:
                    marioZone = 5; break;
                case <= 1000 and < 1200:
                    marioZone = 6; break;
                case <= 1200 and < 1400:
                    marioZone = 7; break;
                case <= 1400 and < 1600:
                    marioZone = 8; break;
                case <= 1600 and < 1800:
                    marioZone = 9; break;
                case <= 1800 and < 2000:
                    marioZone = 10; break;
                case <= 2000 and < 2200:
                    marioZone = 11; break;
                case <= 2200 and < 2400:
                    marioZone = 12; break;
                case <= 2400 and < 2600:
                    marioZone = 13; break;
                case <= 2600 and < 2800:
                    marioZone = 14; break;
                case <= 2800 and < 3000:
                    marioZone = 15; break;
            }

            return marioZone;
        }

    }
}
