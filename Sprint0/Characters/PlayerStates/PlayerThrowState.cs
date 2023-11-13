using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Utility;

namespace Sprint0.Characters.PlayerStates
{
    internal class PlayerThrowState : ICharacterState
    {
        private Player player;
        private PlayerNumbers p;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames FileNames = new FileNames();

        public PlayerThrowState(Player player)
        {
            this.player = player;
            p = new PlayerNumbers();
        }

        public void Move()
        {
            player.State = new PlayerMoveState(player);
        }

        public void Jump()
        {
            player.State = new PlayerJumpState(player);
            audioManager.PlaySFX(FileNames.jumpSFX);
        }
        public void Fly() 
        {
            player.State = new PlayerFlyState(player);
        }
        public void Fall()
        {
        }
        public void Crouch()
        {
            player.State = new PlayerCrouchState(player);
        }

        public void Stop()
        {
            player.State = new PlayerIdleState(player);
        }

        public void Throw()
        {
        }
        public void Die()
        {
            player.State = new DeadPlayerState(player);
        }
        public void Update(GameTime gametime)
        {
            player.pose = Player.PlayerPose.Throwing;

            player.currentSprite = SetSprite(gametime);
        }
        public AnimatedSpritePlayer SetSprite(GameTime gametime)
        {
            // if player is mario
            if (player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioThrowLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnMarioSprite(p.MarioThrowLeft);
            }
            else if (!player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioThrowRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnMarioSprite(p.MarioThrowRight);
            }

            // if player is luigi
            if (player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiThrowLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnLuigiSprite(p.LuigiThrowLeft);
            }
            else if (!player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiThrowRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnLuigiSprite(p.LuigiThrowRight);
            }

            return player.currentSprite;
        }
    }
}