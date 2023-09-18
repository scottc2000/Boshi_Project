using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Controllers
{
    internal class MouseController : IController
    {
        const int width = 800;
        const int height = 475;

        public Dictionary<string, ICommand> controllerMappings;

        string mouseState;

        public MouseController()
        {
            controllerMappings = new Dictionary<string, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            //Not used
        }

        public void RegisterMouseCommand(string mouseState, ICommand command)
        {

            controllerMappings.Add(mouseState, command);

        }

        public void Update()
        {

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
                controllerMappings["Exit"].Execute();

            mouseState = GetMousePosition();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (controllerMappings.ContainsKey(mouseState))
                    controllerMappings[mouseState].Execute();
            }



        }
        string GetMousePosition()
        {
            int mouseX = Mouse.GetState().X;
            int mouseY = Mouse.GetState().Y;

            if (mouseX < width / 2 && mouseY < height / 2)
            {
                return "TopLeft";
            }
            else if (mouseX >= width / 2 && mouseY < height / 2)
            {
                return "TopRight";
            }
            else if (mouseX < width / 2 && mouseY >= height / 2)
            {
                return "BottomLeft";
            }
            else
            {
                return "BottomRight";
            }
        }
    }
}
