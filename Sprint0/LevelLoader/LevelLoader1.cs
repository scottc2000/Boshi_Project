using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using Sprint0.Sprites;
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

        public BlockManager blockManager;
        public ItemManager itemManager;

        public LevelLoader1(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;

            // Initailize managers
            blockManager = new BlockManager(this.sprint0);
            itemManager = new ItemManager(this.sprint0);
        }
        public void Load(string jsonFilePath)
        {
            // Deserialize json file
            string json = File.ReadAllText(jsonFilePath);
            data = JsonSerializer.Deserialize<Root>(json);

            // Initialize Lists
            blockManager.Blocks = new List<IBlock>();
            itemManager.Items = new List<IItem>();

            Load(data);
        }

        public void Load(Root data)
        {
            // Repeat this code for each zone1
            foreach(Block block in data.Blocks)
            { 
                if(block.Name == "floor")
                {
                    // need a Floor.c class that inherits from IBlock
                    //floor.add(new Floor(block.x, block.y, block.width, block.height)); 

                } else if (block.Name == "large_block")
                {
                    // need LargeBlock.c class that inherits from IBLock
                    // largeblock.add(new LargeBlock(block.x, block.y, block.width, block.height));
                }
                // repeat for all block types in zone1
            }
            foreach(Item item in data.Items)
            {
                // need a RedMushroom.c class that inherits from IItem
               // redmushroom.add(new RedMushroom(item.Position, item.Hitbox));
            }
            // repeat for all item types in zone1
            /*
             * ADD ENEMIES ONCE ADDED TO LEVEL1.JSON AND ENEMY CLASS(ES) ARE ADDED TO LEVEL1DATA.CS
             */

        }

        public void LoadBackground(SpriteBatch spriteBatch)
        {
            // Finish camera and then test

        }

    }
}
