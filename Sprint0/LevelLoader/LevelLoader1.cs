using Sprint0.GameMangager;
using Sprint0.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Sprint0.LevelLoader.Level1Data;

namespace Sprint0
{

    public class LevelLoader1
    {
        private Sprint0 sprint0;

        private JsonElement levelData;
        private Root data;

        public ObjectManager objectManager;

        public LevelLoader1(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
            objectManager = new ObjectManager(this.sprint0);
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

            Load(data);
        }

        public void Load(Root data)
        {
            foreach(Block block in data.Blocks)
            { 
                if(block.Name == "floor")
                {
                    // need a Floor.c class that inherits from IBlock
                    //floor.add(new Floor(block.x, block.y, block.width, block.height)); 
                    //objectManager.Blocks.add(floor);

                } else if (block.Name == "large_block")
                {
                    // need LargeBlock.c class that inherits from IBLock
                    // largeblock.add(new LargeBlock(block.x, block.y, block.width, block.height));
                    // objectManager.Blocks.add(largeblock);
                }
                // repeat for all block types in zone1
            }
            foreach(Item item in data.Items)
            {
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
