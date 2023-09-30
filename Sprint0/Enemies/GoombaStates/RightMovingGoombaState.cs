using Sprint0.Enemies.GooombaStates;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.GoombaStates
{
    public class RightMovingGoombaState : IEnemyState
    {
        private readonly Goomba goomba;

        public RightMovingGoombaState (Goomba goomba)
        {
            this.goomba = goomba;
        }

        public void ChangeDirection()
        {
            goomba.state = new LeftMovingGoombaState(goomba);
            goomba.facingLeft = true;
        }

        public void BeStomped()
        {

        }

        public void BeFlipped()
        {

        }

        public void Update()
        {
            goomba.Move();
        }
    }
}
