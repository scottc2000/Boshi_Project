using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.LevelLoader;
using System.Collections.Generic;

namespace Sprint0.GameMangager
{
    public class BlockManager : IGameObject
    {
        public string Name { get; }

        public List<IBlock> Blocks { get; set; }

        private Sprint0 sprint;
        
        public BlockManager(Sprint0 sprint0)
        {
            this.sprint = sprint0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var block in Blocks)
            {
                block.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
          foreach(var block in Blocks)
            {
                block.Update(gameTime);
            }   
        }
    }

}