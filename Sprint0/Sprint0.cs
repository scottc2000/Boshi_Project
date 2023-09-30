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

        public ISprite marioSprite;
        public ISprite luigiSprite;
        
        ISprite textSprite;
        IController KeyboardController;

        public Item item;
        public GameTime myGameTime;

        const int width = 475;
        const int height = 300;

        public Sprint0()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            KeyboardController = new KeyboardController();
            item = new Item(this);

            //Keyboard command mappings
            KeyboardController.RegisterCommand(Keys.D0, new Exit(this));
            KeyboardController.RegisterCommand(Keys.W, new playerJump(this));
            KeyboardController.RegisterCommand(Keys.A, new playerLeft(this));
            KeyboardController.RegisterCommand(Keys.S, new playerCrouch(this));
            KeyboardController.RegisterCommand(Keys.D, new playerRight(this));

            KeyboardController.RegisterCommand(Keys.U, new previousItem(item));
            KeyboardController.RegisterCommand(Keys.I, new nextItem(item));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            item.LoadItems();

        }

        protected override void Update(GameTime gameTime)
        {
            item.Update(gameTime);
            item.UpdatePos(gameTime);

            KeyboardController.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin();

            // textSprite.Draw(_spriteBatch, Content);
            //luigiSprite.Draw(_spriteBatch);
            item.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}