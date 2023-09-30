using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.HammerBroStates
{
    public class RightMovingKoopaState : IEnemyState
    {
        private readonly Koopa koopa;

        public RightMovingKoopaState (Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void ChangeDirection()
        {
            koopa.state = new LeftMovingKoopaState(koopa);
            koopa.facingLeft = true;
        }

        public void BeStomped()
        {

        }

        public void BeFlipped()
        {

        }

        public void Update()
        {
            koopa.Move();
        }
    }
}
