using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.GoombaStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.goombaSprite;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.SpriteFactories;
using System;

namespace Sprint0.Enemies
{
    public class Goomba :IEnemies
    {
        public IEnemyState state;
        public Vector2 position;
        public Sprint0 mySprint;
        public bool facingLeft { get; set;}
        public Rectangle destination { get; set; }

        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }

        public ISprite goombaSprite;
        public Texture2D goombaTexture;


        public Goomba(Sprint0 sprint0)
        {
            this.state = new RightMovingGoombaState(this);

            this.facingLeft = true;

            this.position.X = 500;
            this.position.Y = 400;
            this.mySprint = sprint0;

            mySpriteFactory = new EnemySpriteFactoryGoomba(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

            currentSprite = mySpriteFactory.returnSprite("GoombaMove");
            destination = currentSprite.destination;
        }

        public void ChangeDirection()
        {
            state.ChangeDirection();
        }

        public void BeStomped()
        {
            state.BeStomped();
        }

        public void BeFlipped()
        {
            state.BeFlipped();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch, position);
        }
        
        public void Update(GameTime gameTime)
        {
            currentSprite.Update(gameTime); 
            state.Update();
        }

        public void Move()
        {
            if (facingLeft)
            {
                position.X -= 1;
                if (position.X < 200)
                {
                    ChangeDirection();
                }
            } else
            {
                position.X += 1;
                if (position.X > 600)
                {
                    ChangeDirection();
                }
            }
        }
    }
}
