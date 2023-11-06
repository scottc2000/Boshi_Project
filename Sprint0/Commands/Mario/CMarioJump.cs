
﻿using Sprint0.Interfaces;

namespace Sprint0.Commands.Mario
{
    public class CMarioJump : ICommand
    {
        private Sprint0 mySprint0;

        private IMario mario;

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