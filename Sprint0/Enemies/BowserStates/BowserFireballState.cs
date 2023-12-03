using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.BowserStates
{
    internal class BowserFireballState : IEnemyBowserState
    {
        private Bowser bowser;

        public BowserFireballState(Bowser bowser)
        {
            this.bowser = bowser;
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

        }
        public void Fall()
        {

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
            //
        }

    }
}
