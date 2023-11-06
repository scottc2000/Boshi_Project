using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CMarioMoveRight : ICommand
    {
       
        private Sprint0 mySprint0;
        private IMario mario;

        public CMarioMoveRight(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mario = mySprint0.objects.mario;
            mario.facingLeft = false;

            if (mario.health == Characters.Mario.MarioHealth.Raccoon && mario.pose == Characters.Mario.MarioPose.Walking)
                mario.runningTimer++;
            else
                mario.runningTimer = 0;
            System.Diagnostics.Debug.WriteLine("running timer: " + mario.runningTimer);

            mario.Move();
        }
    }
}
