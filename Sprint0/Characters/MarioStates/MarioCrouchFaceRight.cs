using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioCrouchFaceRight : ICharacterState
    {
        private Mario mario;

        public MarioCrouchFaceRight(Mario mario)
        {
            this.mario = mario;
        }
        public void ChangeDirection()
        {
            mario.marioState = new MarioCrouchFaceLeft(mario);
        }
        public void Move()
        {

        }

        public void Stop()
        {

        }
    }
}
