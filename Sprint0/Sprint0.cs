using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Camera;
using Sprint0.Collision;
using Sprint0.Controllers;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using Sprint0.SFX;
using System;
using System.Drawing;
using System.Reflection.Metadata;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public GameTime gametime;
        public ObjectManager objects;
        public AudioManager audioManager;

        private LevelLoader1 levelLoader;
        public MarioCamera camera;
        public static int ScreenWidth;
        public static int ScreenHeight;

        public TimeSpan spriteDelay, timeSinceLastSprite;

        IController KeyboardController;

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
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;

            camera = new MarioCamera(GraphicsDevice.Viewport);
            objects = new ObjectManager(this, camera);
            audioManager = AudioManager.Instance;

            KeyboardController = new KeyboardController(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            audioManager.Load();

            levelLoader = new LevelLoader1(this, _spriteBatch, Content);
            levelLoader.Load("JSON/level1.json");

            ItemSpriteFactory.Instance.LoadTextures(Content);
            // collision
            collision = new CollisionHandler(this, objects);
        }

        protected override void Update(GameTime gameTime)
        {

            KeyboardController.Update();;

            objects.Update(gameTime, collision);

            //camera.Update(gameTime, objects.mario);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.LightSlateGray);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, 
                null, null, null, null, camera.transform);

            objects.Draw(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
