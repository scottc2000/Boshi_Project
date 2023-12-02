﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Background;
using Sprint0.Blocks;
using Sprint0.Camera;
using Sprint0.Commands;
using Sprint0.Enemies;
using Sprint0.GameMangager;
using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Items;
using System.IO;
using System.Linq;
using System.Text.Json;
using static Sprint0.LevelLoader.Level1Data;
using Item = Sprint0.LevelLoader.Level1Data.Item;

namespace Sprint0
{

    public class LevelLoader1
    {
        private Sprint0 sprint0;
        private SpriteBatch spriteBatch;
        private ContentManager content;
        private Root data;

        public PlayerCamera camera;
        public IPlayer mario;
        public IPlayer luigi;
        private Terrain terrain;
        private ICommand added;

        public ObjectManager objectManager;
        private AudioManager audioManager = AudioManager.Instance;

        public LevelLoader1(Sprint0 sprint0, SpriteBatch spriteBatch, ContentManager content, PlayerCamera camera, IPlayer mario, IPlayer luigi, GameStats hud)
        {
            this.sprint0 = sprint0;
            objectManager = sprint0.objects;

            this.camera = camera;
            this.mario = mario;
            this.luigi = luigi;

            this.spriteBatch = spriteBatch;
            this.content = content;

            terrain = new Terrain(sprint0);
        }
        public void Load(string jsonFilePath)
        {
            // Deserialize json file
            string json = File.ReadAllText(jsonFilePath);
            data = JsonSerializer.Deserialize<Root>(json);

            Load(data);
            audioManager.PlayMusic(data.Songs[0].Name);
        }

