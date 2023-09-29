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

namespace Sprint0
{
    public class Sprint0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BlockSpriteFactory blockSpriteFactory;
        private List<BlockSprites> blockSprites;
        public int currentSpriteIndex, tempSpriteIndex;
        public TimeSpan spriteDelay, animationDelay;
        public TimeSpan timeSinceLastSprite, timeSinceLastAnimation;

        public ISprite marioSprite; // move into mario ICharacter
        public ICharacter mario;
        public Vector2 marioPosition; // move into mario ICharacter

        public ISprite luigiSprite;
        public ISprite blockSprite;
        
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
            SpriteController.RegisterCommand(Keys.T, new BlockPrev(this));
            SpriteController.RegisterCommand(Keys.Y, new BlockNext(this));


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            mario = new Mario(this);
            marioPosition.X = 150;
            marioPosition.Y = 150;

            marioSprite = new MarioLeftIdleSprite(this);

            

            // Load inital sprite states
            luigiSprite = new LuigiStill();
            //marioSprite = new MarioStillLeft();

            blockSpriteFactory = new BlockSpriteFactory();

            Texture2D blockTexture = Content.Load<Texture2D>("SpriteImages/blocks");
            List<Rectangle> spriteRectangles = new List<Rectangle>
            {
                // five different blocks
                new Rectangle(2076, 274, 32, 32),
                new Rectangle(2416, 2, 32, 32),
                new Rectangle(2280, 2, 32, 32),
                new Rectangle(2076, 70, 32, 32),
                new Rectangle(2008, 36, 32, 32),

                // frames for question mark block
                new Rectangle(2416, 2, 32, 32),
                new Rectangle(2314, 2, 32, 32),
                new Rectangle(2348, 2, 32, 32),
                new Rectangle(2382, 2, 32, 32),

                //frames for brick
                new Rectangle(2008, 36, 32, 32),
                new Rectangle(2110, 70, 32, 32),
                new Rectangle(2144, 70, 32, 32),
                new Rectangle(2178, 70, 32, 32)
            };
            blockSpriteFactory.AddSprite(blockTexture, spriteRectangles);

            blockSprites = blockSpriteFactory.sprites;
            currentSpriteIndex = 0;
            tempSpriteIndex = 0;
            spriteDelay = TimeSpan.FromMilliseconds(125);
            animationDelay = TimeSpan.FromMilliseconds(200);
            timeSinceLastSprite = TimeSpan.Zero;
            timeSinceLastAnimation = TimeSpan.Zero;

        }

        protected override void Update(GameTime gameTime)
        {
            myGameTime = gameTime;

            KeyboardController.Update();
            mario.Update();

            marioSprite.Update();
            blockSpriteFactory.Update();

            // switching blocks using t and y goes slower
            timeSinceLastSprite += gameTime.ElapsedGameTime;
            if (timeSinceLastSprite >= spriteDelay)
            {
                SpriteController.Update();
                timeSinceLastSprite = TimeSpan.Zero;
            }

            //timeSinceLastAnimation += gameTime.ElapsedGameTime;
            //if (timeSinceLastAnimation >= animationDelay)
            //{
            //    if(tempSpriteIndex > 4)
            //    {
            //        tempSpriteIndex++;
            //    }
            //    if(currentSpriteIndex == 1 && tempSpriteIndex == 9)
            //    {
            //        tempSpriteIndex = 5;
            //    }
            //    if (currentSpriteIndex == 4 && tempSpriteIndex == 13)
            //    {
            //        tempSpriteIndex = 9;
            //    }
            //    timeSinceLastAnimation = TimeSpan.Zero;
            //}

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin();
            luigiSprite.Draw(_spriteBatch, Content);
            marioSprite.Draw(_spriteBatch, Content);
            blockSprites[currentSpriteIndex].Draw(_spriteBatch, Content);
            
            //mario.Draw(_spriteBatch, Content); need to update parameters
            marioSprite.Draw(_spriteBatch, Content);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}