using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.HammerBroStates
{
    public class LeftMovingKoopaState : IEnemyState
    {
        private readonly Koopa koopa;

        public LeftMovingKoopaState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void ChangeDirection()
        {
            koopa.state = new RightMovingKoopaState(koopa);
            koopa.facingLeft = false;
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
