using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactories;
using Sprint0.Utility;
using System;
using System.ComponentModel.Design;
using static Sprint0.Characters.Mario;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.MarioStates
{
    internal class DeadMarioState : ICharacterState
    {
        private Mario mario;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames FileNames = new FileNames();

        public DeadMarioState(Mario mario)
        {
            this.mario = mario;
            audioManager.PlaySFX(FileNames.deathSFX);
            audioManager.StopMusic();
        }

        public void Crouch()
        {
        }

        public void Die()
        {

        }

        public void Fall()
        {
        }

        public void Fly()
        {
        }

        public void Jump()
        {
        }

        public void Move()
        {
        }

        public void Stop()
        {
        }

        public void Throw()
        {

        }
        public void TakeDamage() 
        {

        }
        public void Update(GameTime gametime)
        {
            mario.health = Mario.MarioHealth.Dead;
            mario.currentSprite = mario.mySpriteFactory.returnSprite("MarioDead");
            mario.velocityY = -1;
        }
    }
}