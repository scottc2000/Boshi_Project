using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0
{
    internal class Reset : ICommand
    {
        private Sprint0 mySprint;
        public Reset(Sprint0 game) { 
            mySprint = game;
        }
        public void Execute() 
        {
            mySprint.marioSprite = new MarioBigLeftIdleSprite(mySprint);
            mySprint.luigi.currentSprite = new NormalLuigiStill(mySprint.luigi);
        }

    }
}
