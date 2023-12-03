using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.BowserStates
{
    internal class BowserLookState : IEnemyBowserState
    {
        private Bowser bowser;

        public BowserLookState(Bowser bowser)
        {
            this.bowser = bowser;
            this.bowser.velocity.X = 0;
            this.bowser.velocity.Y = 0;
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
            bowser.state = new BowserFallState(bowser);
        }
        public void Look()
        {

        }
        public void Die()
        {

        }
        public void Fireball()
        {

        }
        public void Update(GameTime gametime)
        {
            bowser.Wait(gametime);
        }

    }
}
