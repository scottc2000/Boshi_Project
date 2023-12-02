﻿using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Utility;

namespace Sprint0.Characters.PlayerStates
{
    public class DeadPlayerState : ICharacterState
	{
        Player player;
        private PlayerNumbers check;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames FileNames = new FileNames();
        public DeadPlayerState(Player player)
		{
            this.player = player;
            check = new PlayerNumbers();
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
        public void Update(GameTime gametime)
        {
            player.health = Player.PlayerHealth.Dead;
            if (player.number == check.mario)
            {
                player.currentSprite = player.mySpriteFactory.returnMarioSprite(check.MarioDead);
            }
            else if (player.number == check.luigi)
            {
                player.currentSprite = player.mySpriteFactory.returnLuigiSprite(check.LuigiDead);
            }
            player.velocity = Vector2.Zero;
        }

    }
}

