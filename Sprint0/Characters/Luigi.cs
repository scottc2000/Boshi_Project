using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.LuigiStates;
using Sprint0.Interfaces;
using Sprint0.Items.Projectiles;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.Projectile;
using Sprint0.Sprites.SpriteFactories;
using System.Collections.Generic;

namespace Sprint0.Characters
{
    public class Luigi : ILuigi
    {
        public enum LuigiHealth { Normal, Raccoon, Fire, Big, Dead };
        public LuigiHealth health { get; set; }

        public enum LuigiPose { Jump, Crouch, Idle, Walking, Throwing };
        public LuigiPose pose { get; set; }
        public bool facingLeft { get; set; }
        public bool fired;

        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }
        public bool isInvinsible { get; set; }
        public int flyingTimer { get; set; }

        public float velocityX;
        public float velocityY;
        public float decay;
        public float gravity;
        public int timeGap;
        public int runningTimer { get; set; }


        public ICharacterState State { get; set; }


        public Vector2 position { get; set; }
        public Sprint0 mySprint;
        int sizeDiff;
        public Rectangle Destination { get; set; }
        public bool boosted { get; set; }


        public AnimatedSpriteLuigi currentSprite {get; set; }
        public CharacterSpriteFactoryLuigi mySpriteFactory;

        public FireProjectile fireProjectile { get; set; }




        public Luigi(Sprint0 sprint0)
        {
            this.health = LuigiHealth.Big;
            this.State = new LuigiIdleState(this);

            // default position stuff
            flyingTimer = 0;
            this.boosted = false;
            this.facingLeft = true;
            this.position = new Vector2(200, 200);
            this.sizeDiff = 25;
            this.fired = false;
            this.timeGap = 0;
            this.runningTimer = 0;
            this.flyingTimer = 0;

            this.downhit = false;
            this.uphit = false;
            this.lefthit = false;
            this.righthit = false;

            // default velocity is zero (still), decay makes player slippery the higher it is.
            this.velocityX = 0.0f;
            this.velocityY = 0.0f;
            this.decay = 0.9f;
            this.stuck = false;
            this.gravity = 1.0f;

            this.mySprint = sprint0;

            // creates new sprite factory and projectile factory
            mySpriteFactory = new CharacterSpriteFactoryLuigi(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

            fireProjectile = new FireProjectile(mySprint.Content);


            currentSprite = mySpriteFactory.returnSprite("LuigiStillLeft");
            Destination = currentSprite.destination;

        }


        public void Move()
        {
            if (health != LuigiHealth.Dead)
            {
                State.Move();
            }
        }

        public void Fly()
        {
            State.Fly();
        }

        public void Jump()
        {
            if (uphit && health != LuigiHealth.Dead)
            {
                State.Jump();
            }
        }

        public void Fall()
        {
            if (health != LuigiHealth.Dead)
            {
                State.Fall();
            }
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
            velocityX *= -1;
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
            if (health == LuigiHealth.Fire)
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
                case LuigiHealth.Fire:
                    health = LuigiHealth.Big;
                    break;
                case LuigiHealth.Raccoon:
                    health = LuigiHealth.Big;
                    break;
                case LuigiHealth.Big:
                    health = LuigiHealth.Normal;
                    break;
                case LuigiHealth.Normal:
                    health = LuigiHealth.Dead;
                    break;
            }
        }

        // Will change with game functionality
        public void ChangeToFire()
        {
            if (health == LuigiHealth.Normal)
            {
                position = new Vector2(position.X, position.Y - sizeDiff);
            }
            health = LuigiHealth.Fire;
        }

        public void ChangeToRaccoon()
        {
            if (health == LuigiHealth.Normal)
            {
                position = new Vector2(position.X, position.Y - sizeDiff);
            }
            health = LuigiHealth.Raccoon;

            if (facingLeft)
                currentSprite = mySpriteFactory.returnSprite("LuigiStillLeft");
            else
                currentSprite = mySpriteFactory.returnSprite("LuigiStillRight");
        }

        public void ChangeToBig()
        {
            if (health == LuigiHealth.Normal)
            {
                position = new Vector2(position.X, position.Y - sizeDiff);
                health = LuigiHealth.Big;
            }
            
        }

        public void ChangeToNormal()
        {
            if (health != LuigiHealth.Normal)
            {
                position = new Vector2(position.X, position.Y + sizeDiff);
            }
            health = LuigiHealth.Normal;
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
                position = new Vector2(position.X - (velocityX * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f))), position.Y);
            }
            else
            {
                position = new Vector2(position.X + (velocityX * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f))), position.Y);
            }
            position = new Vector2(position.X, position.Y + (velocityY * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f))));
            

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

            if (!(pose == LuigiPose.Throwing))
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
            currentSprite.Draw(spritebatch, position);  
        }
    }
}