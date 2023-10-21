using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Camera;
using Sprint0.Characters.MarioStates;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.Players;
using Sprint0.Sprites.SpriteFactories;
using System;
using static Sprint0.Characters.Mario;

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

        public Sprint0 mySprint;
        int sizeDiff;
        public Vector2 position;

        public AnimatedSpriteMario currentSprite;
        public CharacterSpriteFactoryMario mySpriteFactory;
        public Camera1 camera;

        public Mario(Sprint0 sprint0)
        {
            health = MarioHealth.Normal;
            State = new MarioIdleState(this);

            facingLeft = true;
            sizeDiff = 25;
            position.X = 200;
            position.Y = 400;

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
            if (health == MarioHealth.Fire)
            {
                State.Throw();
            }
        }

        // Will change with game functionality
        public void ChangeToFire()
        {
            if (health == MarioHealth.Normal)
            {
                position.Y -= sizeDiff;
            }
            health = MarioHealth.Fire;
        }

        public void ChangeToRaccoon()
        {
            if (health == MarioHealth.Normal)
            {
                position.Y -= sizeDiff;
            }
            health = MarioHealth.Raccoon;
        }

        public void ChangeToBig()
        {
            if (health == MarioHealth.Normal)
            {
                position.Y -= sizeDiff;
            }
            health = MarioHealth.Big;
        }

        public void ChangeToNormal()
        {
            if (health != MarioHealth.Normal)
            {
                position.Y += sizeDiff;
            }
            health = MarioHealth.Normal;
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