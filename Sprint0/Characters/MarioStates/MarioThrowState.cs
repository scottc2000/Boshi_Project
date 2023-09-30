using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.ComponentModel.Design;

namespace Sprint0.Characters.MarioStates
{
    internal class MarioThrowState : ICharacterState
    {
        private Mario mario;

        public MarioThrowState(Mario mario)
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


        }

        public void Die()
        {
            // mario.marioSprite = CharacterSpriteFactory.Instance.CreateDeadMarioSprite();
        }
        public void Update(GameTime gametime)
        {
            mario.pose = Mario.MarioPose.Throwing;
            if (mario.facingLeft && mario.health == Mario.MarioHealth.Fire)
            {
                if (mario.currentSprite.spriteName.Equals("FireMarioThrowLeft"))
                {

                    mario.currentSprite.Update(gametime);
                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("FireMarioThrowLeft");
                }
            }
            else
            {
                if (mario.currentSprite.spriteName.Equals("FireMarioThrowRight"))
                {

                    mario.currentSprite.Update(gametime);
                }
                else
                {
                    mario.currentSprite = mario.mySpriteFactory.returnSprite("FireMarioThrowRight");
                }
            }
        }
    }
}