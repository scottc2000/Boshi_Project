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
using System.Reflection.Metadata;
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
            //Keyboard command mappings
            RegisterCommand(Keys.Escape, new Exit(sprint0));
            // KeyboardController.RegisterCommand(Keys.D0, new Reset(this, gametime, Content));

            // Mario
            RegisterCommand(Keys.W, new CMarioJump(sprint0));
            RegisterCommand(Keys.A, new CMarioMoveLeft(sprint0));
            RegisterCommand(Keys.S, new CMarioCrouch(sprint0));
            RegisterCommand(Keys.D, new CMarioMoveRight(sprint0));
            RegisterCommand(Keys.E, new CMarioThrow(sprint0));      // Still needs projectile

            RegisterCommand(Keys.Q, new CDeadMario(sprint0));
            RegisterCommand(Keys.D4, new CMarioRaccoon(sprint0));
            RegisterCommand(Keys.D3, new CMarioFire(sprint0));
            RegisterCommand(Keys.D2, new CMarioBig(sprint0));
            RegisterCommand(Keys.D1, new CMarioNormal(sprint0));



            // Luigi
            RegisterCommand(Keys.I, new CLuigiJump(sprint0));
            RegisterCommand(Keys.J, new CLuigiMoveLeft(sprint0));
            RegisterCommand(Keys.K, new CLuigiCrouch(sprint0));
            RegisterCommand(Keys.L, new CLuigiMoveRight(sprint0));
            RegisterCommand(Keys.M, new CLuigiThrow(sprint0));

            RegisterCommand(Keys.D8, new CLuigiRaccoon(sprint0));
            RegisterCommand(Keys.D7, new CLuigiFire(sprint0));
            RegisterCommand(Keys.D6, new CLuigiBig(sprint0));
            RegisterCommand(Keys.D5, new CLuigiNormal(sprint0));

            
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
               !pressedKeys.Contains(Keys.L) && !pressedKeys.Contains(Keys.E) && !pressedKeys.Contains(Keys.M))
            {
                mySprint.luigi.State.Stop();
            }
        }

    }
}
