using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Sprint0.GameMangager;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    internal class CCoinDisappear : ICommand
    {
        private Sprint0 game;
        public ObjectManager objectManager;
        public CCoinDisappear(Sprint0 game) 
        {
            this.game = game;
            objectManager = game.objects;
        }

        public void Execute()
        {
            objectManager.Blocks.Remove();
            objectManager.Coins.Remove();
        }
    }
}
