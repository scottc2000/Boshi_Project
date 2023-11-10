using System;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Utility;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.LuigiStates
{
	public class DeadLuigiState : ICharacterState
	{
        Luigi luigi;
        private FileNames FileNames = new FileNames();
        public DeadLuigiState(Luigi luigi)
		{
            this.luigi = luigi;
            AudioManager audioManager = AudioManager.Instance;
            audioManager.PlaySFX(FileNames.deathSFX);
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
        public void Update(GameTime gametime)
        {
            luigi.health = Luigi.LuigiHealth.Dead;
            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiDead");
            luigi.velocityY = -1;
        }
    }
}

