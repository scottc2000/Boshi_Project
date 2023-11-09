using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Commands.Luigi;
using Sprint0.Commands.Mario;
using Sprint0.Interfaces;
using System.Collections.Generic;
namespace Sprint0.Controllers
{
    public class KeyboardController : IController
    {
        public Dictionary<Keys, ICommand> keyboardInput;
        public Dictionary<Keys, ICommand> keyPressed;
        public Dictionary<Keys, ICommand> keyReleased;
        private KeyboardState currentState;
        private KeyboardState previousState;
        public Sprint0 mySprint;
        private LevelLoader1 level;

        public KeyboardController(Sprint0 sprint0, LevelLoader1 level)
        {
            keyboardInput = new Dictionary<Keys, ICommand>();
            keyPressed = new Dictionary<Keys, ICommand>();
            keyReleased = new Dictionary<Keys, ICommand>();
            this.level = level;
            mySprint = sprint0;
            setKeyboardDict();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            keyboardInput.Add(key, command);
        }

        public void RegisterPressCommand(Keys key, ICommand command)
        {
            keyPressed.Add(key, command);
        }

        public void RegisterReleaseCommand(Keys key, ICommand command)
        {
            keyReleased.Add(key, command);
        }

        public void Update()
        {
            currentState = Keyboard.GetState();

            pressedKeys(currentState, previousState);
            heldKeys(currentState);
            releasedKeys(currentState, previousState);

            previousState = currentState;
        }

        public void setKeyboardDict()
        {
            RegisterCommand(Keys.Escape, new Exit(mySprint));
            //RegisterCommand(Keys.D0, new Reset(mySprint, gametime, Content));

            RegisterPressCommand(Keys.W, new CMarioJump(mySprint, level));
            RegisterPressCommand(Keys.A, new CMarioMoveLeft(mySprint, level));
            RegisterReleaseCommand(Keys.A, new CMarioStop(mySprint,level));
            RegisterPressCommand(Keys.S, new CMarioCrouch(mySprint, level));
            RegisterReleaseCommand(Keys.S, new CMarioStop(mySprint, level));
            RegisterPressCommand(Keys.D, new CMarioMoveRight(mySprint, level));
            RegisterReleaseCommand(Keys.D, new CMarioStop(mySprint, level));
            RegisterPressCommand(Keys.E, new CMarioThrow(mySprint, level));      // Still needs projectile

            RegisterPressCommand(Keys.Q, new CDeadMario(mySprint, level));
            RegisterPressCommand(Keys.D4, new CMarioRaccoon(mySprint, level));
            RegisterPressCommand(Keys.D3, new CMarioFire(mySprint, level));
            RegisterPressCommand(Keys.D2, new CMarioBig(mySprint, level));
            RegisterPressCommand(Keys.D1, new CMarioNormal(mySprint, level));

            RegisterPressCommand(Keys.Up, new CLuigiJump(mySprint, level));
            RegisterCommand(Keys.Left, new CLuigiMoveLeft(mySprint, level));
            RegisterReleaseCommand(Keys.Left, new CLuigiStop(mySprint, level));
            RegisterCommand(Keys.Down, new CLuigiCrouch(mySprint, level));
            RegisterReleaseCommand(Keys.Down, new CLuigiStop(mySprint, level));
            RegisterCommand(Keys.Right, new CLuigiMoveRight(mySprint, level));
            RegisterReleaseCommand(Keys.Right, new CLuigiStop(mySprint, level));

            RegisterPressCommand(Keys.D8, new CLuigiRaccoon(mySprint, level));
            RegisterPressCommand(Keys.D7, new CLuigiFire(mySprint, level));
            RegisterPressCommand(Keys.D6, new CLuigiBig(mySprint, level));
            RegisterPressCommand(Keys.D5, new CLuigiNormal(mySprint, level));

            RegisterCommand(Keys.D0, new Reset(mySprint, level));
        }

        private void pressedKeys(KeyboardState current, KeyboardState previous)
        {
            Keys[] oldKeys = previous.GetPressedKeys();
            List<Keys> justPressed = new List<Keys>();
            for (int i = 0; i < oldKeys.Length; i++)
            {
                if (current.IsKeyDown(oldKeys[i]))
                {
                    justPressed.Add(oldKeys[i]);
                }
            }

            foreach (Keys key in justPressed)
            {
                if (keyPressed.ContainsKey(key))
                    keyPressed[key].Execute();
            }

        }

        private void heldKeys(KeyboardState current)
        {
            Keys[] heldKeys = current.GetPressedKeys();

            foreach (Keys key in heldKeys)
            {
                if (keyboardInput.ContainsKey(key))
                    keyboardInput[key].Execute();
            }
        }

        private void releasedKeys(KeyboardState current, KeyboardState previous)
        {
            Keys[] oldKeys = previous.GetPressedKeys();
            List<Keys> justReleased = new List<Keys>();
            for (int i = 0; i < oldKeys.Length; i++)
            {
                if (current.IsKeyUp(oldKeys[i]))
                {
                    justReleased.Add(oldKeys[i]);
                }
            }

            foreach (Keys key in justReleased)
            {
                if (keyReleased.ContainsKey(key))
                    keyReleased[key].Execute();
            }
        }

    }
}
