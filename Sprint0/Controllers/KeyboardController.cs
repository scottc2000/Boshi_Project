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
        public KeyboardState current;
        public KeyboardState previous;
        public List<Keys> releasedKeys = new List<Keys>();

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            previous = Keyboard.GetState();

        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        private bool IsPressed(Keys key, KeyboardState current)
        {
            return (current.IsKeyDown(key) && !previous.IsKeyDown(key));
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                    controllerMappings[key].Execute();
            }


        }

        // helper booleans
        private bool Left(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.W) &&
                !pressedKeys.Contains(Keys.D) &&
                !pressedKeys.Contains(Keys.S);
        }
        private bool Right(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.W) &&
                pressedKeys.Contains(Keys.D) &&
                !pressedKeys.Contains(Keys.S);
        }
        private bool Down(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.W) &&
                !pressedKeys.Contains(Keys.D) &&
                pressedKeys.Contains(Keys.S);
        }
        private bool Up(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.A) &&
                pressedKeys.Contains(Keys.W) &&
                !pressedKeys.Contains(Keys.D) &&
                !pressedKeys.Contains(Keys.S);
        }
        private bool Idle(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.W) &&
                !pressedKeys.Contains(Keys.D) &&
                !pressedKeys.Contains(Keys.S);
        }

    }
}
