using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Camera;
using Sprint0.Characters.LuigiStates;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Items.Projectiles;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.SpriteFactories;
using static Sprint0.Characters.Luigi;
using static Sprint0.Characters.Mario;

namespace Sprint0.Characters
{
    public class Mario : IMario
    {
        public enum MarioHealth { Normal, Raccoon, Fire, Big, Dead };
        public MarioHealth health { get; set; }

        public enum MarioPose { Jump, Crouch, Idle, Walking, Throwing, Flying };
        public MarioPose pose { get; set; }
        public bool facingLeft { get; set; }
        public bool fired;

        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }
        public bool isInvinsible { get; set; }

        // move into physics class eventually
        public Vector2 velocity;
        public float decay;
        public float gravity;
        public int timeGap;

        public ICharacterState State { get; set; }


        public int runningTimer { get; set; }
        public int flyingTimer { get; set; }
        public bool boosted { get; set; }

        public Vector2 position { get; set; }
        public Sprint0 mySprint;
        int sizeDiff;
        public Rectangle Destination { get; set; }


        public AnimatedSpriteMario currentSprite { get; set; }
        public CharacterSpriteFactoryMario mySpriteFactory;
        public MarioCamera camera;
        public FireProjectile fireProjectile { get; set; }

        public Mario(Sprint0 sprint0)
        {
            this.health = MarioHealth.Normal;
            this.State = new MarioIdleState(this);

            // timers
            runningTimer = 0;
            flyingTimer = 0;
            boosted = false;

            // default position stuff
            this.facingLeft = true;
            this.position = new Vector2(180, 200);
            this.sizeDiff = 25;
            this.fired = false;
            this.timeGap = 0;

            this.downhit = false;
            this.uphit = false;
            this.lefthit = false;
            this.righthit = false;

            // default velocity is zero (still), decay makes player slippery the higher it is.
            this.velocity = new Vector2(0, 0);
            this.decay = 0.9f;
            this.stuck = false;
            this.gravity = 1.0f;

            mySprint = sprint0;

            stuck = false;
            isInvinsible = false;

            // creates new sprite factory and projectile factory
            mySpriteFactory = new CharacterSpriteFactoryMario(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

            fireProjectile = new FireProjectile(mySprint.Content);


            currentSprite = mySpriteFactory.returnSprite("MarioStillLeft");
            Destination = currentSprite.destination;

        }

        /* ----------------------- Mario States --------------------*/
        public void Move()  
        { 
            State.Move(); 
        }

        public void Jump()  
        {
            if(uphit && health != MarioHealth.Dead)
            {
                State.Jump();
            }
        }
        public void Fall()
        {
            if (health != MarioHealth.Dead)
            {
                State.Fall();
            }
        }
        public void Fly() 
        { 
            State.Fly();
        }

        public void Crouch()
        {
            State.Crouch();
        }

        public void Stop()
        {
            fired = false;
            timeGap = 0;
            State.Stop();
        }

        public void Die()
        {
            State.Die();
        }

        public void Reverse()
        {
            velocity.X *= -1;
        }

        public void resetHits()
        {
            this.downhit = false;
            this.uphit = false;
            this.lefthit = false;
            this.righthit = false;
            this.stuck = false;
        }

        public void Throw()
        {
            // projectiles stored in list, only three at a time on screen
            if (health == Mario.MarioHealth.Fire)
            {
                if (!fired)
                {
                    fireProjectile.addProjectile("PlayerFireRight", position, facingLeft);
                    fired = true;
                }

                State.Throw();
            }
        }

        public void TakeDamage()
        {
            switch (health)
            {
                case MarioHealth.Fire:
                    health = MarioHealth.Big;
                    break;
                case MarioHealth.Raccoon:
                    health = MarioHealth.Big;
                    break;
                case MarioHealth.Big:
                    health = MarioHealth.Normal;
                    break;
                case MarioHealth.Normal:
                    health = MarioHealth.Dead;
                    break;
            }
        }

        // Will change with game functionality
        public void ChangeToFire()
        {
            if (health == MarioHealth.Normal)
            {
                position = new Vector2(position.X, position.Y - sizeDiff);
            }
            health = MarioHealth.Fire;
        }

        public void ChangeToRaccoon()
        {
            if (health == MarioHealth.Normal)
            {
                position = new Vector2(position.X, position.Y - sizeDiff);
            }
            health = MarioHealth.Raccoon;
        }

        public void ChangeToBig()
        {
            if (health == MarioHealth.Normal)
            {
                position = new Vector2(position.X, position.Y - sizeDiff);
            }
            health = MarioHealth.Big;
        }

        public void ChangeToNormal()
        {
            if (health != MarioHealth.Normal)
            {
                position = new Vector2(position.X, position.Y + sizeDiff);
            }
            health = MarioHealth.Normal;
        }


        public void applyGravity()
        {

            position = new Vector2(position.X, position.Y + gravity);

        }

        public void UpdateMovement(GameTime gametime)
        {
            // updates movement using pos +/- v * dt

            if (facingLeft)
            {
                position = new Vector2(position.X - (velocity.X * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f))), position.Y);
            }
            else
            {
                position = new Vector2(position.X + (velocity.X * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f))), position.Y);
            }
            position = new Vector2(position.X, position.Y + (velocity.Y * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f))));


        }

        public void LeftStuck(GameTime gametime)
        {

        }
        public void RightStuck(GameTime gametime)
        {

        }

        public void UpStuck()
        {
            //position.Y -= (gravity / 2);
        }

        public void Update(GameTime gametime)
        {
            // UpdateProjectiles(gametime);        

            if (!(pose == MarioPose.Throwing))
            {
                fired = false;
            }

            State.Update(gametime);
            UpdateMovement(gametime);
            applyGravity();

            Destination = currentSprite.destination;
            resetHits();

        }


        public void Draw(SpriteBatch spritebatch)
        {
            currentSprite.Draw(spritebatch, position, Color.White);
        }
    }
}
