using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    internal interface ICharacterState
    {
        public void ChangeDirection();

        public void Move();

        public void Stop();
    }
}
