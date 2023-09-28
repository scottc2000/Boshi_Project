using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Commands.Mario;
using Sprint0.Commands.Blocks;
using Sprint0.Controllers;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System.Collections.Generic;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BlockSpriteFactory blockSpriteFactory;
        private List<BlockSprites> blockSprites;
        public int currentSpriteIndex;

        public ISprite marioSprite;
        public ISprite luigiSprite;
        public ISprite blockSprite;
        
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
            KeyboardController.RegisterCommand(Keys.W, new MarioJump(this));
            KeyboardController.RegisterCommand(Keys.A, new MarioCommandMoveLeft(this));
            KeyboardController.RegisterCommand(Keys.S, new MarioCrouch(this));
            KeyboardController.RegisterCommand(Keys.D, new MarioCommandMoveRight(this));

            // Luigi
            KeyboardController.RegisterCommand(Keys.I, new LuigiJump(this));
            KeyboardController.RegisterCommand(Keys.J, new LuigiLeft(this));
            KeyboardController.RegisterCommand(Keys.K, new LuigiCrouch(this));
            KeyboardController.RegisterCommand(Keys.L, new LuigiRight(this));

            //Blocks
            KeyboardController.RegisterCommand(Keys.T, new BlockPrev(this));
            KeyboardController.RegisterCommand(Keys.Y, new BlockNext(this));


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            

            // Load inital sprite states
            luigiSprite = new LuigiStill();
            marioSprite = new MarioStillLeft();

            blockSpriteFactory = new BlockSpriteFactory();

            Texture2D blockTexture = Content.Load<Texture2D>("SpriteImages/blocks");
            List<Rectangle> spriteRectangles = new List<Rectangle>
            {
                new Rectangle(2076, 274, 32, 32),
                new Rectangle(2416, 2, 32, 32),
                new Rectangle(2280, 2, 32, 32),
                new Rectangle(2076, 2, 32, 32),
                new Rectangle(2008, 36, 32, 32)
            };
            blockSpriteFactory.AddSprite(blockTexture, spriteRectangles);

            blockSprites = blockSpriteFactory.sprites;
            currentSpriteIndex = 0;

        }

        protected override void Update(GameTime gameTime)
        {
            myGameTime = gameTime;

            luigiSprite.Update();
            marioSprite.Update();
            blockSpriteFactory.Update();

            KeyboardController.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin();

            luigiSprite.Draw(_spriteBatch, Content);
            marioSprite.Draw(_spriteBatch, Content);
            blockSprites[currentSpriteIndex].Draw(_spriteBatch, Content);
            

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}