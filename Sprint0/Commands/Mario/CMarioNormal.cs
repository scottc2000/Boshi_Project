using Sprint0.Interfaces;


namespace Sprint0.Commands.Mario
{
    public class CMarioNormal : ICommand
    {
        private Sprint0 mySprint0;
        private IMario mario;
        public CMarioNormal(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mario = mySprint0.objects.mario;
            mario.ChangeToNormal();
        }

    }
}
