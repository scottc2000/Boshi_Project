using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Background;
using Sprint0.Camera;
using Sprint0.Characters;
using Sprint0.Collision;
using Sprint0.Controllers;
using Sprint0.Enemies;
using Sprint0.GameMangager;
using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactories;
using Sprint0.Utility;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameTime gametime;
        private FileNames filename;
        private PlayerNumbers p;

        public ObjectManager objects;
        public GameStats hud;
        public Title title;
        public GameStates gamestates { get; set; }
        public Triggers triggers;
        public AudioManager audioManager;
        private IController KeyboardController;

        public LevelLoader1 levelLoader; // change back to private later
        public PlayerCamera camera;
        public IPlayer luigi;
        public IPlayer mario;

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
            p = new PlayerNumbers();

            mario = new Player(this, p.mario);
            luigi = new Player(this, p.luigi);

            hud = new GameStats(this);
            title = new Title(this);
            gamestates = GameStates.TITLE;

            // Initialize game components
            camera = new PlayerCamera(GraphicsDevice.Viewport);
            objects = new ObjectManager(this);
            levelLoader = new LevelLoader1(this, _spriteBatch, Content, camera, mario, luigi, hud);
            triggers = new Triggers(this);
            KeyboardController = new KeyboardController(this, mario, luigi, hud);

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
            switch (gamestates)
            {
                case GameStates.TITLE:
                    KeyboardController.Update();
                    title.Update(gameTime);
                    break;
                case GameStates.PLAY:
                    KeyboardController.Update();
                    levelLoader.Update(gameTime);
                    hud.Update(gameTime);
                    triggers.Detect();
                    detector.DetectCollision();
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);


            switch (gamestates)
            {
                case GameStates.TITLE:
                    _spriteBatch.Begin();
                    title.Draw(_spriteBatch);
                    _spriteBatch.End();
                    break;
                case GameStates.PLAY:
                    _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                        null, null, null, null, camera.transform);
                    levelLoader.Draw(_spriteBatch);
                    _spriteBatch.End();

                    _spriteBatch.Begin();
                    hud.Draw(_spriteBatch);
                    _spriteBatch.End();
                    break;

            }
           
            base.Draw(gameTime);
        }

    }
}
