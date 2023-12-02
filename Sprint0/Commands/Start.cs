using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class Start : ICommand
    {
        private Sprint0 sprint;

        public Start(Sprint0 game)
        {
            sprint = game;
        }
        public void Execute()
        {
            sprint.gamestates = GameStates.PLAY;
        }
    }
}