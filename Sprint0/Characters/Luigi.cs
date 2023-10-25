using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.LuigiStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.Projectile;
using Sprint0.Sprites.SpriteFactories;
using System.Collections.Generic;

namespace Sprint0.Characters
{
    public class Luigi : ICharacter
    {
        public enum LuigiHealth { Normal, Raccoon, Fire, Big, Dead };
        public LuigiHealth health = LuigiHealth.Normal;

        public enum LuigiPose { Jump, Crouch, Idle, Walking, Throwing };
        public LuigiPose pose = LuigiPose.Idle;
        public bool facingLeft { get; set; }
        public bool fired;

        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }

        public float velocityX;
        public float velocityY;
        public float decay;
        public float gravity;
        public int timeGap;


        public ICharacterState State { get; set; }


        public Vector2 position;
        public Sprint0 mySprint;
        int sizeDiff;
        public Rectangle destination { get; set; }

        public AnimatedSpriteLuigi currentSprite;
        public CharacterSpriteFactoryLuigi mySpriteFactory;

        public ProjectileSpriteFactory projectileFactory;

        public List<AnimatedProjectile> ThrownProjectiles;



        public Luigi(Sprint0 sprint0)
        {
            this.health = LuigiHealth.Normal;
            this.State = new LuigiIdleState(this);

            // default position stuff
            this.facingLeft = true;
            this.position.X = 100;
            this.position.Y = 400;
            this.sizeDiff = 25;
            this.fired = false;
            this.timeGap = 0;

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

            projectileFactory = new ProjectileSpriteFactory();

            ThrownProjectiles = new List<AnimatedProjectile>();

            projectileFactory.LoadTextures(mySprint.Content);

            currentSprite = mySpriteFactory.returnSprite("LuigiStillLeft");
            destination = currentSprite.destination;

        }


        public void Move()
        {
            State.Move();
        }

        public void Jump()
        {
            State.Jump();
        }

        public void Crouch()
        {
            State.Crouch();
        }

        public void Stop()
        {
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
            if (health == Luigi.LuigiHealth.Fire)
            {
                if (!fired)
                {
                    ThrownProjectiles.Add(projectileFactory.returnSprite("PlayerFireRight", position, facingLeft));
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
                position.Y -= sizeDiff;
            }
            health = LuigiHealth.Fire;
        }

        public void ChangeToRaccoon()
        {
            if (health == LuigiHealth.Normal)
            {
                position.Y -= sizeDiff;
            }
            health = LuigiHealth.Raccoon;
        }

        public void ChangeToBig()
        {
            if (health == LuigiHealth.Normal)
            {
                position.Y -= sizeDiff;
            }
            health = LuigiHealth.Big;
        }

        public void ChangeToNormal()
        {
            if (health != LuigiHealth.Normal)
            {
                position.Y += sizeDiff;
            }
            health = LuigiHealth.Normal;
        }

        public void UpdateProjectiles(GameTime gametime)
        {
            // checks if projectile is off screen, if so then deletes it
            List<AnimatedProjectile> gone = new List<AnimatedProjectile>();
            foreach (AnimatedProjectile am in ThrownProjectiles)
            {
                am.Update(gametime);
                if (am.pos.X > 850 || am.pos.X < -50)
                {
                    gone.Add(am);
                }
            }

            foreach (AnimatedProjectile item in gone) ThrownProjectiles.Remove(item);
            gone.Clear();
        }


        public void applyGravity()
        { 
            if (!uphit)
            {
                position.Y += this.gravity;
            }

            if (!downhit)
            {
                position.Y += velocityY;
            }

           
        }

        public void UpdateMovement(GameTime gametime)
        {
            // updates movement using pos +/- v * dt

            if (facingLeft)
            {
                position.X -= (velocityX * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f)));
            }
            else
            {
                position.X += (velocityX * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f)));
            }

        }

        public void LeftStuck(GameTime gametime)
        {
            position.X += (velocityX * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f)));
        }
        public void RightStuck(GameTime gametime)
        {
            position.X -= (velocityX * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f)));
        }

        public void UpStuck()
        {
            position.Y -= (gravity / 2);
        }

        public void Update(GameTime gametime)
        {
            UpdateProjectiles(gametime);
            

            if (!lefthit && !stuck)
            {
                UpdateMovement(gametime);
            }

            else if (lefthit && stuck)
            {
                LeftStuck(gametime);
            }

            if (!righthit && !stuck)
            {
                UpdateMovement(gametime);
            }
                
            else if (righthit && stuck)
            {
                RightStuck(gametime);
            }
                   
            destination = currentSprite.destination;

            if (!(pose == LuigiPose.Throwing))
            {
                fired = false;
            }

            applyGravity();

            State.Update(gametime);
            resetHits();

        }


        public void Draw(SpriteBatch spritebatch)
        {

            currentSprite.Draw(spritebatch, position);
            foreach (AnimatedProjectile am in ThrownProjectiles)
            {
                am.Draw(spritebatch);
            }

        }
    }
}