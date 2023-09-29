using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Characters
{
    public class Mario : ICharacter
    {
        public enum MarioHealth { Normal, Raccoon, Fire, Big};
        public MarioHealth health = MarioHealth.Normal;

        public enum MarioPose { Jump, Crouch, Idle, Walking};
        public MarioPose pose = MarioPose.Idle;
        public bool facingLeft { get; set; }

        public ICharacterState State { get; set; }

        public Vector2 position;
        public Sprint0 mySprint;

        public ISprite marioSprite;
        public Texture2D marioTexture;


        public Mario(Sprint0 sprint0)
        {
            this.health = MarioHealth.Normal;
            this.State = new MarioIdleState(this);

            this.facingLeft = true;

            this.position.X= 150;
            this.position.Y = 150;
            this.mySprint = sprint0;

            this.marioSprite = new MarioLeftIdleSprite(mySprint, this);
            marioTexture = mySprint.Content.Load<Texture2D>("SpriteImages/playerssclear");
            //this.marioSprite = CharacterSpriteFactory.Instance.CreateMarioIdleRightSprite();

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
    
        // Will change with game functionality
        public void ChangeToFire()
        {
            health = MarioHealth.Fire;
            State.ChangeHealth();
        }

        public void ChangeToRaccoon()
        {
            health = MarioHealth.Raccoon;
            State.ChangeHealth();
        }

        public void ChangeToBig()
        {
            health = MarioHealth.Big;
            State.ChangeHealth();
        }

        public void ChangeToNormal()
        {
            health = MarioHealth.Normal;
            State.ChangeHealth();
        }

        public void Update(GameTime gametime)
        {
           State.Update(gametime);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            marioSprite.Draw(spritebatch);
        }
    }
}
