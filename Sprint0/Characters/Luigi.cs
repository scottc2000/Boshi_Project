using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.Projectile;
using Sprint0.Sprites.SpriteFactories;
using System.Collections.Generic;

namespace Sprint0.Characters
{
    public class Luigi : ICharacter
    {
        public enum LuigiHealth { Normal, Raccoon, Fire, Big };
        public LuigiHealth health = LuigiHealth.Normal;

        public enum LuigiPose { Jump, Crouch, Idle, Walking, Throwing };
        public LuigiPose pose = LuigiPose.Idle;
        public bool facingLeft { get; set; }
        public bool fired;
        public bool stuck;

        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }

        public float velocity;
        public float decay;


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

            this.downhit = false;
            this.uphit = false;
            this.lefthit = false;
            this.righthit = false;

            // default velocity is zero (still), decay makes player slippery the higher it is.
            this.velocity = 0.0f;
            this.decay = 0.9f;
            this.stuck = false;

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
            State.Stop();
        }

        public void Die()
        {
            State.Die();
        }

        public void Reverse()
        {
            velocity *= -1;
        }

        public void resetHits()
        {
            this.downhit = false;
            this.uphit = false;
            this.lefthit = false;
            this.righthit = false;
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

        public void UpdateMovement(GameTime gametime)
        {
            // updates movement using pos +/- v * dt
            
                if (facingLeft)
                {
                    position.X -= (velocity * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f)));
                }
                else
                {
                    position.X += (velocity * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f)));
                }           

        }

        public void Update(GameTime gametime)
        {
            UpdateProjectiles(gametime);

            if (!lefthit)
            {
                UpdateMovement(gametime);
            }

            State.Update(gametime);
            destination = currentSprite.destination;

            if (!(pose == LuigiPose.Throwing))
            {
                fired = false;
            }

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