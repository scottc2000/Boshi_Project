using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Sprint0.Characters;
using Sprint0.Commands;
using Sprint0.Commands.Mario;
using Sprint0.Controllers;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Commands.Blocks;
using Sprint0.Blocks;
using System;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BlockSpriteFactory spriteFactory;
  
        public ICharacter mario;
        public ICharacter luigi;

        public ISprite blockSprite;

        public Block block;
        public TimeSpan spriteDelay, timeSinceLastSprite;

        IController KeyboardController;
        IController SpriteController;

        
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

            KeyboardController = new KeyboardController(this);
            SpriteController = new KeyboardController (this);

            //Keyboard command mappings
            KeyboardController.RegisterCommand(Keys.Escape, new Exit(this));
            KeyboardController.RegisterCommand(Keys.D0, new Reset(this));

            // Mario
            KeyboardController.RegisterCommand(Keys.W, new CMarioJump(this));
            KeyboardController.RegisterCommand(Keys.A, new CMarioMoveLeft(this));
            KeyboardController.RegisterCommand(Keys.S, new CMarioCrouch(this));
            KeyboardController.RegisterCommand(Keys.D, new CMarioMoveRight(this));
            KeyboardController.RegisterCommand(Keys.E, new CMarioThrow(this));      // Still needs projectile

            KeyboardController.RegisterCommand(Keys.D5, new CDeadMario(this));
            KeyboardController.RegisterCommand(Keys.D4, new CMarioRaccoon(this));
            KeyboardController.RegisterCommand(Keys.D3, new CMarioFire(this));
            KeyboardController.RegisterCommand(Keys.D2, new CMarioBig(this));
            KeyboardController.RegisterCommand(Keys.D1, new CMarioNormal(this));

            //Luigi
            /*
            KeyboardController.RegisterCommand(Keys.I, new CLuigiJump(this));
            KeyboardController.RegisterCommand(Keys.J, new CLuigiMoveLeft(this));
            KeyboardController.RegisterCommand(Keys.K, new CLuigiCrouch(this));
            KeyboardController.RegisterCommand(Keys.L, new CLuigiMoveRight(this));

            KeyboardController.RegisterCommand(Keys.D8, new CLuigiRaccoon(this));
            KeyboardController.RegisterCommand(Keys.D7, new CLuigiFire(this));
            KeyboardController.RegisterCommand(Keys.D6, new CLuigiBig(this));
            KeyboardController.RegisterCommand(Keys.D5, new CLuigiNormal(this));
            */



            //Blocks
            SpriteController.RegisterCommand(Keys.T, new BlockPrev(block));
            SpriteController.RegisterCommand(Keys.Y, new BlockNext(block));

            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            

            mario = new Mario(this);
            // luigi = new Luigi(this);

            spriteDelay = TimeSpan.FromMilliseconds(125);
            timeSinceLastSprite = TimeSpan.Zero;

        }

        protected override void Update(GameTime gameTime)
        {

            KeyboardController.Update();
            mario.Update(gameTime);
            // luigi.Update(gameTime)


            // switching blocks using t and y goes slower
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

            mario.Draw(_spriteBatch);
            block.Draw();

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}