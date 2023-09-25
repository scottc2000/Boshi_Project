using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Controllers;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.Item_Sprites;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public ISprite marioSprite;
        public ISprite luigiSprite;
        public ISprite itemSprite;
        
        ISprite textSprite;
        IController KeyboardController;
   
        public GameTime myGameTime;

        public int currentItemSprite = 0;
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

            //Keyboard command mappings
            KeyboardController.RegisterCommand(Keys.D0, new Exit(this));
            KeyboardController.RegisterCommand(Keys.W, new playerJump(this));
            KeyboardController.RegisterCommand(Keys.A, new playerLeft(this));
            KeyboardController.RegisterCommand(Keys.S, new playerCrouch(this));
            KeyboardController.RegisterCommand(Keys.D, new playerRight(this));

            KeyboardController.RegisterCommand(Keys.U, new previousItem(this));
            KeyboardController.RegisterCommand(Keys.I, new nextItem(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            luigiSprite = new StillSprite();
            itemSprite = new RedMushroom();
            textSprite = new TextSprite();
        }

        protected override void Update(GameTime gameTime)
        {
            myGameTime = gameTime;
            luigiSprite.Update();
            itemSprite.Update();

            KeyboardController.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin();

            // textSprite.Draw(_spriteBatch, Content);
            luigiSprite.Draw(_spriteBatch, Content);
            itemSprite.Draw(_spriteBatch, Content);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}