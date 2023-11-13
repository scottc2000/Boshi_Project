using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Utility;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.PlayerStates
{
    internal class PlayerIdleState : ICharacterState
    {
        private Player player;
        private PlayerNumbers p;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames FileNames = new FileNames();
        public PlayerIdleState(Player player)
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
            if (player.timeGap == 0)
            {
                player.State = new PlayerJumpState(player);
                audioManager.PlaySFX(FileNames.jumpSFX);
            }

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
        public void Throw()
        {
            player.State = new PlayerThrowState(player);
        }

        public void Stop()
        {
            player.timeGap = 0;
            player.State = new PlayerIdleState(player);
        }

        public void UpdateVelocity()
        {
            player.velocity.X *= 0;
            player.velocity.Y *= 0;
        }

        public void Die()
        {
            player.State = new DeadPlayerState(player);
        }
        public void Update(GameTime gametime)
        {
            player.pose = Player.PlayerPose.Idle;

            UpdateVelocity();

            player.currentSprite = SetSprite(gametime);
        }

        public AnimatedSpritePlayer SetSprite(GameTime gametime)
        {
            if (player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioIdleLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnSprite(p.MarioIdleLeft);
            }
            else if (!player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioIdleRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnSprite(p.MarioIdleRight);
            }

            if (player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiIdleLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnSprite(p.LuigiIdleLeft);
            }
            else if (!player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiIdleRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnSprite(p.LuigiIdleRight);
            }

            return player.currentSprite;
        }
    }
}