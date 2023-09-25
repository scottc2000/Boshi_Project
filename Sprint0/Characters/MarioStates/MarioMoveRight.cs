using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioMoveRight : ICharacterState
    {
        private Mario mario;

        public MarioMoveRight(Mario mario)
        {
            this.mario = mario;
        }
        public void ChangeDirection()
        {
            mario.marioState = new MarioMoveLeft(mario);
        }

        public void Move()
        {

        }

        public void Stop() {
            mario.marioState = new MarioFaceRight(mario);
        }

        public void Draw()
        {
            switch (mario.health)
            {
                case (Mario.MarioHealth.Normal):
                    {
                        //sprite
                        break;
                    }


                case (Mario.MarioHealth.Star):
                    {
                        //sprite
                        break;
                    }

                case (Mario.MarioHealth.Fire):
                    {
                        //sprite
                        break;
                    }

                case (Mario.MarioHealth.Big):
                    {
                        //sprite
                        break;
                    }

            }
        }
    }
}
