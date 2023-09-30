using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Commands.Enemies
{
    internal class EnemyPrev : ICommand
    {
        public Sprint0 sprint0;
        public EnemyPrev(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            if (sprint0.enemyIndex == 0)
            {
                sprint0.enemyIndex = 2;
            } else
            {
                sprint0.enemyIndex--;
            }

        }
    }
}
