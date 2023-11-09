using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Camera;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.Characters
{
    public class Mario : IMario
    {
        public enum MarioHealth { Normal, Raccoon, Fire, Big, Dead };
        public MarioHealth health { get; set; }

        public enum MarioPose { Jump, Crouch, Idle, Walking, Throwing, Flying };
        public MarioPose pose { get; set; }
        public bool facingLeft { get; set; }

        public ICharacterState State { get; set; }

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
        public int runningTimer { get; set; }
        public int flyingTimer { get; set; }
        public bool boosted { get; set; }

        public Sprint0 mySprint;
        int sizeDiff;
        public Vector2 position { get; set; }

        public Rectangle Destination { get; set; }

        public AnimatedSpriteMario currentSprite { get; set; }
        public CharacterSpriteFactoryMario mySpriteFactory;
        public MarioCamera camera;

        public Mario(Sprint0 sprint0)
        {
            mySprint = sprint0;

            // mario states
            health = MarioHealth.Normal;
            pose = MarioPose.Walking;
            State = new MarioIdleState(this);

            // mario object information
            facingLeft = true;
            sizeDiff = 12;
            position = new Vector2(115, 300);
            
            // timers
            timeGap = 0;
            runningTimer = 0;
            flyingTimer = 0;
            boosted = false;

            resetHits();

            // default velocity is zero (still), decay makes player slippery the higher it is.
            velocity = new Vector2(0,0);
            gravity = 1.0f;
            decay = 0.9f;
            stuck = false;
            isInvinsible = false;

            // Sprite initalization
            mySpriteFactory = new CharacterSpriteFactoryMario(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

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
            if (uphit)
                State.Jump(); 
        }
        public void Fly() 
        { 
            State.Fly();
        }
        public void Fall()  
        { 
            State.Fall();
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
        
        // Throw logic needs to be updated for mario
        public void Throw()
        {
            if (health == MarioHealth.Fire)
                State.Throw();
        }

        /* ----------------------- Health State Changes --------------------*/
        public void ChangeToFire()
        {
            if (health == MarioHealth.Normal)
                position = new Vector2(position.X, position.Y - sizeDiff);
 
            health = MarioHealth.Fire;

            if (facingLeft)
                currentSprite = mySpriteFactory.returnSprite("MarioStillLeft");
            else
                currentSprite = mySpriteFactory.returnSprite("MarioStillRight");
        }
        
        public void ChangeToRaccoon()
        {
            if (health == MarioHealth.Normal)
                position = new Vector2(position.X, position.Y - sizeDiff);

            health = MarioHealth.Raccoon;

            if (facingLeft)
                currentSprite = mySpriteFactory.returnSprite("MarioStillLeft");
            else
                currentSprite = mySpriteFactory.returnSprite("MarioStillRight");
        }

        public void ChangeToBig()
        {
            if (health == MarioHealth.Normal)
                position = new Vector2(position.X, position.Y - sizeDiff);

            health = MarioHealth.Big;

            if (facingLeft)
                currentSprite = mySpriteFactory.returnSprite("MarioStillLeft");
            else
                currentSprite = mySpriteFactory.returnSprite("MarioStillRight");

        }
        public void ChangeToNormal()
        {
            if (health != MarioHealth.Normal)
                position = new Vector2(position.X, position.Y + sizeDiff);
            
            health = MarioHealth.Normal;

            if (facingLeft)
                currentSprite = mySpriteFactory.returnSprite("MarioStillLeft");
            else
                currentSprite = mySpriteFactory.returnSprite("MarioStillRight");
        }

        /* ----------------------- Physics/Collision Methods --------------------*/
        public void UpdateMovement(GameTime gametime)
        {
            // updates movement using pos +/- v * dt

            if (facingLeft)
                position = new Vector2(position.X - (velocity.X * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f))), position.Y);
            else
                position = new Vector2(position.X + (velocity.X * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f))), position.Y);

            position = new Vector2(position.X, position.Y + (velocity.Y * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f))));
        }

        public void applyGravity()
        {
            position = new Vector2(position.X, position.Y + gravity);
        }

        // Stuck methods
        public void LeftStuck(GameTime gametime) { position = new Vector2(position.X + (velocity.X * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f))), position.Y); }
        public void RightStuck(GameTime gametime) { position = new Vector2(position.X - (velocity.X * ((float)gametime.ElapsedGameTime.TotalSeconds / (1.0f / 60.0f))), position.Y); }
        public void UpStuck()   { position = new Vector2(position.X, position.Y - (gravity/2));  }

        public void Reverse() { velocity.X *= -1; }
        public void resetHits()
        {
            this.downhit = false;
            this.uphit = false;
            this.lefthit = false;
            this.righthit = false;
            this.gothit = false;
            this.stuck = false;
        }

        /* ----------------------- Update & Draw --------------------*/
        public void Update(GameTime gametime)
        {
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
