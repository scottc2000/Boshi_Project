using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies.HammerBroStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.HammerBroSprite;
using System;
using System.Collections.Generic;

namespace Sprint0.Enemies
{
    public class HammerBro : IEnemies
    {
        public IEnemyState state;
        public Vector2 position;
        public Sprint0 mySprint;
        public bool facingLeft { get; set; }

        public ISprite hammerBroSprite;
        public Texture2D hammerBroTexture;
        public Rectangle Destination { get; set; }
        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }


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

        public void SetPosition(List<int> position)
        {
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
