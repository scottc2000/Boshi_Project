using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Controllers
{
    public class KeyboardController : IController
    {
        public Dictionary<Keys, ICommand> controllerMappings;
        public Sprint0 mySprint;

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
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
                if (Down(pressedKeys)) { controllerMappings[key].Execute(); }
                else if (Left(pressedKeys)) { controllerMappings[key].Execute(); }
                else if (Right(pressedKeys)) { controllerMappings[key].Execute(); }
                else if (Up(pressedKeys)) { controllerMappings[key].Execute(); }
                else if (next(pressedKeys)) { controllerMappings[key].Execute(); }
                else if (prev(pressedKeys)) { controllerMappings[key].Execute(); }
            }

        }

        // helper booleans
        private bool Left(Keys[] pressedKeys)
        {
            return (pressedKeys.Contains(Keys.A) && // Mario
                !pressedKeys.Contains(Keys.W) &&
                !pressedKeys.Contains(Keys.D) &&
                !pressedKeys.Contains(Keys.S))

                || (pressedKeys.Contains(Keys.J) && // Luigi
                !pressedKeys.Contains(Keys.I) &&
                !pressedKeys.Contains(Keys.L) &&
                !pressedKeys.Contains(Keys.K));
        }
        private bool Right(Keys[] pressedKeys)
        {
            return (!pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.W) &&
                 pressedKeys.Contains(Keys.D) &&
                !pressedKeys.Contains(Keys.S))

                || (!pressedKeys.Contains(Keys.J) &&
                !pressedKeys.Contains(Keys.I) &&
                 pressedKeys.Contains(Keys.L) &&
                !pressedKeys.Contains(Keys.K));
        }
        private bool Down(Keys[] pressedKeys)
        {
            return (!pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.W) &&
                 !pressedKeys.Contains(Keys.D) &&
                pressedKeys.Contains(Keys.S))

                || (!pressedKeys.Contains(Keys.J) &&
                !pressedKeys.Contains(Keys.I) &&
                 !pressedKeys.Contains(Keys.L) &&
                pressedKeys.Contains(Keys.K));
        }
        private bool Up(Keys[] pressedKeys)
        {
            return (!pressedKeys.Contains(Keys.A) &&
                pressedKeys.Contains(Keys.W) &&
                 !pressedKeys.Contains(Keys.D) &&
                !pressedKeys.Contains(Keys.S))

                || (!pressedKeys.Contains(Keys.J) &&
                 pressedKeys.Contains(Keys.I) &&
                 !pressedKeys.Contains(Keys.L) &&
                !pressedKeys.Contains(Keys.K));
        }
        private bool Idle(Keys[] pressedKeys)
        {
            return (!pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.W) &&
                 !pressedKeys.Contains(Keys.D) &&
                !pressedKeys.Contains(Keys.S))

                || (!pressedKeys.Contains(Keys.J) &&
                !pressedKeys.Contains(Keys.I) &&
                 !pressedKeys.Contains(Keys.L) &&
                !pressedKeys.Contains(Keys.K));
        }

        private bool next(Keys[] pressedKeys)
        {
            return (pressedKeys.Contains(Keys.Y) &&
                 !pressedKeys.Contains(Keys.T));
        }

        private bool prev(Keys[] pressedKeys)
        {
            return (pressedKeys.Contains(Keys.T) &&
                !pressedKeys.Contains(Keys.Y));
        }

    }
}
