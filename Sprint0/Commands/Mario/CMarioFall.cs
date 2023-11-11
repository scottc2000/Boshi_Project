using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Mario
{
    internal class CMarioFall : ICommand
    {
        private Sprint0 sprint;
        private IMario mario;
        public CMarioFall(Sprint0 sprint, LevelLoader1 level)
        {
            this.sprint = sprint;
            mario = level.mario;
        }
        public void Execute()
        { 
  
            mario.Fall();
            

        }

    }
}