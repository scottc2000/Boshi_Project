using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        private Sprint0 mySprint;


        public KeyboardController(Sprint0 sprint)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            mySprint = sprint;
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

       
        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach(Keys keys in pressedKeys)
            {
                if (controllerMappings.ContainsKey(keys))
                {
                    controllerMappings[keys].Execute();
                }
            } 
            
        }
    }
}
