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
using Sprint0.Commands.Enemies;
using Sprint0.Blocks;
using System;
using System.ComponentModel;
using Sprint0.Enemies;
using System.Collections.Generic;
using Sprint0.Items;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0
{
    public class Sprint0 : Game
    {
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BlockSpriteFactory spriteFactory;
        public GameTime gametime;

        public static int ScreenWidth;
        public static int ScreenHeight;

        public Camera camera;

        public ICharacter mario;
        public ICharacter luigi;

        public ISprite blockSprite;
        public Item item;

        public Block block;
        public TimeSpan spriteDelay, timeSinceLastSprite;

        //List just for demo
        public List<IEnemies> enemyList = new List<IEnemies>();
        public int enemyIndex;
        public IEnemies enemies;

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

            ScreenWidth = _graphics.PreferredBackBufferWidth;
            ScreenHeight = _graphics.PreferredBackBufferHeight;

            camera = new Camera();
            
            mario = new Mario(this);
            luigi = new Luigi(this);

            //List used for demo cycling
            enemyList.Add(new Goomba(this));
            enemyList.Add(new HammerBro(this));
            enemyList.Add(new Koopa(this));
            enemies = enemyList[enemyIndex];

            item = new Item(this, gametime);

            KeyboardController = new KeyboardController(this);

            SpriteController = new KeyboardController(this);
            /*
            //Keyboard command mappings
            KeyboardController.RegisterCommand(Keys.Escape, new Exit(this));
            */
            KeyboardController.RegisterCommand(Keys.D0, new Reset(this, gametime, Content));

            //Blocks
            SpriteController.RegisterCommand(Keys.T, new BlockPrev(block));
            SpriteController.RegisterCommand(Keys.Y, new BlockNext(block));

            // Items
            SpriteController.RegisterCommand(Keys.V, new previousItem(item));
            SpriteController.RegisterCommand(Keys.B, new nextItem(item));

            //Enemies
            SpriteController.RegisterCommand(Keys.O, new EnemyPrev(this));
            SpriteController.RegisterCommand(Keys.P, new EnemyNext(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            item.LoadItems();
            block.LoadBlocks();

            spriteDelay = TimeSpan.FromMilliseconds(125);
            timeSinceLastSprite = TimeSpan.Zero;

        }

        protected override void Update(GameTime gameTime)
        {

            KeyboardController.Update();
            //Just for demo
            enemies = enemyList[enemyIndex];
            mario.Update(gameTime);
            luigi.Update(gameTime);

            enemies.Update(gameTime);

            item.Update(gameTime);
            item.UpdatePos(gameTime);

            // switching blocks using t and y goes slower
            timeSinceLastSprite += gameTime.ElapsedGameTime;
            if (timeSinceLastSprite >= spriteDelay)
            {
                SpriteController.Update();
                timeSinceLastSprite = TimeSpan.Zero;
            }
            block.Update(gameTime);

            camera.follow(luigi);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin(transformMatrix: camera.transform);

            mario.Draw(_spriteBatch);
            luigi.Draw(_spriteBatch);
            block.Draw();
            item.Draw(_spriteBatch);
            enemies.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
