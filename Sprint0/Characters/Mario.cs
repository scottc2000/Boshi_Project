﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Camera;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.SpriteFactories;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters
{
    public class Mario : ICharacter
    {
        public enum MarioHealth { Normal, Raccoon, Fire, Big, Dead };
        public MarioHealth health = MarioHealth.Normal;

        public enum MarioPose { Jump, Crouch, Idle, Walking, Throwing };
        public MarioPose pose = MarioPose.Idle;
        public bool facingLeft { get; set; }

        public ICharacterState State { get; set; }

        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }

        public Vector2 velocity;
        public float decay;
        public float gravity;
        public int timeGap;

        public Sprint0 mySprint;
        int sizeDiff;
        public Vector2 position;
        public Rectangle destination { get; set; }

        public AnimatedSpriteMario currentSprite;
        public CharacterSpriteFactoryMario mySpriteFactory;
        public MarioCamera camera;

        public Mario(Sprint0 sprint0)
        {
            health = MarioHealth.Normal;
            State = new MarioIdleState(this);

            facingLeft = true;
            sizeDiff = 12;
            position.X = 300;
            position.Y = 400;
            timeGap = 0;

            this.downhit = false;
            this.uphit = false;
            this.lefthit = false;
            this.righthit = false;
            this.gothit = false;

            // default velocity is zero (still), decay makes player slippery the higher it is.
            this.velocity = new Vector2(0,0);
            this.gravity = 1f;
            this.decay = 0.9f;
            this.stuck = false;

            mySprint = sprint0;
            mySpriteFactory = new CharacterSpriteFactoryMario(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

            currentSprite = mySpriteFactory.returnSprite("MarioStillLeft");
            destination = currentSprite.destination;

        }
        public void Move()  {   State.Move();   }

        public void Jump()  {   State.Jump();   }
        public void Fall()  {   State.Fall();   }

        public void Crouch()    {   State.Crouch();    }

        public void Stop()  {   State.Stop();   }

        public void Die()   
        {
            if (health == MarioHealth.Dead)
            {
                // Set the sprite to the "Mario dead" sprite
                currentSprite = mySpriteFactory.returnSprite("MarioDead");
            }
        }

        public void Reverse()   {   velocity *= -1; }
        public void resetHits()
        {
            this.downhit = false;
            this.uphit = false;
            this.lefthit = false;
            this.righthit = false;
            this.gothit = false;
            this.stuck = false;
        }
        public void TakeDamage()
        {
            if (health == MarioHealth.Normal)
            {
                health = MarioHealth.Dead;
                State.Die();
                velocity = Vector2.Zero; // Stop movement
            }
            else
            {
                // Handle other health states as you were previously doing
                switch (health)
                {
                    case MarioHealth.Fire:
                        health = MarioHealth.Big;
                        State.TakeDamage();
                        break;
                    case MarioHealth.Raccoon:
                        health = MarioHealth.Big;
                        State.TakeDamage();
                        break;
                    case MarioHealth.Big:
                        health = MarioHealth.Normal;
                        State.TakeDamage();
                        break;
                }
            }
            System.Diagnostics.Debug.WriteLine("health in MarioClass; " + health);
        }
        public void Throw()
        {
            if (health == MarioHealth.Fire)
            {
                State.Throw();
            }
        }

        public void ChangeToFire()
        {
            if (health == MarioHealth.Normal)
            {
                position.Y -= sizeDiff;
            }
            health = MarioHealth.Fire;

            if (facingLeft)
                currentSprite = mySpriteFactory.returnSprite("MarioStillLeft");
            else
                currentSprite = mySpriteFactory.returnSprite("MarioStillRight");

        }
        
        public void ChangeToRaccoon()
        {
            if (health == MarioHealth.Normal)
            {
                position.Y -= sizeDiff;
            }
            health = MarioHealth.Raccoon;

            if (facingLeft)
                currentSprite = mySpriteFactory.returnSprite("MarioStillLeft");
            else
                currentSprite = mySpriteFactory.returnSprite("MarioStillRight");

        }

        public void ChangeToBig()
        {
            if (health == MarioHealth.Normal)
            {
                position.Y -= sizeDiff;
            }
            health = MarioHealth.Big;

            if (facingLeft)
                currentSprite = mySpriteFactory.returnSprite("MarioStillLeft");
            else
                currentSprite = mySpriteFactory.returnSprite("MarioStillRight");

        }

        public void ChangeToNormal()
        {
            if (health != MarioHealth.Normal)
            {
                position.Y += sizeDiff;
            }
            health = MarioHealth.Normal;

            if (facingLeft)
                currentSprite = mySpriteFactory.returnSprite("MarioStillLeft");
            else
                currentSprite = mySpriteFactory.returnSprite("MarioStillRight");

        }

        public void UpdateMovement(GameTime gametime)
        {
            // updates movement using pos +/- v * dt

            if (facingLeft)
                position.X -= (velocity.X * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f)));
            else
                position.X += (velocity.X * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f)));
        }

        public void applyGravity()
        {
            if (!uphit)
                position.Y += this.gravity;

            if (!downhit)
                position.Y += velocity.Y;
        }

        // Stuck methods
        public void LeftStuck() {    position.X += 1;   }
        public void RightStuck() {   position.X -= 1;   }
        public void UpStuck()   {   position.Y -= (gravity / 2);    
        }
        public void Update(GameTime gametime)
        {
            if (!lefthit && !stuck)
                UpdateMovement(gametime);
            else if (lefthit && stuck)
                LeftStuck();

            if (!righthit && !stuck)
                UpdateMovement(gametime);
            else if (righthit && stuck)
                RightStuck();

            if (gothit)
                TakeDamage();

            State.Update(gametime);
            applyGravity();
            destination = currentSprite.destination;
            resetHits();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            currentSprite.Draw(spritebatch, position);
        }
    }
}
