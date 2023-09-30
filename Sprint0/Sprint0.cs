using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Characters;
using Sprint0.Commands;
using Sprint0.Commands.Mario;
using Sprint0.Commands.Blocks;
using Sprint0.Controllers;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System.Collections.Generic;
using System;
using Sprint0.Blocks;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BlockSpriteFactory spriteFactory;
        

        public ISprite marioSprite; // move into mario ICharacter
        public ICharacter mario;
        public Vector2 marioPosition; // move into mario ICharacter

        public ISprite luigiSprite;
        public ISprite blockSprite;

        public Block block;
        public TimeSpan spriteDelay, timeSinceLastSprite;

        ISprite textSprite;
        IController KeyboardController;
        IController SpriteController;
   
        public GameTime myGameTime;

        
        public Sprint0()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            block = new Block(this, _spriteBatch, Content);
            block.LoadBlocks();

            KeyboardController = new KeyboardController();
            SpriteController = new KeyboardController ();

            //Keyboard command mappings
            KeyboardController.RegisterCommand(Keys.D0, new Exit(this));
            KeyboardController.RegisterCommand(Keys.D9, new Reset(this));

            // Mario
            KeyboardController.RegisterCommand(Keys.W, new CMarioJump(this));
            KeyboardController.RegisterCommand(Keys.A, new CMarioMoveLeft(this));
            KeyboardController.RegisterCommand(Keys.S, new CMarioCrouch(this));
            KeyboardController.RegisterCommand(Keys.D, new CMarioMoveRight(this));
            KeyboardController.RegisterCommand(Keys.Z, new CMarioLeftIdle(this));
            // KeyboardController.RegisterCommand(Keys.X, new CMarioRightIdle(this));
            // KeyboardController.RegisterCommand(Keys.Q, new CMarioFire(this));
            // KeyboardController.RegisterCommand(Keys.E, new CMarioStar(this));

            // Luigi
            KeyboardController.RegisterCommand(Keys.I, new LuigiJump(this));
            KeyboardController.RegisterCommand(Keys.J, new LuigiLeft(this));
            KeyboardController.RegisterCommand(Keys.K, new LuigiCrouch(this));
            KeyboardController.RegisterCommand(Keys.L, new LuigiRight(this));

            //Blocks
            KeyboardController.RegisterCommand(Keys.T, new DoNothing(this));
            KeyboardController.RegisterCommand(Keys.Y, new DoNothing(this));
            SpriteController.RegisterCommand(Keys.T, new BlockPrev(block));
            SpriteController.RegisterCommand(Keys.Y, new BlockNext(block));

            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            

            mario = new Mario(this);
            marioPosition.X = 150;
            marioPosition.Y = 150;

            marioSprite = new MarioLeftIdleSprite(this);

            

            // Load inital sprite states
            luigiSprite = new LuigiStill();
            //marioSprite = new MarioStillLeft();

            spriteDelay = TimeSpan.FromMilliseconds(125);
            timeSinceLastSprite = TimeSpan.Zero;

        }

        protected override void Update(GameTime gameTime)
        {
            myGameTime = gameTime;

            KeyboardController.Update();
            mario.Update();

            //marioSprite.Update();
            timeSinceLastSprite += gameTime.ElapsedGameTime;
            if (timeSinceLastSprite >= spriteDelay)
            {
                SpriteController.Update();
                timeSinceLastSprite = TimeSpan.Zero;
            }
            block.Update(gameTime);
            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin();
            //luigiSprite.Draw(_spriteBatch, Content);
            //marioSprite.Draw(_spriteBatch, Content);

            block.Draw();

            //mario.Draw(_spriteBatch, Content); need to update parameters
            //marioSprite.Draw(_spriteBatch, Content);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}