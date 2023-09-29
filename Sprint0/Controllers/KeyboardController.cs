using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        public Keys[] releasedKeys;
        public ICharacter mario;

        public KeyboardController(Sprint0 sprint0, ICharacter Mario)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            mario = Mario;
            releasedKeys = new Keys[0];
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach(Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
<<<<<<< HEAD
                }
            }

            /*
            // Quit
            if (pressedKeys.Contains(Keys.Escape) && !releasedKeys.Contains(Keys.Escape))
            {
                controllerMappings[Keys.Escape].Execute();
            }

            // Reset
            if (pressedKeys.Contains(Keys.D0) && !releasedKeys.Contains(Keys.D0))
            {
                controllerMappings[Keys.D0].Execute();
            }

            // Move Left
            if (pressedKeys.Contains(Keys.A) && !releasedKeys.Contains(Keys.A))
            {
                controllerMappings[Keys.A].Execute();
            }

            // Stop Moving Left
            else if (!pressedKeys.Contains(Keys.A) && releasedKeys.Contains(Keys.A))
            {
                new CReleasedMario(mySprint);
            }
=======
                if (next(pressedKeys)) { controllerMappings[key].Execute(); }
                if (prev(pressedKeys)) { controllerMappings[key].Execute(); }
            }

            /*  if (pressedKeys.Contains(Keys.D0))
              {
                  controllerMappings[Keys.D0].Execute();
              }
              if (pressedKeys.Contains(Keys.D9))
              {
                  controllerMappings[Keys.D9].Execute();
              }
              if(Left(pressedKeys))
              {
                  controllerMappings[Keys.A].Execute();
              } else if (Right(pressedKeys))
              {
                  controllerMappings[Keys.D].Execute();
              } else if (Up(pressedKeys))
              {
                  controllerMappings[Keys.W].Execute();
              } else if (Down(pressedKeys))
              {
                  controllerMappings[Keys.S].Execute();
              } else if (Idle(pressedKeys))
              {
                  controllerMappings[Keys.Z].Execute();
              }

              releasedKeys = pressedKeys; */
>>>>>>> f36c50eea6a6522d1878aedc5ed220b24a0ee4a3

            // Move Right
            else if (pressedKeys.Contains(Keys.D) && !releasedKeys.Contains(Keys.D))
            {
                controllerMappings[Keys.D].Execute();
            }

            // Stop Moving Right

            else if (!pressedKeys.Contains(Keys.D) && releasedKeys.Contains(Keys.D))
            {
                new CReleasedMario(mySprint);
            }

            // Jump
            else if (pressedKeys.Contains(Keys.W) && !releasedKeys.Contains(Keys.W))
            {
                controllerMappings[Keys.W].Execute();
            }

            // Crouch
            else if (pressedKeys.Contains(Keys.S) && !releasedKeys.Contains(Keys.S))
            {
                controllerMappings[Keys.S].Execute();

<<<<<<< HEAD
            }

            // Not Crouching
            else if (!pressedKeys.Contains(Keys.S) && releasedKeys.Contains(Keys.S))
            {
                new CReleasedMario(mySprint);
            }

            // Change to Fire State
            else if (pressedKeys.Contains(Keys.Q) && !releasedKeys.Contains(Keys.Q))
            {
                controllerMappings[Keys.Q].Execute();
            }

            // Change to Big State
            else if (pressedKeys.Contains(Keys.D1) && !releasedKeys.Contains(Keys.D1))
            {
                controllerMappings[Keys.D1].Execute();
            }

            // Change to Normal State
            else if (pressedKeys.Contains(Keys.D2) && !releasedKeys.Contains(Keys.D2))
            {
                controllerMappings[Keys.D2].Execute();
            }
            */
            releasedKeys = pressedKeys;
=======
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
                !pressedKeys.Contains(Keys.S) &&
                pressedKeys.Contains(Keys.Z))

                 || !pressedKeys.Contains(Keys.D) &&
                !pressedKeys.Contains(Keys.S)
>>>>>>> f36c50eea6a6522d1878aedc5ed220b24a0ee4a3

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
