using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using Sprint0.Background;
using Sprint0.Camera;
using Sprint0.Collision;
using Sprint0.Controllers;
using Sprint0.Enemies;
using Sprint0.GameMangager;
using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactories;
using Sprint0.Utility;
using System;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameTime gametime;
        private FileNames filename;
        
        public ObjectManager objects;
        public GameStats hud;

        public Triggers triggers;
        public AudioManager audioManager;
        public ScrnManager screenManager;

        public LevelLoader1 levelLoader; // change back to private later
        public Camera.PlayerCamera camera;
        public static int ScreenWidth;
        public static int ScreenHeight;

        private CollisionDetector detector; 

        public Sprint0()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            filename = new FileNames();
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            hud = new GameStats(this);

            // Initialize game components
            camera = new PlayerCamera(GraphicsDevice.Viewport);
            objects = new ObjectManager(this);
            levelLoader = new LevelLoader1(this, _spriteBatch, Content, camera, hud);
            triggers = new Triggers(this);

            audioManager = AudioManager.Instance;
            screenManager = new ScrnManager(this, _spriteBatch);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            audioManager.Load(Content);

            levelLoader.Load(filename.levelData);

            ItemSpriteFactory.Instance.LoadTextures(Content);
            BlockSpriteFactory.Instance.LoadTextures(Content);
            BlockSpriteFactory.Instance.LoadSpriteLocations();

            // collision
            detector = new CollisionDetector(this, objects);
        }

        protected override void Update(GameTime gameTime)
        {
            levelLoader.Update(gameTime);
            hud.Update(gameTime);
            triggers.Detect();
            detector.DetectCollision();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, 
                null, null, null, null, camera.transform);

            screenManager.Draw();
            _spriteBatch.End();

            _spriteBatch.Begin();
            
            hud.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
