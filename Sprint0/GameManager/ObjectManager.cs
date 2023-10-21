using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.LevelLoader;
using System.Collections.Generic;
using Sprint0.Characters;
using Sprint0.Enemies;
using Sprint0.Collision;
using System;
using System.Diagnostics;

namespace Sprint0.GameMangager
{
    public class ObjectManager : IGameObject
    {
        public string Name { get; }

        public List<IBlock> Blocks { get; set; }
        public List<IItem> Items { get; set; } 
        public List<IEnemies> Enemies { get;set; }
        public List<ICharacter> Players { get; set; }

        private Sprint0 sprint;
        
        public ObjectManager(Sprint0 sprint0)
        {
            this.sprint = sprint0;
            Players = new List<ICharacter>();
            Items = new List<IItem>();
            Enemies = new List<IEnemies>();
            Blocks = new List<IBlock>();

            
            Players.Add(new Mario(sprint));
            Players.Add(new Luigi(sprint));


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var block in Blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach(var item in Items)
            {
                item.Draw(spriteBatch);
            }
            foreach(var enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (ICharacter player in Players)
            {
                player.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime, CollisionHandler collision)
        {
          foreach(var block in Blocks)
          {
             block.Update(gameTime);
          }
          foreach(var item in Items)
            {
                item.Update(gameTime);
            }
          foreach (var enemy in Enemies)
            {
                enemy.Update(gameTime);
            }
            foreach (ICharacter player in Players)
            {
                player.Update(gameTime);
                collision.playerUpdate();

            }
        }

        public void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }

}