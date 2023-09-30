using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.Characters.Mario;

namespace Sprint0.Commands.Mario
{
    internal class CMarioDead : ICommand
    {
        private Sprint0 mysprint;
        private ICharacter mario;

        public CMarioDead(Sprint0 mysprint)
        {
            this.mysprint = mysprint;
        }

        public void Execute()
        {
            mario = mysprint.mario;
            mario.Die();
        }
    }
}
