using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.BowserStates;
using Sprint0.Enemies.GooombaStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.goombaSprite;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.SpriteFactories;
using System.Collections.Generic;

namespace Sprint0.Enemies
{
    public class Bowser :IEnemies
    {
        public IEnemyBowserState state;
        public Vector2 position;
        public Vector2 initialposition;
        public Sprint0 mySprint;
        public bool facingLeft { get; set;}
        public Rectangle Destination { get; set; }
        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }

        public AnimatedSpriteBowser currentSprite;
        public EnemySpriteFactoryBowser mySpriteFactory;

        public Bowser(Sprint0 sprint0)
        {
            state = new BowserIdleState(this);

            facingLeft = true;
            mySprint = sprint0;

            mySpriteFactory = new EnemySpriteFactoryBowser(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

            currentSprite = mySpriteFactory.returnSprite("BowserStill");
            Destination = currentSprite.destination;
        }

        public void SetPosition(List<int> position)
        {
            initialposition.X = position[0];
            initialposition.Y = position[1];
            this.position.X = position[0];
            this.position.Y = position[1];
        }

        public void ChangeDirection()
        {
            
        }

        public void BeStomped()
        {
            //Does not be stomped
        }

        public void BeFlipped()
        {
            //Does not flip
        }

        public void StartSwarm()
        {
            //Does not swarm
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch, position, Color.White);
        }
        
        public void Update(GameTime gameTime)
        {
            currentSprite.Update(gameTime);
            Destination = currentSprite.destination;
            state.Update(gameTime);
        }

        public void Move()
        {
            if (facingLeft)
            {
                position.X -= 1;
                if (position.X < initialposition.X-160)
                {
                    ChangeDirection();
                }
            } else
            {
                position.X += 1;
                if (position.X > initialposition.X)
                {
                    ChangeDirection();
                }
            }
        }

    }
}
