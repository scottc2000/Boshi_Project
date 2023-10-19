using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.HammerBroStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.HammerBroSprite;
using System;

namespace Sprint0.Enemies
{
    public class HammerBro : IEnemies, IObject
    {
        public IEnemyState state;
        public Vector2 position;
        public Sprint0 mySprint;
        public bool facingLeft { get; set; }

        public ISprite hammerBroSprite;
        public Texture2D hammerBroTexture;


        public HammerBro(Sprint0 sprint0)
        {
            this.state = new RightMovingHammerBroState(this);

            this.facingLeft = false;

            this.position.X = 500;
            this.position.Y = 400;
            this.mySprint = sprint0;

            this.hammerBroSprite = new HammerBroMoveSprite(this);
            hammerBroTexture = mySprint.Content.Load<Texture2D>("marioenemy");
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
            hammerBroSprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            state.Update();
            hammerBroSprite.Update(gameTime);
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
            }
            else
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
