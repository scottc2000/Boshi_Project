using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.LevelLoader;
using System.Collections.Generic;

namespace Sprint0.GameMangager
{
    public class ItemManager : IGameObject
    {
        public List<IItem> Items { get; set; }

        private Sprint0 sprint;
        
        public ItemManager(Sprint0 sprint0)
        {
            this.sprint = sprint0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var item in Items)
            {
                item.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
          foreach(var item in Items)
            {
                item.Update(gameTime);
            }   
        }
    }

}