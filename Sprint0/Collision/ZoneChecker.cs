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
                case >= 0 and < 256:
                    marioZone = 1; break;
                case <= 256 and < 512:
                    marioZone = 2; break;
                case <= 512 and < 768:
                    marioZone = 3; break;
                case <= 768 and < 1024:
                    marioZone = 4; break;
                case <= 1024 and < 1280:
                    marioZone = 5; break;
                case <= 1280 and < 1536:
                    marioZone = 6; break;
                case <= 1536 and < 1792:
                    marioZone = 7; break;
                case <= 1792 and < 2048:
                    marioZone = 8; break;
                case <= 2048 and < 2304:
                    marioZone = 9; break;
                case <= 2304 and < 2560:
                    marioZone = 10; break;
                case <= 2560 and < 2816:
                    marioZone = 11; break;
                
            }

            return marioZone;
        }

    }
}
