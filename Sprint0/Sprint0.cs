using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Characters;
using Sprint0.Commands;
using Sprint0.Commands.Mario;
using Sprint0.Controllers;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public ISprite marioSprite; // move into mario ICharacter
        public ICharacter mario;
        public Vector2 marioPosition; // move into mario ICharacter

        ISprite textSprite;
        IController KeyboardController;
   
        public GameTime myGameTime;

        public Sprint0()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            KeyboardController = new KeyboardController(this, mario);

            //Keyboard command mappings
            KeyboardController.RegisterCommand(Keys.D0, new Exit(this));
            KeyboardController.RegisterCommand(Keys.D9, new Reset(this));

            // Mario
            KeyboardController.RegisterCommand(Keys.W, new CMarioJump(this));
            KeyboardController.RegisterCommand(Keys.A, new CMarioMoveLeft(this));
            KeyboardController.RegisterCommand(Keys.S, new CMarioCrouch(this));
            KeyboardController.RegisterCommand(Keys.D, new CMarioMoveRight(this));
            KeyboardController.RegisterCommand(Keys.Q, new CMarioFire(this));
            KeyboardController.RegisterCommand(Keys.D1, new CMarioBig(this));
            KeyboardController.RegisterCommand(Keys.D2, new CMarioNormal(this));
           // KeyboardController.RegisterCommand(Keys.E, new CMarioStar(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            marioPosition.X = 150;
            marioPosition.Y = 150;
            mario = new Mario(this, marioPosition);

            marioSprite = new MarioLeftIdleSprite(this);

        }

        protected override void Update(GameTime gameTime)
        {
            myGameTime = gameTime;

            KeyboardController.Update();
            mario.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin();

            mario.State.Draw(_spriteBatch, marioPosition);
            marioSprite.Draw(_spriteBatch, marioPosition);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}