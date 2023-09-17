using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Controllers;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public ISprite luigiSprite;
        ISprite textSprite;
        IController KeyboardController;
        IController MouseController;
        const int width = 800;
        const int height = 475;
        public GameTime myGameTime;

        public Sprint0()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            KeyboardController = new KeyboardController();
            MouseController = new MouseController();

            //Command interface implementations
            ICommand Exit = new Exit(this);
            ICommand SetStillSprite = new SetStillSpriteCommand(this);
            ICommand SetDeadSprite = new SetDeadSpriteCommand(this);
            ICommand SetRunInPlaceSprite = new SetRunInPlaceSpriteCommand(this);
            ICommand SetRunAroundSprite = new SetRunAroundSpriteCommand(this);

            //Keyboard command mappings
            KeyboardController.RegisterCommand(Keys.D0, Exit);
            KeyboardController.RegisterCommand(Keys.D1, SetStillSprite);
            KeyboardController.RegisterCommand(Keys.D2, SetRunInPlaceSprite);
            KeyboardController.RegisterCommand(Keys.D3, SetDeadSprite);
            KeyboardController.RegisterCommand(Keys.D4, SetRunAroundSprite);

            //Mouse command mappings
            MouseController.RegisterMouseCommand("Exit", Exit);
            MouseController.RegisterMouseCommand("TopLeft", SetStillSprite);
            MouseController.RegisterMouseCommand("TopRight", SetRunInPlaceSprite);
            MouseController.RegisterMouseCommand("BottomLeft", SetDeadSprite);
            MouseController.RegisterMouseCommand("BottomRight", SetRunAroundSprite);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            luigiSprite = new StillSprite();
            textSprite = new TextSprite();
        }

        protected override void Update(GameTime gameTime)
        {
            myGameTime = gameTime;
            luigiSprite.Update();

            KeyboardController.Update();
            MouseController.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            textSprite.Draw(_spriteBatch, width, height, Content);
            luigiSprite.Draw(_spriteBatch, width, height, Content);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}