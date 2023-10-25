using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Background;
using Sprint0.Collision;
using Sprint0.Commands;
using Sprint0.Controllers;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using Sprint0.Items;
using System;
namespace Sprint0
{
    public class Sprint0 : Game
    {
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public GameTime gametime;
        public ObjectManager objects;

        private LevelLoader1 levelLoader;
        //Camera1 camera;
        public Terrain terrain;

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
            terrain = new Terrain(this);
            objects = new ObjectManager(this);


            KeyboardController = new KeyboardController(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {

            levelLoader = new LevelLoader1(this, _spriteBatch, Content);
            levelLoader.Load("JSON/level1.json");

            // collision
            collision = new CollisionHandler(this, objects);

        }

        protected override void Update(GameTime gameTime)
        {

            KeyboardController.Update();

            terrain.Update(gameTime);

            objects.Update(gameTime, collision);

            //camera.Update(gameTime, objects.mario);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin(/*SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform*/);

            terrain.Draw(_spriteBatch);
            objects.Draw(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
