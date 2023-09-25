using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioFaceRight : ICharacterState
    {
        private Mario mario;

        public MarioFaceRight(Mario mario)
        {
            this.mario = mario;
        }
        public void ChangeDirection()
        {
            mario.marioState = new MarioFaceLeft(mario);
        }

        public void Move()
        {
            mario.marioState = new MarioMoveRight(mario);
        }

        public void Stop()
        {

        }
    }
}
