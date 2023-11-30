using Sprint0.Enemies.GoombaStates;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies.GooombaStates
{
    public class StompedKoopaState : IEnemyState
    {
        private readonly Koopa koopa;

        public StompedKoopaState(Goomba goomba)
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
            koopa.currentSprite = koopa.mySpriteFactory.returnSprite("GoombaStomped");
        }
    }
}
