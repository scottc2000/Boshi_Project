using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Items;
using System.Collections.Generic;
using static Sprint0.LevelLoader.Level1Data;
using Sprint0.Utility;

namespace Sprint0.Blocks
{
    internal class QuestionBlock : IBlock
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        private ISprite sprite;
        private Vector2 location;
        public Rectangle Destination { get; set; }
        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit {  get; set; }
        public bool stuck { get; set; }
        public bool bumped { get; set; }
        public bool newSpriteSet {  get; set; }
        public IItem item { get; set; }
        public List<int> itemPos { get; set; }
        private SpriteBatch spriteBatch;
        private float timer = 0f;
        private int count = 10;
        private int fall = 5;
        private SpriteNumbers spriteNumbers = new SpriteNumbers();

        public QuestionBlock(SpriteBatch spriteBatch, ContentManager content, Rectangle blockRectangle, string item)
        {
            Destination = blockRectangle;
            location = new Vector2(blockRectangle.X, blockRectangle.Y);
            itemPos = new List<int>(2);
            this.spriteBatch = spriteBatch;
            BlockSpriteFactory.Instance.LoadTextures(content);
            BlockSpriteFactory.Instance.LoadSpriteLocations();
            sprite = BlockSpriteFactory.Instance.CreateAnimatedBlock(spriteBatch, "question_block", new Vector2(blockRectangle.X, blockRectangle.Y));
            itemPos.Add(blockRectangle.X);
            itemPos.Add(blockRectangle.Y - 16);
            this.item = storeItem(item);
            bumped = false;
            newSpriteSet = false;
            
        }

        private IItem storeItem(string item)
        {
            switch (item)
            {
                case "RedMushroom":
                    IItem RedMushroom = new RedMushroom();
                    RedMushroom.setPosition(itemPos);
                    return RedMushroom;
                case "OneUpMushroom":
                    IItem OneUpMushroom = new OneUpMushroom();
                    OneUpMushroom.setPosition(itemPos);
                    return OneUpMushroom;
                case "FireFlower":
                    IItem FireFlower = new FireFlower();
                    FireFlower.setPosition(itemPos);
                    return FireFlower;
                case "Leaf":
                    IItem Leaf = new Leaf();
                    Leaf.setPosition(itemPos);
                    return Leaf;
                case "Star":
                    IItem Star = new Star();
                    Star.setPosition(itemPos);
                    return Star;
                case "Frog":
                    IItem Frog = new Frog();
                    Frog.setPosition(itemPos);
                    return Frog;
                case "Tanooki":
                    IItem Tanooki = new Tanooki();
                    Tanooki.setPosition(itemPos);
                    return Tanooki;
                case "Hammer":
                    IItem Hammer = new Hammer();
                    Hammer.setPosition(itemPos);
                    return Hammer;
                case "Shoe":
                    IItem Shoe = new Shoe();
                    Shoe.setPosition(itemPos);
                    return Shoe;
                default:
                    IItem Coin = new Coin(spriteBatch, Destination);
                    Coin.setPosition(itemPos);
                    return Coin;
                    
            }
        }


        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (bumped)
            {
                if (!newSpriteSet)
                {
                    sprite = BlockSpriteFactory.Instance.CreateNonAnimatedBlock(spriteBatch, "empty_question_block", location);
                    newSpriteSet = true;
                }
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer >= spriteNumbers.frameInterval && count > fall)
                {
                    location.Y -= 1;
                    count--;
                    timer = 0f;
                }
                else if (timer >= spriteNumbers.frameInterval && count > 0)
                {
                    location.Y += 1;
                    count--;
                    timer = 0f;
                }
            }
            




        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}