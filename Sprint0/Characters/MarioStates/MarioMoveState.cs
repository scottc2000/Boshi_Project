using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactories;
using System;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioMoveState : ICharacterState
    {
        private Mario mario;

        public MarioMoveState(Mario mario)
        {
            this.mario = mario;
        }

        public void Move()
        {
            if (mario.facingLeft)
            {
                mario.position.X -= 1;
            }
            else
            {
                mario.position.X += 1;
            }
        }

        public void Jump()
        {
            mario.State = new MarioJumpState(mario);
        }

        public void Crouch()
        {
            mario.State = new MarioCrouchState(mario);
        }

        public void Stop()
        {
            mario.State = new MarioIdleState(mario);
        }
        public void Throw()
        {
            mario.State = new MarioThrowState(mario);
        }
        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }

        public void Update(GameTime gametime)
        {

            mario.pose = Mario.MarioPose.Walking;

            if (mario.facingLeft)
            {
                switch (mario.health)
                {
                    case (Mario.MarioHealth.Normal):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateNormalMarioLeftMove();
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateRaccoonMarioLeftMove();
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateFireMarioLeftMove();
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateBigMarioLeftMove();
                            break;
                        }

                }
            }
            else
            {
                switch (mario.health)
                {
                    case (Mario.MarioHealth.Normal):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateNormalMarioRightMove();
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateRaccoonMarioRightMove();
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateFireMarioRightMove();
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateBigMarioRightMove();
                            break;
                        }

                }
            }

            mario.pose = Mario.MarioPose.Walking;

        }
    }
}
