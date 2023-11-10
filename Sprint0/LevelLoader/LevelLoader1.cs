using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Background;
using Sprint0.Blocks;
using Sprint0.Camera;
using Sprint0.Characters;
using Sprint0.Enemies;
using Sprint0.GameMangager;
using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Items;
using System.IO;
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

        public MarioCamera camera;
        private Terrain terrain;
        public GameStats hud;
        public ILuigi luigi;
        public IMario mario;

        public ObjectManager objectManager;
        public AudioManager audioManager;

        public LevelLoader1(Sprint0 sprint0, SpriteBatch spriteBatch, ContentManager content, MarioCamera camera)
        {
            this.sprint0 = sprint0;
            objectManager = sprint0.objects;

            this.spriteBatch = spriteBatch;
            this.content = content;
            audioManager = AudioManager.Instance;

            this.camera = camera;
            terrain = new Terrain(sprint0);
            hud = new GameStats(sprint0);
            mario = new Mario(sprint0);
            luigi = new Luigi(sprint0);
        }
        public void Load(string jsonFilePath)
        {
            // Deserialize json file
            string json = File.ReadAllText(jsonFilePath);
            data = JsonSerializer.Deserialize<Root>(json);

            Load(data);
            audioManager.PlayMusic(data.Songs[0].Name);
            System.Diagnostics.Debug.WriteLine(data.Songs[0].Name);
        }

        public void Load(Root data)
        {
            // Load all blocks from the JSON file to objectManager
            foreach (Block block in data.Blocks)
            {
                Rectangle blockRectangle = new Rectangle(block.x, block.y, block.width, block.height);
                switch (block.Name)
                {
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
                        QuestionBlock question_block = new QuestionBlock(spriteBatch, content, blockRectangle, block.x, block.y, block.width, block.height);
                        objectManager.Blocks.Add(question_block);
                        objectManager.TopCollidableBlocks.Add(question_block);
                        objectManager.BottomCollidableBlocks.Add(question_block);
                        objectManager.SideCollidableBlocks.Add(question_block);
                        objectManager.DynamicEntities.Add(question_block);
                        break;
                    case "spinning_coin":
                        SpinningCoin spinning_coin = new SpinningCoin(spriteBatch, blockRectangle);
                        objectManager.Blocks.Add(spinning_coin);
                        objectManager.TopCollidableBlocks.Add(spinning_coin);
                        objectManager.BottomCollidableBlocks.Add(spinning_coin);
                        objectManager.SideCollidableBlocks.Add(spinning_coin);
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
                        objectManager.Items.Add(RedMushroom);
                        objectManager.DynamicEntities.Add(RedMushroom);
                        break;
                    case "OneUpMushroom":
                        IItem OneUpMushroom = new OneUpMushroom();
                        OneUpMushroom.setPosition(item.Position);
                        objectManager.Items.Add(OneUpMushroom);
                        objectManager.DynamicEntities.Add(OneUpMushroom);
                        break;
                    case "FireFlower":
                        IItem FireFlower = new FireFlower();
                        FireFlower.setPosition(item.Position);
                        objectManager.Items.Add(FireFlower);
                        objectManager.DynamicEntities.Add(FireFlower);
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
                    objectManager.Enemies.Add(goomba);
                    objectManager.DynamicEntities.Add(goomba);
                }
                if (enemy.Name == "Koopa")
                {
                    IEnemies koopa = new Koopa(sprint0);
                    koopa.SetPosition(enemy.Position);
                    objectManager.Enemies.Add(koopa);
                    objectManager.DynamicEntities.Add(koopa);
                }
            }

            objectManager.DynamicEntities.Add(mario);
            objectManager.DynamicEntities.Add(luigi);
            objectManager.Projectiles.Add(luigi.fireProjectile);
            objectManager.DynamicEntities.Add(luigi.fireProjectile);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            terrain.Draw(spriteBatch); // need to draw terrain before any game objects

            // Draw each game object
            foreach (var block in objectManager.Blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach(var item in objectManager.Items)
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
            hud.Draw(spriteBatch);
            mario.Draw(spriteBatch);
            luigi.Draw(spriteBatch);

        }

        public void Update(GameTime gameTime)
        {
            terrain.Update(gameTime);   // need to update terrain before any game objects

            // Update each game object
            foreach (var block in objectManager.Blocks)
            {
                block.Update(gameTime);
            }
            foreach (var item in objectManager.Items)
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

            camera.Update(mario);
            hud.Update(gameTime);
            mario.Update(gameTime);
            luigi.Update(gameTime);

        }
    }
}
