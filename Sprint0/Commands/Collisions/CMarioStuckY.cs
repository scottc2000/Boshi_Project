using System;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collision
{
    public class CMarioStuckY : ICommand
    {

        private Sprint0 mySprint0;
        private ICharacter mario;

        public CMarioStuckY(Sprint0 mySprint0)
        {
            this.mySprint0 = mySprint0;
        }

        public void Execute()
        {

            mario = mySprint0.objects.mario;
            mario.uphit = true;


        }
    }
}