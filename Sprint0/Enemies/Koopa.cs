using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.HammerBroStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.goombaSprite;
using Sprint0.Sprites.HammerBroSprite;
using Sprint0.Sprites.SpriteFactories;
using System;
using System.Collections.Generic;

namespace Sprint0.Enemies
{
    public class Koopa : IEnemies, IEntity
    {
        public IEnemyState state;
        public Vector2 position;
        public Vector2 initialposition;
        public Sprint0 mySprint;
        public bool facingLeft { get; set; }
        public Rectangle destination { get; set; }

        public KoopaMoveSprite currentSprite;
        public EnemySpriteFactoryKoopa mySpriteFactory;

        public Koopa(Sprint0 sprint0)
        {
            this.state = new RightMovingKoopaState(this);

            this.facingLeft = true;

            this.position.X = 500;
            this.position.Y = 400;
            this.mySprint = sprint0;

            mySpriteFactory = new EnemySpriteFactoryKoopa(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

            currentSprite = mySpriteFactory.returnSprite("KoopaMove");
            destination = currentSprite.destination;
        }

        public void SetPosition(List<int> position)
        {
            this.initialposition.X = position[0];
            this.initialposition.Y = position[1];
            this.position.X = position[0];
            this.position.Y = position[1];
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
                if (position.X < initialposition.X - 100)
                {
                    ChangeDirection();
                }
            }
            else
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
