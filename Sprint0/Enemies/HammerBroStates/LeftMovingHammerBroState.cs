using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.HammerBroStates
{
    public class LeftMovingHammerBroState : IEnemyState
    {
        private readonly HammerBro hammerBro;

        public LeftMovingHammerBroState(HammerBro hammerBro)
        {
            this.hammerBro = hammerBro;
        }

        public void ChangeDirection()
        {
            hammerBro.state = new RightMovingHammerBroState(hammerBro);
            hammerBro.facingLeft = false;
        }

        public void BeStomped()
        {

        }

        public void BeFlipped()
        {

        }

        public void Update()
        {
            hammerBro.Move();
        }

        public void startSwarm()
        {
        }
    }
}
