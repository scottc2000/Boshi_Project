using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface ICharacter
    {
        public void ChangeDirection();

        public void MoveRight();

        public void MoveLeft();

        public void Jump();

        public void Crouch();

        public void Stop();

        void Update();

    }
}
