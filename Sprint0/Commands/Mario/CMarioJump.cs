using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.SFX;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.Characters.Mario;

namespace Sprint0.Commands.Mario
{
    internal class CMarioJump : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter mario;
        AudioManager sfx;
        public CMarioJump(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
            sfx = AudioManager.Instance;
        }
        public void Execute()
        {
            mario = mySprint0.objects.mario;
            mario.Jump();
            sfx.PlaySFX("jumpSmall");
        }
    }
}