        public void Load(Root data)
        {
            // Load all blocks from the JSON file to objectManager
            foreach (Block block in data.Blocks)
            {
                Rectangle blockRectangle = new Rectangle(block.x, block.y, block.width, block.height);
                switch (block.Name)
                {
                    case "death_zone":
                        DeathZone death_zone = new DeathZone(spriteBatch, blockRectangle);
                        objectManager.Blocks.Add(death_zone);
                        objectManager.ThroughCollidableBlocks.Add(death_zone);
                        objectManager.StaticEntities.Add(death_zone);
                        break;
                    case "floor":
                        Floor floor = new Floor(spriteBatch, blockRectangle);
                        objectManager.Blocks.Add(floor);
                        objectManager.TopCollidableBlocks.Add(floor);
                        objectManager.SideCollidableBlocks.Add(floor);
                        objectManager.StaticEntities.Add(floor);
                        break;
                    case "large_block":
                        LargeBlock large_block = new LargeBlock(spriteBatch, blockRectangle);
                        objectManager.Blocks.Add(large_block);
                        objectManager.TopCollidableBlocks.Add(large_block);
                        objectManager.StaticEntities.Add(large_block);
                        break;
                    case "yellow_brick":
                        YellowBrick yellow_brick = new YellowBrick(spriteBatch, blockRectangle);
                        objectManager.Blocks.Add(yellow_brick);
                        objectManager.TopCollidableBlocks.Add(yellow_brick);
                        objectManager.BottomCollidableBlocks.Add(yellow_brick);
                        objectManager.SideCollidableBlocks.Add(yellow_brick);
                        objectManager.StaticEntities.Add(yellow_brick);
                        break;
                    case "wood_blocks":
                        WoodBlocks wood_blocks = new WoodBlocks(spriteBatch, blockRectangle);
                        objectManager.Blocks.Add(wood_blocks);
                        objectManager.TopCollidableBlocks.Add(wood_blocks);
                        objectManager.BottomCollidableBlocks.Add(wood_blocks);
                        objectManager.SideCollidableBlocks.Add(wood_blocks);
                        objectManager.StaticEntities.Add(wood_blocks);
                        break;
                    case "clouds":
                        Clouds clouds = new Clouds(spriteBatch, blockRectangle);
                        objectManager.Blocks.Add(clouds);
                        objectManager.TopCollidableBlocks.Add(clouds);
                        objectManager.StaticEntities.Add(clouds);
                        break;
                    case "pipe":
                        Pipe pipe = new Pipe(spriteBatch, blockRectangle);
                        objectManager.Blocks.Add(pipe);
                        objectManager.TopCollidableBlocks.Add(pipe);
                        objectManager.SideCollidableBlocks.Add(pipe);
                        objectManager.StaticEntities.Add(pipe);
                        break;
                    case "question_block":
                        QuestionBlock question_block = new QuestionBlock(spriteBatch, content, blockRectangle, block.item);
                        objectManager.Blocks.Add(question_block);
                        objectManager.TopCollidableBlocks.Add(question_block);
                        objectManager.BottomCollidableBlocks.Add(question_block);
                        objectManager.SideCollidableBlocks.Add(question_block);
                        objectManager.DynamicEntities.Add(question_block);
                        break;
                    case "spinning_coin":
                        SpinningCoin spinning_coin = new SpinningCoin(spriteBatch, blockRectangle);
                        objectManager.Blocks.Add(spinning_coin);
                        objectManager.ThroughCollidableBlocks.Add(spinning_coin);
                        objectManager.DynamicEntities.Add(spinning_coin);
                        break;
                }
            }

            // Load all items from JSON file to object manager
            foreach (Item item in data.Items)
            {
                switch (item.Name)
                {
                    case "RedMushroom":
                        IItem RedMushroom = new RedMushroom();
                        RedMushroom.setPosition(item.Position);
                        added = new CAddDynamic(RedMushroom, objectManager);
                        added.Execute();
                        break;
                    case "OneUpMushroom":
                        IItem OneUpMushroom = new OneUpMushroom();
                        OneUpMushroom.setPosition(item.Position);
                        added = new CAddDynamic(OneUpMushroom, objectManager);
                        added.Execute();
                        break;
                    case "FireFlower":
                        IItem FireFlower = new FireFlower();
                        FireFlower.setPosition(item.Position);
                        added = new CAddDynamic (FireFlower, objectManager);
                        added.Execute();
                        break;
                    case "Leaf":
                        IItem Leaf = new Leaf();
                        Leaf.setPosition(item.Position);
                        break;
                    case "Star":
                        IItem Star = new Star();
                        Star.setPosition(item.Position);
                        break;
                    case "Frog":
                        IItem Frog = new Frog();
                        Frog.setPosition(item.Position);
                        break;
                    case "Tanooki":
                        IItem Tanooki = new Tanooki();
                        Tanooki.setPosition(item.Position);
                        break;
                    case "Hammer":
                        IItem Hammer = new Hammer();
                        Hammer.setPosition(item.Position);
                        break;
                    case "Shoe":
                        IItem Shoe = new Shoe();
                        Shoe.setPosition(item.Position);
                        break;
                }
            }

            // Load all enemies from JSON file to object manager
            foreach (Enemy enemy in data.Enemies)
            {
                if (enemy.Name == "Goomba")
                {
                    IEnemies goomba = new Goomba(sprint0);
                    goomba.SetPosition(enemy.Position);
                    added = new CAddDynamic(goomba, objectManager);
                    added.Execute();
                }
                if (enemy.Name == "Koopa")
                {
                    IEnemies koopa = new Koopa(sprint0);
                    koopa.SetPosition(enemy.Position);
                    added = new CAddDynamic(koopa, objectManager);
                    added.Execute();
                }
            }
            added = new CAddDynamic(mario, objectManager);
            added.Execute();
            added = new CAddDynamic(luigi, objectManager);
            added.Execute();

            objectManager.Projectiles.Add(mario.fireProjectile);
            objectManager.Projectiles.Add(luigi.fireProjectile);

        }

        public void Update(GameTime gameTime)
        {
            terrain.Update(gameTime);   // need to update terrain before any game objects

            // Update each game object
            foreach (var block in objectManager.Blocks)
            {
                block.Update(gameTime);
            }
            foreach (var item in objectManager.Items.ToList())
            {
                item.Update(gameTime);
            }
            foreach (var enemy in objectManager.Enemies)
            {
                enemy.Update(gameTime);
            }
            foreach (var proj in objectManager.Projectiles)
            {
                proj.Update(gameTime);
            }

            objectManager.Update();
            camera.Update(mario, luigi);
            mario.Update(gameTime);
            luigi.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            terrain.Draw(spriteBatch); // need to draw terrain before any game objects

            // Draw each game object
            foreach (var block in objectManager.Blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (var item in objectManager.Items)
            {
                item.Draw(spriteBatch);
            }
            foreach (var enemy in objectManager.Enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (var proj in objectManager.Projectiles)
            {
                proj.Draw(spriteBatch);
            }

            mario.Draw(spriteBatch);
            luigi.Draw(spriteBatch);

        }
    }
}
