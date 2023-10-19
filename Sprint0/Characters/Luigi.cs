using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.SpriteFactories;
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
        int sizeDiff;

        public AnimatedSpriteLuigi currentSprite;
        public CharacterSpriteFactoryLuigi mySpriteFactory;


        public Luigi(Sprint0 sprint0)
        {
            this.health = LuigiHealth.Big;
            this.State = new LuigiIdleState(this);

            this.facingLeft = true;
            this.position.X = 350;
            this.position.Y = 350;
            this.sizeDiff = 25;

            this.mySprint = sprint0;
            mySpriteFactory = new CharacterSpriteFactoryLuigi(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

            currentSprite = mySpriteFactory.returnSprite("LuigiStillLeft");

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


        public void Update(GameTime gametime)
        {
            State.Update(gametime);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            currentSprite.Draw(spritebatch, position);
        }
    }
}