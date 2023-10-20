using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.SpriteFactories;
using System;
using static Sprint0.Characters.Mario;

namespace Sprint0.Characters
{

    
    public class Mario : ICharacter, IObject
    {
        public enum Health { Normal, Raccoon, Fire, Big, Dead };
        public Health health = Health.Normal;

        public enum MarioPose { Jump, Crouch, Idle, Walking, Throwing };
        public MarioPose pose = MarioPose.Idle;
        public bool facingLeft { get; set; }

        public ICharacterState State { get; set; }

        public Vector2 position { get; set; }

        public Sprint0 mySprint;
        int sizeDiff;

        public AnimatedSpriteMario currentSprite;
        public CharacterSpriteFactoryMario mySpriteFactory;

        public Mario(Sprint0 sprint0)
        {
            health = Health.Normal;
            State = new MarioIdleState(this);

            facingLeft = true;
            position = new Vector2(150, 350);

            sizeDiff = 25;

            mySprint = sprint0;
            mySpriteFactory = new CharacterSpriteFactoryMario(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

            currentSprite = mySpriteFactory.returnSprite("MarioStillLeft");

        }
        public void Move()
        {
            State.Move();
        }

        public void Jump()
        {
            State.Jump();
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
            State.Stop();
        }

        public void Die()
        {
            State.Die();
        }

        public void Throw()
        {
            if (health == Health.Fire)
            {
                State.Throw();
            }
        }

        // Will change with game functionality
        public void ChangeToFire()
        {
            if (health == Health.Normal)
            {
                position = new Vector2(position.X, position.Y - sizeDiff);
            }
            health = Health.Fire;
        }

        public void ChangeToRaccoon()
        {
            if (health == Health.Normal)
            {
                position = new Vector2(position.X, position.Y - sizeDiff);
            }
            health = Health.Raccoon;
        }

        public void ChangeToBig()
        {
            if (health == Health.Normal)
            {
                position = new Vector2(position.X, position.Y - sizeDiff);
            }
            health = Health.Big;
        }

        public void ChangeToNormal()
        {
            if (health != Health.Normal)
            {
                position = new Vector2(position.X, position.Y + sizeDiff);
            }
            health = Health.Normal;
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