using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Blocks;

namespace Sprint0.Commands.Enemies
{
    internal class EnemyNext : ICommand
    {
        public Sprint0 sprint0;
        public EnemyNext(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            if (sprint0.enemyIndex == 2)
            {
                sprint0.enemyIndex = 0;
            }
            else
            {
                sprint0.enemyIndex++;
            }
        }
    }
}