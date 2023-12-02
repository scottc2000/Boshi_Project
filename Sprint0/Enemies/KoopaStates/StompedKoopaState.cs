using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.HammerBroStates
{
    public class StompedKoopaState : IEnemyState
    {
        private readonly Koopa koopa;

        public StompedKoopaState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void ChangeDirection()
        {
            
        }

        public void BeStomped()
        {

        }

        public void BeFlipped()
        {

        }

        public void Update()
        {
            
        }

        public void startSwarm()
        {
        }
    }
}
