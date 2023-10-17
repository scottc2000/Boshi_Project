using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using static Sprint0.Sprites.PlayerData;

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

        public ICharacterState State { get; set; }

        public Vector2 position;
        public Sprint0 mySprint;
        int sizeDiff;

        public AnimatedSpriteLuigi currentSprite;
        public CharacterSpriteFactoryLuigi mySpriteFactory;

        public ProjectileSpriteFactory projectileFactory;

        public List<AnimatedProjectile> ThrownProjectiles;

        public Luigi(Sprint0 sprint0)
        {
            this.health = LuigiHealth.Big;
            this.State = new LuigiIdleState(this);

            this.facingLeft = true;
            this.position.X = 350;
            this.position.Y = 350;
            this.sizeDiff = 25;
            this.fired = false;

            this.mySprint = sprint0;
            mySpriteFactory = new CharacterSpriteFactoryLuigi(this);
            mySpriteFactory.LoadTextures(mySprint.Content);

            projectileFactory = new ProjectileSpriteFactory();

            ThrownProjectiles = new List<AnimatedProjectile>();

            projectileFactory.LoadTextures(mySprint.Content);

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
            List<AnimatedProjectile> gone = new List<AnimatedProjectile>();
            foreach (AnimatedProjectile am in ThrownProjectiles)
            {
                am.Update(gametime);
                if (am.pos.X > 850)
                {
                    gone.Add(am);
                }
            }

            gone.Clear();



        }

        public void Update(GameTime gametime)
        {
            UpdateProjectiles(gametime);
            State.Update(gametime);
            if (!(pose == LuigiPose.Throwing))
            {
                fired = false;
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            currentSprite.Draw(spritebatch);
            foreach (AnimatedProjectile am in ThrownProjectiles)
            {
                am.Draw(spritebatch);
            }

        }
    }
}