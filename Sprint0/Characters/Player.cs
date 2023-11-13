using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.PlayerStates;
using Sprint0.Interfaces;
using Sprint0.Items.Projectiles;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.SpriteFactories;
using Sprint0.Utility;

namespace Sprint0.Characters
{
    public class Player : IPlayer
    {
        public Sprint0 mySprint;
        private PlayerNumbers player;
        
        // Player information
        public ICharacterState State { get; set; }
        public enum PlayerHealth { Normal, Raccoon, Fire, Big, Dead };
        public PlayerHealth health { get; set; }

        public enum PlayerPose { Jump, Crouch, Idle, Walking, Throwing };
        public Vector2 position { get; set; }
        public PlayerPose pose { get; set; }
        public bool isInvinsible { get; set; }
        public int flyingTimer { get; set; }
        public int runningTimer { get; set; }
        public bool boosted { get; set; }
        public bool facingLeft { get; set; }

        public bool fired { get; set; }
        public int number { get; set; }

        int sizeDiff;

        // ICollidable
        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }

        // Physics components - on refactor list
        public Vector2 velocity;
        public float decay;
        public float gravity;
        public int timeGap;

        // Sprite
        public AnimatedSpritePlayer currentSprite {get; set; }
        public CharacterSpriteFactory mySpriteFactory;
        public Rectangle Destination { get; set; }

        public FireProjectile fireProjectile { get; set; }

        public Player(Sprint0 sprint0, int playerNumber)
        {
            mySprint = sprint0;
            player = new PlayerNumbers();

            health = PlayerHealth.Big;
            State = new PlayerIdleState(this);

            // default position stuff
            flyingTimer = 0;
            boosted = false;
            facingLeft = false;

            if (playerNumber == player.mario)
            {
                number = player.mario;
                position = player.marioPosition;
            }
            else if (playerNumber == player.luigi)
            {
                number = player.luigi;
                position = player.luigigPosition;
            }

            sizeDiff = player.sizeDiff;
            fired = false;
            timeGap = 0;
            runningTimer = 0;
            flyingTimer = 0;

            // Collidables
            downhit = false;
            uphit = false;
            lefthit = false;
            righthit = false;

            // default velocity is zero (still), decay makes player slippery the higher it is.
            velocity = player.velocity;
            decay = 0.9f;
            stuck = false;
            gravity = 1.0f;

            // creates new sprite factory and projectile factory
            mySpriteFactory = new CharacterSpriteFactory(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

            fireProjectile = new FireProjectile(mySprint.Content);

            if (playerNumber == player.mario)
                currentSprite = mySpriteFactory.returnMarioSprite(player.MarioIdleRight);
            else if (playerNumber == player.luigi)
                currentSprite = mySpriteFactory.returnLuigiSprite(player.LuigiIdleRight);

            Destination = currentSprite.destination;

        }

        /* ----------------------- Player States --------------------*/
        public void Move()
        {
            if (health != PlayerHealth.Dead)
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
            if (uphit && health != PlayerHealth.Dead)
            {
                State.Jump();
            }
        }
        public void Fall()
        {
            if (health != PlayerHealth.Dead)
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
            velocity.X *= player.reverse;
        }
        public void resetHits()
        {
            downhit = false;
            uphit = false;
            lefthit = false;
            righthit = false;
            stuck = false;
        }
        public void Throw()
        {
            // projectiles stored in list, only three at a time on screen
            if (health == PlayerHealth.Fire)
            {
                if (!fired)
                {
                    fireProjectile.addProjectile(player.PlayerFire, position, facingLeft);
                    fired = true;
                }

                State.Throw();
            }
        }
        public void ChangeToFire()
        {
            if (health == PlayerHealth.Normal)
            {
                position = new Vector2(position.X, position.Y - sizeDiff);
            }
            health = PlayerHealth.Fire;
        }
        public void ChangeToRaccoon()
        {
            if (health == PlayerHealth.Normal)
            {
                position = new Vector2(position.X, position.Y - sizeDiff);
            }
            health = PlayerHealth.Raccoon;
        }
        public void ChangeToBig()
        {
            if (health == PlayerHealth.Normal)
            {
                position = new Vector2(position.X, position.Y - sizeDiff);
            }
            health = PlayerHealth.Big;
        }
        public void ChangeToNormal()
        {
            if (health != PlayerHealth.Normal)
            {
                position = new Vector2(position.X, position.Y + sizeDiff);
            }
            health = PlayerHealth.Normal;
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
                position = new Vector2(position.X - (velocity.X * ((float)gametime.ElapsedGameTime.TotalSeconds / player.sixth)), position.Y);
            }
            else
            {
                position = new Vector2(position.X + (velocity.X * ((float)gametime.ElapsedGameTime.TotalSeconds / player.sixth)), position.Y);
            }
            position = new Vector2(position.X, position.Y + (velocity.Y * ((float)gametime.ElapsedGameTime.TotalSeconds / player.sixth)));
        }

        // Are these no longer used? please remove if so
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

            if (!(pose == PlayerPose.Throwing))
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