using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using System.Collections.Generic;

namespace Sprint0.Items
{
    internal class Leaf : IItem, IEntity
    {
        private AniItemSprite aniItem;
        private Vector2 position;
        public Rectangle destination { get; set; }
        public bool moveRight { get; set; }

        public Leaf()
        {
            aniItem = ItemSpriteFactory.Instance.returnSprite("Leaf");
            destination = aniItem.itemPosition;
            System.Diagnostics.Debug.WriteLine("Leaf Rectangle in IItem: " + destination);
        }

        public void setPosition(List<int> pos)
        {
            position.X = pos[0];
            position.Y = pos[1];
        }

        public void Update(GameTime gameTime)
        {
            aniItem.Update(gameTime);
            destination = aniItem.itemPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aniItem.Draw(spriteBatch, position);
        }
    }
}