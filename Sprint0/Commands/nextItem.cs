using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.Item_Sprites;

namespace Sprint0.Commands
{
    internal class nextItem : ICommand
    {
        private Sprint0 mySprint0 { get; set; }

        public nextItem(Sprint0 sprint0)
        {
            mySprint0 = sprint0;
        }

        public void Execute()
        {
            mySprint0.currentItemSprite++;
            if (mySprint0.currentItemSprite > 8) mySprint0.currentItemSprite = 0;
            switch (mySprint0.currentItemSprite) 
            {
                case 0:
                    mySprint0.itemSprite = new RedMushroom();
                    break;
                case 1:
                    mySprint0.itemSprite = new OneUpMushroom();
                    break;
                case 2:
                    mySprint0.itemSprite = new FireFlower();
                    break;
                case 3:
                    mySprint0.itemSprite = new Leaf();
                    break;
                case 4:
                    mySprint0.itemSprite = new Star(mySprint0);
                    break;
                case 5:
                    mySprint0.itemSprite = new Frog();
                    break;
                case 6:
                    mySprint0.itemSprite = new Tanooki();
                    break;
                case 7:
                    mySprint0.itemSprite = new Hammer();
                    break;
                case 8:
                    mySprint0.itemSprite = new Shoe(mySprint0);
                    break;
            }
        }
    }
}
