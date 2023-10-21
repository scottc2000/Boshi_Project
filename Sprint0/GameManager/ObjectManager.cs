using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Items;
using Sprint0.LevelLoader;
using System.Collections.Generic;

namespace Sprint0.GameMangager
{
    public class ObjectManager : IGameObject
    {
        public string Name { get; }

        public List<IBlock> Blocks { get; set; }
        public List<IItem> Items { get; set; } 
        public List<IEnemies> Enemies { get;set; }
        public ICharacter mario { get; set; }
        public ICharacter luigi { get; set; }

        public Item item;

        private Sprint0 sprint;
        
        public ObjectManager(Sprint0 sprint0)
        {
            this.sprint = sprint0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var block in Blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach(var item in Items)
            {
                item.Draw(spriteBatch);
                this.item.Draw(spriteBatch);
            }
            foreach(var enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
            mario.Draw(spriteBatch);
            luigi.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
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
            mario.Update(gameTime);
            luigi.Update(gameTime);
        }

        /*
         * Will update when camera is set up
         * checks if object is on the screen
         * use this to draw and update objects 
         */
        private static bool IsInView()
        {
            return true;
        }
    }

}