﻿using Sprint0.Interfaces;

namespace Sprint0.Commands.Mario
{
    internal class CMarioThrow : ICommand
    {
        private Sprint0 mySprint0;
        private IMario mario;
        public CMarioThrow(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mario = mySprint0.objects.mario;
            mario.Throw();

        }

    }
}
