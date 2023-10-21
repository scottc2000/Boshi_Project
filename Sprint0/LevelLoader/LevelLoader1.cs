﻿using Sprint0.GameMangager;
using Sprint0.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Sprint0.Blocks;
using static Sprint0.LevelLoader.Level1Data;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

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
        private ICharacter mario;
        private ICharacter luigi;

        public LevelLoader1(Sprint0 sprint0, SpriteBatch spriteBatch, ContentManager content, ICharacter mario, ICharacter luigi)
        {
            this.sprint0 = sprint0;
            this.spriteBatch = spriteBatch;
            this.content = content;
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

            foreach (Block block in data.Blocks)
            {
                switch (block.Name)
                {
                    case "floor":
                        objectManager.Blocks.Add(new Floor(spriteBatch, content, block.x, block.y, block.width, block.height));
                        break;
                    case "large_block":
                        objectManager.Blocks.Add(new LargeBlock(spriteBatch, content, block.x, block.y, block.width, block.height));
                        break;
                    case "yellow_brick":
                        objectManager.Blocks.Add(new YellowBrick(spriteBatch, content, block.x, block.y, block.width, block.height));
                        break;
                    case "wood_blocks":
                        objectManager.Blocks.Add(new WoodBlocks(spriteBatch, content, block.x, block.y, block.width, block.height));
                        break;
                    case "clouds":
                        objectManager.Blocks.Add(new Clouds(spriteBatch, content, block.x, block.y, block.width, block.height));
                        break;
                    case "pipe":
                        objectManager.Blocks.Add(new Pipe(spriteBatch, content, block.x, block.y, block.width, block.height));
                        break;
                    case "question_block":
                        objectManager.Blocks.Add(new QuestionBlock(spriteBatch, content, block.x, block.y, block.width, block.height));
                        break;
                }
            }
            foreach (Item item in data.Items)
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

        public List<IBlock> getBlockList()
        {
            return objectManager.Blocks;
        }

    }
}
