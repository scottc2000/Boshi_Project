using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using System;

namespace Sprint0.Characters
{
    public class Mario : ICharacter
    {
        public enum MarioHealth { Normal, Raccoon, Fire, Big, Dead };
        public MarioHealth health = MarioHealth.Normal;

        public enum MarioPose { Jump, Crouch, Idle, Move, Throw, Dead };
        public MarioPose pose = MarioPose.Idle;
        public bool facingLeft { get; set; }

        public ICharacterState State { get; set; }

        public Vector2 position;
        public Sprint0 mySprint;

        public ISprite currentSprite;


        public Mario(Sprint0 sprint0)
        {
            this.health = MarioHealth.Normal;
            this.State = new MarioIdleState(this);

            this.facingLeft = true;

            this.position.X = 150;
            this.position.Y = 150;
            this.mySprint = sprint0;

            currentSprite = SpriteFactoryMario.Instance.CreateNormalMarioRightIdle();

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
            if (health == Mario.MarioHealth.Fire)
            {
                State.Throw();
            }
        }

        // Will change with game functionality
        public void ChangeToFire()
        {
            health = MarioHealth.Fire;
        }

        public void ChangeToRaccoon()
        {
            health = MarioHealth.Raccoon;
        }

        public void ChangeToBig()
        {
            health = MarioHealth.Big;
        }

        public void ChangeToNormal()
        {
            health = MarioHealth.Normal;
        }


        public void Update(GameTime gametime)
        {
            State.Update(gametime);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            currentSprite.Draw(spritebatch, this.position);
        }
    }
}