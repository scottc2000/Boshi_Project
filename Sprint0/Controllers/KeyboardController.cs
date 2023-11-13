using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Commands.Player;
using Sprint0.Interfaces;
using System.Collections.Generic;
namespace Sprint0.Controllers
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> keyboardInput;
        private Dictionary<Keys, ICommand> keyPressed;
        private Dictionary<Keys, ICommand> keyReleased;

        private KeyboardState currentState;
        private KeyboardState previousState;

        private Sprint0 mySprint;
        private LevelLoader1 level;

        private IPlayer mario;
        private IPlayer luigi;

        public KeyboardController(Sprint0 sprint0, IPlayer mario, IPlayer luigi)
        {
            keyboardInput = new Dictionary<Keys, ICommand>();
            keyPressed = new Dictionary<Keys, ICommand>();
            keyReleased = new Dictionary<Keys, ICommand>();

            this.mario = mario;
            this.luigi = luigi;

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

            RegisterPressCommand(Keys.W, new CPlayerJump(mario));
            RegisterReleaseCommand(Keys.W, new CPlayerFall(mario));
            RegisterPressCommand(Keys.A, new CPlayerMoveLeft(mario));
            RegisterReleaseCommand(Keys.A, new CPlayerStop(mario));
            RegisterPressCommand(Keys.S, new CPlayerCrouch(mario));
            RegisterReleaseCommand(Keys.S, new CPlayerStop(mario));
            RegisterPressCommand(Keys.D, new CPlayerMoveRight(mario));
            RegisterReleaseCommand(Keys.D, new CPlayerStop(mario));
            RegisterPressCommand(Keys.E, new CPlayerThrow(mario));

            // For testing
            RegisterPressCommand(Keys.Q, new CDeadPlayer(mario));
            RegisterPressCommand(Keys.D4, new CPlayerRaccoon(mario));
            RegisterPressCommand(Keys.D3, new CPlayerFire(mario));
            RegisterPressCommand(Keys.D2, new CPlayerBig(mario)) ;
            RegisterPressCommand(Keys.D1, new CPlayerNormal(mario));

            RegisterPressCommand(Keys.Up, new CPlayerJump(luigi));
            RegisterReleaseCommand(Keys.Up, new CPlayerFall(luigi));
            RegisterPressCommand(Keys.Left, new CPlayerMoveLeft(luigi));
            RegisterReleaseCommand(Keys.Left, new CPlayerStop(luigi));
            RegisterPressCommand(Keys.Down, new CPlayerCrouch(luigi));
            RegisterReleaseCommand(Keys.Down, new CPlayerStop(luigi));
            RegisterPressCommand(Keys.Right, new CPlayerMoveRight(luigi));
            RegisterReleaseCommand(Keys.Right, new CPlayerStop(luigi));
            RegisterPressCommand(Keys.M, new CPlayerThrow(luigi));

            RegisterCommand(Keys.D0, new Reset(mySprint));
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
