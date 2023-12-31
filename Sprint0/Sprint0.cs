﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Camera;
using Sprint0.Collision;
using Sprint0.Controllers;
using Sprint0.GameMangager;
using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactories;
using Sprint0.Utility;
using System;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameTime gametime;
        private FileNames filename;
        
        public ObjectManager objects;
        public GameStats stats;
        public AudioManager audioManager;

        public LevelLoader1 levelLoader; // change back to private later
        public MarioCamera camera;
        public static int ScreenWidth;
        public static int ScreenHeight;
       
        private IController KeyboardController;

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

            // May be removed later if not needed
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;

            // Initialize game components
            camera = new MarioCamera(GraphicsDevice.Viewport);
            objects = new ObjectManager(this);
            levelLoader = new LevelLoader1(this, _spriteBatch, Content, camera);
            KeyboardController = new KeyboardController(this, levelLoader);

            audioManager = AudioManager.Instance;

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
            KeyboardController.Update();
            levelLoader.Update(gameTime);
            detector.DetectCollision();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, 
                null, null, null, null, camera.transform);

            levelLoader.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
