using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Enemies.BowserStates;
using Sprint0.Enemies.GooombaStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.goombaSprite;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.SpriteFactories;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sprint0.Enemies
{
    public class Bowser :IEnemies
    {
        public IEnemyBowserState state;
        public Vector2 position;
        public Vector2 initialposition;
        public Sprint0 mySprint;

        //Jumping values
        private int gravity;
        public Vector2 velocity;
        private float sixtyith;

        //Wait Values
        private float waitTimerStart;
        private float waitTimerEnd;

        private int health;
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
            this.state = new BowserIdleState(this);

            this.health = 5;

            gravity = 6;
            sixtyith = 1.0f / 60.0f;
            velocity.X = 0;
            velocity.Y = 0;

            waitTimerStart = 0;
            waitTimerEnd = 2;

            this.facingLeft = true;
            this.mySprint = sprint0;

            mySpriteFactory = new EnemySpriteFactoryBowser(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

            currentSprite = mySpriteFactory.returnSprite("BowserStill");
            Destination = currentSprite.destination;
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
            
        }

        public void BeStomped()
        {
            health--;
            if (health == 0)
                mySprint.objects.RemoveFromList(this);
        }

        public void BeFlipped()
        {
            //Does not flip
        }

        public void StartSwarm()
        {
            //Does not swarm
        }

        public void Jump() 
        { 
            state.Jump();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //System.Diagnostics.Debug.WriteLine("Draw bowser");
            currentSprite.Draw(spriteBatch, position);
        }

        public void applyGravity()
        {
            if (position.Y > 500)
                velocity.Y += gravity;
        }
        public void UpdateMovement(GameTime gametime)
        {
            // updates movement using pos +/- v * dt

            if (facingLeft)
            {
                position = new Vector2(position.X - (velocity.X * ((float)gametime.ElapsedGameTime.TotalSeconds / sixtyith)), position.Y);
            }
            else
            {
                position = new Vector2(position.X + (velocity.X * ((float)gametime.ElapsedGameTime.TotalSeconds / sixtyith)), position.Y);
            }
            position = new Vector2(position.X, position.Y + (velocity.Y * ((float)gametime.ElapsedGameTime.TotalSeconds / sixtyith)));
        }

        public void Update(GameTime gameTime)
        {
            System.Diagnostics.Debug.WriteLine(velocity);
            System.Diagnostics.Debug.WriteLine(System.Math.Abs(mySprint.levelLoader.mario.position.X - position.X));

            state.Update(gameTime);
            UpdateMovement(gameTime);
            applyGravity();
            

            Destination = currentSprite.destination;
        }

        public void Move()
        {
            if (System.Math.Abs(mySprint.levelLoader.mario.position.X - position.X) < 200)
            {

                if ((state is BowserIdleState))
                {
                    state.Jump();
                    System.Diagnostics.Debug.WriteLine("bowserJump");
                } else if (state is BowserJumpState)
                {
                    if (mySprint.mario.position.X < position.X && System.Math.Abs(mySprint.levelLoader.mario.position.X - position.X) > 5)
                    {
                        position.X -= 2;
                    }
                    else if (mySprint.mario.position.X > position.X && System.Math.Abs(mySprint.levelLoader.mario.position.X - position.X) > 5)
                    {
                        facingLeft = false;
                        position.X += 2;
                    }
                    else
                    {
                        if (!(state is BowserFallState))
                            state.Fall();
                            System.Diagnostics.Debug.WriteLine("bowserFall");
                    }
                }

                if (state is BowserFallState)
                    if ((mySprint.mario.position.Y - 10) <= position.Y)
                    {
                        state.Look();
                    }
            }
        }

        public void Wait(GameTime gameTime)
        {
            if (waitTimerStart == 0)
                waitTimerStart = (float)gameTime.TotalGameTime.TotalSeconds;

            if (((float)gameTime.TotalGameTime.TotalSeconds - waitTimerStart) >= waitTimerEnd)
            {
                state.Idle();
                System.Diagnostics.Debug.WriteLine("bowserIdle");
                waitTimerStart = 0;
            }
        }

    }
}
