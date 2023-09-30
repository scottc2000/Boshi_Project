using Sprint0.Enemies.GoombaStates;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.GooombaStates
{
    public class LeftMovingGoombaState : IEnemyState
    {
        private readonly Goomba goomba;

        public LeftMovingGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
        }

        public void ChangeDirection()
        {
            goomba.state = new RightMovingGoombaState(goomba);
            goomba.facingLeft = false;
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
