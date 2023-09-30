﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Commands.Blocks
{
    internal class BlockNext : ICommand
    {
        private Sprint0 game;
        public BlockNext(Sprint0 game) 
        {
            this.game = game;
        }

        public void Execute() 
        {
            game.currentSpriteIndex++;
            if (game.currentSpriteIndex == 5)
            {
                game.currentSpriteIndex = 0;
            }

            //switch (game.currentSpriteIndex)
            //{
            //    case 1:
            //        game.tempSpriteIndex = 6;
            //        break;
            //    case 4:
            //        game.tempSpriteIndex = 9;
            //        break;
            //    default:
            //        game.tempSpriteIndex = game.currentSpriteIndex;
            //        break;
            //}

        }
    }
}