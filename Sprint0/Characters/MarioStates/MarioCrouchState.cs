using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactories;
using System;
using System.ComponentModel.Design;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioCrouchState : ICharacterState
    {
        private Mario mario;

        public MarioCrouchState(Mario mario)
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
            mario.pose = Mario.MarioPose.Jump;
            if (mario.facingLeft)
            {
                switch (mario.health)
                {
                    case (Mario.MarioHealth.Normal):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateNormalMarioLeftCrouch();
                            break;
                        }


                    case (Mario.MarioHealth.Raccoon):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateRaccoonMarioLeftCrouch();
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateFireMarioLeftCrouch();
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateBigMarioLeftCrouch();
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
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateNormalMarioRightCrouch();
                            break;
                        }

                    case (Mario.MarioHealth.Raccoon):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateRaccoonMarioRightCrouch();
                            break;
                        }

                    case (Mario.MarioHealth.Fire):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateFireMarioRightCrouch();
                            break;
                        }

                    case (Mario.MarioHealth.Big):
                        {
                            mario.currentSprite = SpriteFactoryMario.Instance.CreateBigMarioRightCrouch();
                            break;
                        }
                }
            }
        }
    }
}
