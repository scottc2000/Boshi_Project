using Sprint0.GameMangager;
using Sprint0.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Sprint0.Blocks;
using System.Collections;
using Sprint0.Items;
using Sprint0.Items.ItemClasses;
using Sprint0.Sprites.SpriteFactories;
using static Sprint0.LevelLoader.Level1Data;
using Item = Sprint0.LevelLoader.Level1Data.Item;
using System.Numerics;

namespace Sprint0
{

    public class LevelLoader1
    {
        private Sprint0 sprint0;
        private ItemSpriteFactory itemSpriteFactory;
        private Items.Item item;

        private JsonElement levelData;
        private Root data;

        public ObjectManager objectManager;
        private ICharacter mario;
        private ICharacter luigi;

        public LevelLoader1(Sprint0 sprint0, ICharacter mario, ICharacter luigi, Items.Item item, ItemSpriteFactory itemSpriteFactory)
        {
            this.sprint0 = sprint0;
            objectManager = new ObjectManager(this.sprint0);
            this.mario = mario;
            this.luigi = luigi;
            this.itemSpriteFactory = itemSpriteFactory;
            this.item = item;
        }
        public void Load(string jsonFilePath)
        {
            // Deserialize json file
            string json = File.ReadAllText(jsonFilePath);
            data = JsonSerializer.Deserialize<Root>(json);

            // Initialize Lists
            objectManager.Blocks = new List<IBlock>();
            objectManager.Items = new List<IItem>();
            objectManager.Enemies = new List<IEnemies>();

            // Initialize Players
            objectManager.mario = mario;
            objectManager.luigi = luigi;

            //Initialize Item
            objectManager.item = item;

            Load(data);
        }

        public void Load(Root data)
        {

            foreach(LevelLoader.Level1Data.Block block in data.Blocks)
            {
                switch (block.Name)
                {
                    case "floor":
                        //floor.add(new Floor(block.x, block.y, block.width, block.height)); 
                        break;
                    case "large_block":
                        //largeblock.add(new LargeBlock(block.x, block.y, block.width, block.height));
                        break;
                    case "yellow_brick":

                        break;
                    case "wood_blocks":

                        break;
                    case "clouds":

                        break;
                    case "pipe":

                        break;
                }
            }
            foreach(Item item in data.Items)
            {
                switch (item.Name)
                {
                    case "RedMushroom":
                        this.item.position.X = item.Position[0];
                        this.item.position.Y = item.Position[1];
                        objectManager.Items.Add(new RedMushroom(this.item, itemSpriteFactory));
                        break;
                    case "OneUpMushroom":
                        this.item.position.X = item.Position[0];
                        this.item.position.Y = item.Position[1];
                        objectManager.Items.Add(new OneUpMushroom(this.item, itemSpriteFactory));
                        break;
                    case "FireFlower":
                        this.item.position.X = item.Position[0];
                        this.item.position.Y = item.Position[1];
                        objectManager.Items.Add(new FireFlower(this.item, itemSpriteFactory));
                        break;
                    case "Leaf":
                        this.item.position.X = item.Position[0];
                        this.item.position.Y = item.Position[1];
                        objectManager.Items.Add(new Leaf(this.item, itemSpriteFactory));
                        break;
                    case "Star":
                        this.item.position.X = item.Position[0];
                        this.item.position.Y = item.Position[1];
                        objectManager.Items.Add(new Star(this.item, itemSpriteFactory));
                        break;
                    case "Frog":
                        this.item.position.X = item.Position[0];
                        this.item.position.Y = item.Position[1];
                        objectManager.Items.Add(new Frog(this.item, itemSpriteFactory));
                        break;
                    case "Tanooki":
                        this.item.position.X = item.Position[0];
                        this.item.position.Y = item.Position[1];
                        objectManager.Items.Add(new Tanooki(this.item, itemSpriteFactory));
                        break;
                    case "Hammer":
                        this.item.position.X = item.Position[0];
                        this.item.position.Y = item.Position[1];
                        objectManager.Items.Add(new Hammer(this.item, itemSpriteFactory));
                        break;
                    case "Shoe":
                        this.item.position.X = item.Position[0];
                        this.item.position.Y = item.Position[1];
                        objectManager.Items.Add(new Shoe(this.item, itemSpriteFactory));
                        break;
                }
                // need a RedMushroom.c class that inherits from IItem
                
               // redmushroom.add(new RedMushroom(item.Position, item.Hitbox));
               // objectManager.Items.add(redmushroom);
            }
            

            /*
             * ADD ENEMIES ONCE ADDED TO LEVEL1.JSON AND ENEMY CLASS(ES) ARE ADDED TO LEVEL1DATA.CS
             */

            /*foreach(Enemy enemy in data.Enemy)
            {
                if (enemy.Name == "goomba"){
                    goomba.add(new Goomba(enemy.Position, enemy.Hitbox);
                    objectManager.Enemy.add(goomba);
                }
            }*/

        }

    }
}
