﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Background;
using Sprint0.Blocks;
using Sprint0.Cam;
using Sprint0.Characters;
using Sprint0.Commands;
using Sprint0.Commands.Blocks;
using Sprint0.Commands.Enemies;
using Sprint0.Controllers;
using Sprint0.Enemies;
using Sprint0.Interfaces;
using Sprint0.Items;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using Sprint0.LevelLoader;
namespace Sprint0
{
    public class Sprint0 : Game
    {
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BlockSpriteFactory spriteFactory;
        public GameTime gametime;

        private LevelLoader1 levelLoader;
        public Terrain terrain;
        public Camera cam;

        public ICharacter mario;
        public ICharacter luigi;

        public List<IBlock> blockList;
        public ISprite blockSprite;
        public Item item;

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
            

            mario = new Mario(this);
            luigi = new Luigi(this);
            terrain = new Terrain(this);

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
            

            levelLoader = new LevelLoader1(this, _spriteBatch, Content);
            levelLoader.Load("JSON/level1.json");

            spriteDelay = TimeSpan.FromMilliseconds(125);
            timeSinceLastSprite = TimeSpan.Zero;

        }

        protected override void Update(GameTime gameTime)
        {

            KeyboardController.Update();
            //Just for demo
            enemies = enemyList[enemyIndex];

            terrain.Update(gameTime);
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
            blockList = levelLoader.getBlockList();
            foreach (IBlock block in blockList)
            {
                block.Update(gameTime);
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin();

            terrain.Draw(_spriteBatch);
            mario.Draw(_spriteBatch);
            luigi.Draw(_spriteBatch);
            blockList = levelLoader.getBlockList();
            foreach(IBlock block in blockList)
            {
                block.Draw(_spriteBatch);
            }
            item.Draw(_spriteBatch);
            enemies.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
