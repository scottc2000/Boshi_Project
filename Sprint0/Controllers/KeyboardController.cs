﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
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

        private KeyboardState currentKeyState;
        private KeyboardState previousKeyState;

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        private void getKeyState()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            

            foreach (Keys key in pressedKeys)
            {
                previousKeyState = currentKeyState;
                if (controllerMappings.ContainsKey(key))
                {

                }
                if (controllerMappings.ContainsKey(key))
                    controllerMappings[key].Execute();
            }

        }

    }
}
