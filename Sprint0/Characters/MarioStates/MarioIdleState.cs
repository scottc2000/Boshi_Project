using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactories;
using System;
using System.Runtime.CompilerServices;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioIdleState : ICharacterState
    {
        private Mario mario;
        public MarioIdleState(Mario mario)
        {
            this.mario = mario;
        }

        public void Move()
        {
            mario.State = new MarioMoveState(mario);
        }

        public void Jump()
        {
            mario.State = new MarioJumpState(mario);
        }

        public void Crouch()
        {
            mario.State = new MarioCrouchState(mario);
        }


        public void Throw()
        {

            mario.State = new MarioThrowState(mario);

        }

        public void Stop()
        {

        }


        public void Die()
        {
            mario.State = new DeadMarioState(mario);
        }
        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Idle;
            if (mario.facingLeft)
            {
                switch (mario.health)
                {
                    case (Mario.MarioHealth.Normal):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateNormalMarioLeftIdle();
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateRaccoonMarioLeftIdle();
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateFireMarioLeftIdle();
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateFireMarioLeftIdle();
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
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateNormalMarioRightIdle();
                            break;
                        }

                    case (Mario.MarioHealth.Raccoon):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateRaccoonMarioRightIdle();
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateFireMarioRightIdle();
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateBigMarioRightIdle();
                            break;
                        }
                }
            }
        }
    }
}