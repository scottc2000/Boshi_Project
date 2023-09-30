using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Characters;
using Sprint0.Commands;
using Sprint0.Commands.Mario;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
namespace Sprint0.Controllers
{
    public class KeyboardController : IController
    {
        public Dictionary<Keys, ICommand> controllerMappings;
        public Sprint0 mySprint;

        public KeyboardController(Sprint0 sprint0)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            mySprint = sprint0;
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();

                }
            }

            if (!pressedKeys.Contains(Keys.W) &&
                !pressedKeys.Contains(Keys.A) &&
                 !pressedKeys.Contains(Keys.S) &&
                !pressedKeys.Contains(Keys.D) && !pressedKeys.Contains(Keys.E))
            {
                mySprint.mario.State.Stop();
            }

            if (!pressedKeys.Contains(Keys.I) &&
               !pressedKeys.Contains(Keys.J) &&
                !pressedKeys.Contains(Keys.K) &&
               !pressedKeys.Contains(Keys.L) && !pressedKeys.Contains(Keys.E))
            {
                // mySprint.luigi.State.Stop();
            }
        }

    }
}
