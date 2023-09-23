using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters
{
    internal class Mario : ICharcter
    {
        private MarioStateMachine stateMachine;

        public Mario() { 
            stateMachine = new MarioStateMachine();
           
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }
        public void CrouchingLeft()
        {
            stateMachine.CrouchingLeft();
        }
        public void BeFlipped()
        {
            stateMachine.BeFlipped();
        }
        public void Update()
        {

        }
    }
}
