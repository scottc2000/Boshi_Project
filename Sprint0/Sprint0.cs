using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Characters;
using Sprint0.Commands;
using Sprint0.Commands.Luigi;
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
        public ISprite luigiSprite;

        public ICharacter mario;
        public Luigi luigi;

        public Vector2 marioPosition; // move into mario ICharacter

        ISprite textSprite;
        public KeyboardController KeyboardController;
   
        public GameTime myGameTime;

        public Sprint0()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            KeyboardController = new KeyboardController(this); // creates new keyboard controller

            //Keyboard command mappings
            KeyboardController.RegisterCommand(Keys.D0, new Exit(this));
            KeyboardController.RegisterCommand(Keys.D9, new Reset(this));

            // Mario
            //KeyboardController.RegisterCommand(Keys.W, new CMarioJump(this));
            //KeyboardController.RegisterCommand(Keys.A, new CMarioMoveLeft(this));
            //KeyboardController.RegisterCommand(Keys.S, new CMarioCrouch(this));
            //KeyboardController.RegisterCommand(Keys.D, new CMarioMoveRight(this));
            //KeyboardController.RegisterCommand(Keys.Z, new CMarioLeftIdle(this));
            // KeyboardController.RegisterCommand(Keys.X, new CMarioRightIdle(this));
            // KeyboardController.RegisterCommand(Keys.Q, new CMarioFire(this));
            // KeyboardController.RegisterCommand(Keys.E, new CMarioStar(this));

            //Luigi controlss
            KeyboardController.RegisterCommand(Keys.J, new LuigiLeft(this));
            KeyboardController.RegisterCommand(Keys.L, new LuigiRight(this));
            KeyboardController.RegisterCommand(Keys.K, new LuigiCrouch(this));
            KeyboardController.RegisterCommand(Keys.I, new LuigiJump(this));
            KeyboardController.RegisterCommand(Keys.M, new LuigiAttack(this));
            KeyboardController.RegisterCommand(Keys.D6, new LuigiNormal(this));
            KeyboardController.RegisterCommand(Keys.D7, new LuigiBig(this));
            KeyboardController.RegisterCommand(Keys.D8, new LuigiFire(this));


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //  mario = new Mario(this);

            luigi = new Luigi(this); // create new luigi character 
            
            //marioPosition.X = 150;
            //marioPosition.Y = 150;

            //marioSprite = new MarioLeftIdleSprite(this);
            // luigiSprite = new LuigiStill();

        }

        protected override void Update(GameTime gameTime)
        {
            myGameTime = gameTime;

            // updates what is currently pressed, then updates luigi character
            KeyboardController.Update();
            luigi.Update();


            //mario.Update(gameTime);


            //marioSprite.Update();
            //luigi.Update();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin();

            //mario.Draw(_spriteBatch, Content); need to update parameters


            luigi.Draw(_spriteBatch, Content);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}