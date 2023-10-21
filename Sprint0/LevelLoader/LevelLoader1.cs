using Sprint0.GameMangager;
using Sprint0.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Sprint0.Blocks;
using static Sprint0.LevelLoader.Level1Data;
using System.Collections;

namespace Sprint0
{

    public class LevelLoader1
    {
        private Sprint0 sprint0;

        private JsonElement levelData;
        private Root data;

        public ObjectManager objectManager;
        private ICharacter mario;
        private ICharacter luigi;

        public LevelLoader1(Sprint0 sprint0, ICharacter mario, ICharacter luigi)
        {
            this.sprint0 = sprint0;
            objectManager = new ObjectManager(this.sprint0);
            this.mario = mario;
            this.luigi = luigi;
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
