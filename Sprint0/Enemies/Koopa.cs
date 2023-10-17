using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.HammerBroStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.HammerBroSprite;
using Sprint0.Sprites.KoopaSprite;
using System;

namespace Sprint0.Enemies
{
    public class Koopa :IEnemies
    {
        public IEnemyState state;
        public Vector2 position;
        public Sprint0 mySprint;
        public bool facingLeft { get; set;}

        public ISprite koopaSprite;
        public Texture2D koopaTexture;


        public Koopa(Sprint0 sprint0)
        {
            this.state = new RightMovingKoopaState(this);

            this.facingLeft = false;

            this.position.X = 500;
            this.position.Y = 400;
            this.mySprint = sprint0;

            this.koopaSprite = new KoopaMoveSprite(this);
            koopaTexture = mySprint.Content.Load<Texture2D>("marioenemy");
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
            koopaSprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            koopaSprite.Update(gameTime);
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
