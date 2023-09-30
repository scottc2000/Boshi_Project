using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;

namespace Sprint0.Characters
{
    public class Luigi : ICharacter
    {
        public enum LuigiHealth { Normal, Raccoon, Fire, Big };
        public LuigiHealth health = LuigiHealth.Normal;

        public enum LuigiPose { Jump, Crouch, Idle, Walking, Throwing };
        public LuigiPose pose = LuigiPose.Idle;
        public bool facingLeft { get; set; }

        public ICharacterState State { get; set; }

        public Vector2 position;
        public Sprint0 mySprint;

        public AnimatedSprite currentSprite;
        public CharacterSpriteFactory mySpriteFactory;


        public Luigi(Sprint0 sprint0)
        {
            this.health = LuigiHealth.Normal;
            this.State = new LuigiIdleState(this);

            this.facingLeft = true;
            this.position.X = 150;
            this.position.Y = 150;

            this.mySprint = sprint0;
            //mySpriteFactory = new CharacterSpriteFactory(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

            currentSprite = mySpriteFactory.returnSprite("NormalLuigiStillLeft");

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

        public void Throw()
        {
            if (health == Luigi.LuigiHealth.Fire)
            {
                State.Throw();
            }
        }

        // Will change with game functionality
        public void ChangeToFire()
        {
            health = LuigiHealth.Fire;
        }

        public void ChangeToRaccoon()
        {
            health = LuigiHealth.Raccoon;
        }

        public void ChangeToBig()
        {
            health = LuigiHealth.Big;
        }

        public void ChangeToNormal()
        {
            health = LuigiHealth.Normal;
        }


        public void Update(GameTime gametime)
        {
            State.Update(gametime);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            currentSprite.Draw(spritebatch);
        }
    }
}