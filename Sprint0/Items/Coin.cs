using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Utility;
using System.Collections.Generic;
using Sprint0.GameMangager;
using Sprint0.Commands.Collisions;

namespace Sprint0.Blocks
{
    internal class Coin : IItem
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        private ISprite sprite;
        public Rectangle Destination { get; set; }
        public bool moveRight { get; set; }
        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }
        private int totalFrames;
        private float frameTimer;
        private float frameInterval;
        public Vector2 location;
        private float timer = 0f;
        private int count = 48;
        private int fall = 16;
        private float interval = 0.1f;
        private IItem coin;
        private Sprint0 sprint0;

        public Coin(SpriteBatch spriteBatch, Rectangle blockRectangle)
        {
            Destination = blockRectangle;
            location = new Vector2(blockRectangle.X, blockRectangle.Y);
            sprite = BlockSpriteFactory.Instance.CreateAnimatedBlock(spriteBatch, "spinning_coin", location);
            location.Y -= 16;
            
        }

        public void setPosition(List<int> pos)
        {
            location.X = pos[0];
            location.Y = pos[1];
        }
        public void getInstance(Sprint0 sprint0, IItem coin)
        {
            this.sprint0 = sprint0;
            this.coin = coin;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer >= interval && count > fall)
            {
                location.Y -= 1;
                count--;
                timer = 0f;
            }
            else if (timer >= interval && count > 0)
            {
                location.Y += 1;
                count--;
                timer = 0f;
            }
            else
            {
                CGetCoin command = new CGetCoin(sprint0);
                command.Execute(coin);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }


    }
}