using Microsoft.Xna.Framework.Input;

namespace Sprint0.Interfaces
{
    public interface IController
    {
        void Update();

        void RegisterCommand(Keys key, ICommand command);

    }
}
