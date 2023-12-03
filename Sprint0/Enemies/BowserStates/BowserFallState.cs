using Microsoft.Xna.Framework;
using MonoGame.Extended.Timers;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.BowserStates
{
    internal class BowserFallState : IEnemyBowserState
    {
        private Bowser bowser;
        private float yVelocity = 2.75f;

        public BowserFallState(Bowser bowser)
        {
            this.bowser = bowser;
            this.bowser.velocity.Y = yVelocity;
        }

        public void Move()
        {

        }
        public void Idle()
        {
            bowser.state = new BowserIdleState(bowser);
        }
        public void Jump()
        {
            bowser.state = new BowserJumpState(bowser);
        }
        public void Fall()
        {
            
        }
        public void Look()
        {
            bowser.state = new BowserLookState(bowser);
        }
        public void Die()
        {

        }
        public void Fireball()
        {

        }
        public void Update(GameTime gametime)
        {
            bowser.Move();
            bowser.currentSprite = setSprite(gametime);
        }

        public AnimatedSpriteBowser setSprite(GameTime gameTime) 
        {

            if (bowser.currentSprite.spriteName.Equals("BowserFall"))
            {
                bowser.currentSprite.Update(gameTime);
            } else
            {
                bowser.currentSprite = bowser.mySpriteFactory.returnSprite("BowserFall");
            }

            return bowser.currentSprite;
        }
    }
}
