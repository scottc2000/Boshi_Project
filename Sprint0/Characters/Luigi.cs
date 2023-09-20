using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters
{
    internal class Luigi : ICharcter
    {
        private LuigiStateMachine stateMachine;

        public Luigi()
        {
            stateMachine = new LuigiStateMachine();
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }
        public void BeStomped()
        {
           stateMachine.BeStomped();
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