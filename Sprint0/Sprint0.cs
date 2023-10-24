using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Background;
using Sprint0.Blocks;
using Sprint0.Camera;
using Sprint0.Collision;
using Sprint0.Commands;
using Sprint0.Commands.Blocks;
using Sprint0.Controllers;
using Sprint0.Enemies;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using Sprint0.Items;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
namespace Sprint0
{
    public class Sprint0 : Game
    {
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BlockSpriteFactory spriteFactory;
        public GameTime gametime;
        public ObjectManager objects;

        private LevelLoader1 levelLoader;
        Camera1 camera;
        public Terrain terrain;

        public ISprite blockSprite;
        public Item item;

        public TimeSpan spriteDelay, timeSinceLastSprite;

        IController KeyboardController;
        IController SpriteController;

        CollisionHandler collision; 

        public Sprint0()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //camera = new Camera1(GraphicsDevice.Viewport);

            
            objects = new ObjectManager(this);

            terrain = new Terrain(this);

            item = new Item(this, gametime);

            KeyboardController = new KeyboardController(this);

            SpriteController = new KeyboardController(this);
            /*
            //Keyboard command mappings
            KeyboardController.RegisterCommand(Keys.Escape, new Exit(this));
            */
            KeyboardController.RegisterCommand(Keys.D0, new Reset(this, gametime, Content));


            // Items
            SpriteController.RegisterCommand(Keys.V, new previousItem(item));
            SpriteController.RegisterCommand(Keys.B, new nextItem(item));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            item.LoadItems();

            levelLoader = new LevelLoader1(this, _spriteBatch, Content);
            levelLoader.Load("JSON/level1.json");

            // collision
            collision = new CollisionHandler(this, objects);

            spriteDelay = TimeSpan.FromMilliseconds(125);
            timeSinceLastSprite = TimeSpan.Zero;

        }

        protected override void Update(GameTime gameTime)
        {

            KeyboardController.Update();
            //Just for demo
            

            terrain.Update(gameTime);

            objects.Update(gameTime, collision);

            item.Update(gameTime);
            item.UpdatePos(gameTime);

            // switching blocks using t and y goes slower
            timeSinceLastSprite += gameTime.ElapsedGameTime;
            if (timeSinceLastSprite >= spriteDelay)
            {
                SpriteController.Update();
                timeSinceLastSprite = TimeSpan.Zero;
            }

            //camera.Update(gameTime, objects.mario);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin(/*SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform*/);

            terrain.Draw(_spriteBatch);
            objects.Draw(_spriteBatch);
            item.Draw(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
