using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        public Texture2D spriteSheet;

        public ISprite marioSprite;
        public ISprite luigiSprite;
        
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
            KeyboardController = new KeyboardController();

            //Keyboard command mappings
            KeyboardController.RegisterCommand(Keys.D0, new Exit(this));
            KeyboardController.RegisterCommand(Keys.D9, new Reset(this));

            // Mario
            KeyboardController.RegisterCommand(Keys.W, new MarioJumpCommand(this));
            KeyboardController.RegisterCommand(Keys.A, new MarioMoveLeftCommand(this));
            KeyboardController.RegisterCommand(Keys.S, new MarioCrouchCommand(this));
            KeyboardController.RegisterCommand(Keys.D, new MarioMoveRightCommand(this));
            KeyboardController.RegisterCommand(Keys.E, new MarioChangeToFireCommand(this));

            // Luigi
            KeyboardController.RegisterCommand(Keys.I, new LuigiJump(this));
            KeyboardController.RegisterCommand(Keys.J, new LuigiLeft(this));
            KeyboardController.RegisterCommand(Keys.K, new LuigiCrouch(this));
            KeyboardController.RegisterCommand(Keys.L, new LuigiRight(this));


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load inital sprite states
            luigiSprite = new LuigiStill();
            marioSprite = new MarioStillLeft();

            // Load Texture
            spriteSheet = Content.Load<Texture2D>("SpriteImages/playerssclear");
        }

        protected override void Update(GameTime gameTime)
        {
            myGameTime = gameTime;

            luigiSprite.Update();
            marioSprite.Update();

            KeyboardController.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin();

            luigiSprite.Draw(_spriteBatch, Content);
            marioSprite.Draw(_spriteBatch, Content);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}