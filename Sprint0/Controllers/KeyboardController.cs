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
        public KeyboardState current;
        public KeyboardState previous;
        public Keys[] releasedKeys;
        public ICharacter mario;

        public KeyboardController(Sprint0 sprint0, ICharacter Mario)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            previous = Keyboard.GetState();
            mario = Mario;
            releasedKeys = new Keys[0];
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

            // Quit
             if (pressedKeys.Contains(Keys.D0) && !releasedKeys.Contains(Keys.D0))
            {
                controllerMappings[Keys.D0].Execute();
            }

            // Reset
            if (pressedKeys.Contains(Keys.D9) && !releasedKeys.Contains(Keys.D9))
            {
                controllerMappings[Keys.D9].Execute();
            }

            // Move Left
            if(Left(pressedKeys) && !Left(releasedKeys))
            {
                controllerMappings[Keys.A].Execute();
            } 

            // Stop Moving Left
            else if(!Left(pressedKeys) && Left(releasedKeys))
            {
                new CReleasedMario(mySprint);
            }    
            
            // Move Right
            else if (Right(pressedKeys) && !Right(releasedKeys))
            {
                controllerMappings[Keys.D].Execute();
            } 

            // Stop Moving Right

            else if (!Right(pressedKeys) && Right(releasedKeys))
            {
                new CReleasedMario(mySprint);
            }
            
            // Jump
            else if (Up(pressedKeys) && !Up(releasedKeys))
            {
                controllerMappings[Keys.W].Execute();
            } 
            
            // Crouch
            else if (Down(pressedKeys) && !Down(releasedKeys))
            {
                controllerMappings[Keys.S].Execute();

            } 

            // Not Crouching
            else if (!Down(pressedKeys) && Down(releasedKeys))
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

            releasedKeys = pressedKeys;

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
                !pressedKeys.Contains(Keys.S) &&
                pressedKeys.Contains(Keys.Z)

                || (!pressedKeys.Contains(Keys.J) &&
                !pressedKeys.Contains(Keys.I) &&
                 !pressedKeys.Contains(Keys.L) &&
                !pressedKeys.Contains(Keys.K)));
        }

    }
}
