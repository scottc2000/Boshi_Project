using System;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collision
{
    public class CMarioStuckX : ICommand
    {

        private Sprint0 mySprint0;
        private IMario mario;

        public CMarioStuckX(Sprint0 mySprint0)
        {
            this.mySprint0 = mySprint0;
        }

        public void Execute()
        {

            mario = mySprint0.objects.mario;
            if (mario.facingLeft)
            {
                mario.stuck = true;
                mario.lefthit = true;
            }
            else
            {
                mario.stuck = true;
                mario.righthit = true;
            }

        }
    }
}