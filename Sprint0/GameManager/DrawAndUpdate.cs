using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Collections.Generic;

namespace Sprint0.GameManager
{
    public class DrawAndUpdate : IGameObject
    {
        private List<IGameObject> objects;
        public DrawAndUpdate(List<IGameObject> objects) 
        { 
            this.objects = objects;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var obj in objects) 
            {
                obj.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var obj in objects)
            {
                obj.Update(gameTime);
            }
        }
    }
}
