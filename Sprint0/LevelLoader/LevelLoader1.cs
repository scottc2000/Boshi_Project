using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using Sprint0.Enemies;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using Sprint0.Items;
using System.Collections.Generic;
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

        private JsonElement levelData;
        private Root data;

        public ObjectManager objectManager;
        public AudioManager audioManager;

        public LevelLoader1(Sprint0 sprint0, SpriteBatch spriteBatch, ContentManager content)
        {
            this.sprint0 = sprint0;
            objectManager = sprint0.objects;
            this.spriteBatch = spriteBatch;
            this.content = content;
            audioManager = sprint0.audioManager;
        }
        public void Load(string jsonFilePath)
        {
            // Deserialize json file
            string json = File.ReadAllText(jsonFilePath);
            data = JsonSerializer.Deserialize<Root>(json);

            Load(data);
            audioManager.PlayMusic("mainTheme");
        }

        public void Load(Root data)
        {

            foreach (Block block in data.Blocks)
            {
                switch (block.Name)
                {
                    case "floor":
                        Floor floor = new Floor(spriteBatch, content, block.x, block.y, block.width, block.height);
                        objectManager.Blocks.Add(floor);
                        objectManager.TopCollidableBlocks.Add(floor);
                        objectManager.SideCollidableBlocks.Add(floor);
                        break;
                    case "large_block":
                        LargeBlock large_block = new LargeBlock(spriteBatch, content, block.x, block.y, block.width, block.height);
                        objectManager.Blocks.Add(large_block);
                        objectManager.TopCollidableBlocks.Add(large_block);
                        break;
                    case "yellow_brick":
                        YellowBrick yellow_brick = new YellowBrick(spriteBatch, content, block.x, block.y, block.width, block.height);
                        objectManager.Blocks.Add(yellow_brick);
                        objectManager.TopCollidableBlocks.Add(yellow_brick);
                        objectManager.BottomCollidableBlocks.Add(yellow_brick);
                        objectManager.SideCollidableBlocks.Add(yellow_brick);
                        break;
                    case "wood_blocks":
                        WoodBlocks wood_blocks = new WoodBlocks(spriteBatch, content, block.x, block.y, block.width, block.height);
                        objectManager.Blocks.Add(wood_blocks);
                        objectManager.TopCollidableBlocks.Add(wood_blocks);
                        objectManager.BottomCollidableBlocks.Add(wood_blocks);
                        objectManager.SideCollidableBlocks.Add(wood_blocks);
                        break;
                    case "clouds":
                        Clouds clouds = new Clouds(spriteBatch, content, block.x, block.y, block.width, block.height);
                        objectManager.Blocks.Add(clouds);
                        objectManager.TopCollidableBlocks.Add(clouds);
                        break;
                    case "pipe":
                        Pipe pipe = new Pipe(spriteBatch, content, block.x, block.y, block.width, block.height);
                        objectManager.Blocks.Add(pipe);
                        objectManager.TopCollidableBlocks.Add(pipe);
                        objectManager.SideCollidableBlocks.Add(pipe);
                        break;
                    case "question_block":
                        QuestionBlock question_block = new QuestionBlock(spriteBatch, content, block.x, block.y, block.width, block.height);
                        objectManager.Blocks.Add(question_block);
                        objectManager.TopCollidableBlocks.Add(question_block);
                        objectManager.BottomCollidableBlocks.Add(question_block);
                        objectManager.SideCollidableBlocks.Add(question_block);
                        break;
                    case "spinning_coin":
                        SpinningCoin spinning_coin = new SpinningCoin(spriteBatch, content, block.x, block.y, block.width, block.height);
                        objectManager.Blocks.Add(spinning_coin);
                        objectManager.TopCollidableBlocks.Add(spinning_coin);
                        objectManager.BottomCollidableBlocks.Add(spinning_coin);
                        objectManager.SideCollidableBlocks.Add(spinning_coin);
                        break;
                }
            }
            foreach (Item item in data.Items)
            {
                switch (item.Name)
                {
                    case "RedMushroom":
                        IItem RedMushroom = new RedMushroom();
                        RedMushroom.setPosition(item.Position);
                        objectManager.Items.Add(RedMushroom);
                        break;
                    case "OneUpMushroom":
                        IItem OneUpMushroom = new OneUpMushroom();
                        OneUpMushroom.setPosition(item.Position);
                        objectManager.Items.Add(OneUpMushroom);
                        break;
                    case "FireFlower":
                        IItem FireFlower = new FireFlower();
                        FireFlower.setPosition(item.Position);
                        objectManager.Items.Add(FireFlower);
                        break;
                    case "Leaf":
                        IItem Leaf = new Leaf();
                        Leaf.setPosition(item.Position);
                        objectManager.Items.Add(Leaf);
                        break;
                    case "Star":
                        IItem Star = new Star();
                        Star.setPosition(item.Position);
                        objectManager.Items.Add(Star);
                        break;
                    case "Frog":
                        IItem Frog = new Frog();
                        Frog.setPosition(item.Position);
                        objectManager.Items.Add(Frog);
                        break;
                    case "Tanooki":
                        IItem Tanooki = new Tanooki();
                        Tanooki.setPosition(item.Position);
                        objectManager.Items.Add(Tanooki);
                        break;
                    case "Hammer":
                        IItem Hammer = new Hammer();
                        Hammer.setPosition(item.Position);
                        objectManager.Items.Add(Hammer);
                        break;
                    case "Shoe":
                        IItem Shoe = new Shoe();
                        Shoe.setPosition(item.Position);
                        objectManager.Items.Add(Shoe);
                        break;
                }
            }

            foreach (Enemy enemy in data.Enemies)
            {
                if (enemy.Name == "Goomba")
                {
                    IEnemies goomba = new Goomba(sprint0);
                    goomba.SetPosition(enemy.Position);
                    objectManager.Enemies.Add(goomba);
                }
                if (enemy.Name == "Koopa")
                {
                    IEnemies koopa = new Koopa(sprint0);
                    koopa.SetPosition(enemy.Position);
                    objectManager.Enemies.Add(koopa);
                }
            }

        }

    }
}
