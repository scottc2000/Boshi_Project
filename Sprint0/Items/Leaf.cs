using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.ItemSprites;
using Sprint0.Sprites.SpriteFactories;
using System.Collections.Generic;

namespace Sprint0.Items
{
    internal class Leaf : IItem
    {
        private AniItemSprite aniItem;
        private Vector2 position;

        public float gravity = 1;

        public Rectangle Destination { get; set; }
        public bool moveRight { get; set; }
        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }

        public Leaf()
        {
            aniItem = ItemSpriteFactory.Instance.returnSprite("Leaf");
            Destination = aniItem.itemPosition;
            moveRight = false;
        }

        public void setPosition(List<int> pos)
        {
            position.X = pos[0];
            position.Y = pos[1];
        }

        public void applyGravity()
        {
            position = new Vector2(position.X, position.Y + gravity);
        }

        public void Update(GameTime gameTime)
        {
            aniItem.Update(gameTime);
            applyGravity();
            Destination = aniItem.itemPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aniItem.Draw(spriteBatch, position);
        }
    }
}