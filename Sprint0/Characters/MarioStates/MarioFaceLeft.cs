using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioFaceLeft : ICharacterState
    {
        private Mario mario;

        public MarioFaceLeft(Mario mario)
        {
            this.mario = mario;
        }
        public void ChangeDirection()
        {
            mario.marioState = new MarioFaceRight(mario);
        }

        public void Move()
        {
            mario.marioState = new MarioMoveLeft(mario);
        }

        public void Stop()
        {

        }

        public void Draw()
        {
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
