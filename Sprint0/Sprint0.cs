using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Background;
using Sprint0.Camera;
using Sprint0.Collision;
using Sprint0.Controllers;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using System;
using System.Security.Cryptography;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameTime gametime;
        
        public ObjectManager objects;
        public AudioManager audioManager;
        public ScreenManager screens;

        private LevelLoader1 levelLoader;
        public MarioCamera camera;
        public static int ScreenWidth;
        public static int ScreenHeight;
       
        private IController KeyboardController;

        private CollisionHandler collision; 

        public Sprint0()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // May be removed later if not needed
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;

            // Initialize game components
            camera = new MarioCamera(GraphicsDevice.Viewport);
            objects = new ObjectManager(this, camera);
            KeyboardController = new KeyboardController(this);

            audioManager = AudioManager.Instance;

            base.Initialize();
            screens = new ScreenManager(this);
        }

        protected override void LoadContent()
        {
            audioManager.Load(Content);

            // load level
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, 
                null, null, null, null, camera.transform);

            screens.Draw(_spriteBatch);

            objects.Draw(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
