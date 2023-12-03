using Microsoft.Xna.Framework;
using MonoGame.Extended.Timers;
using Sprint0.Interfaces;
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
        private float yVelocity = 3.0f;

        public BowserFallState(Bowser bowser)
        {
            this.bowser = bowser;
            this.bowser.velocity.Y = yVelocity;
        }

        public void Move()
        {

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
            bowser.state = new BowserIdleState(bowser);
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
        }

    }
}
