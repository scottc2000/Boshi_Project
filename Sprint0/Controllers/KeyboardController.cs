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
        public Keys[] releasedKeys;

        public KeyboardController(Sprint0 sprint)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            previous = Keyboard.GetState();
            releasedKeys = new Keys[0];
            mySprint = sprint;
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
            Console.WriteLine(pressedKeys);

            foreach(Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                    
                }
                
                    
               
            }
            if (luigiIdle(pressedKeys))
            {
                mySprint.luigi.Stop();
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
            return ((!pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.W) &&
                !pressedKeys.Contains(Keys.D) &&
                !pressedKeys.Contains(Keys.S))

                

                || (!pressedKeys.Contains(Keys.J) &&
                !pressedKeys.Contains(Keys.I) &&
                 !pressedKeys.Contains(Keys.L) &&
                !pressedKeys.Contains(Keys.K)))

                && !(pressedKeys.Contains(Keys.Z));
        }

        private bool luigiIdle(Keys[] pressedKeys)
        {
            return (!pressedKeys.Contains(Keys.J) &&
                !pressedKeys.Contains(Keys.I) &&
                 !pressedKeys.Contains(Keys.L) &&
                !pressedKeys.Contains(Keys.K));
        }

    }
}
