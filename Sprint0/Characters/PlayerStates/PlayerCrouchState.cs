using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Utility;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.PlayerStates
{
    internal class PlayerCrouchState : ICharacterState
    {
        private Player player;
        private PlayerNumbers p;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames FileNames = new FileNames();

        public PlayerCrouchState(Player player)
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
        }

        public void Stop()
        {
            player.timeGap = 0;
            player.State = new PlayerIdleState(player);
        }

        public void Throw()
        {
            player.State = new PlayerThrowState(player);
        }
        public void Die()
        {
            player.State = new DeadPlayerState(player);
        }

        public void UpdateVelocity()
        {
            player.velocity.X *= player.decay;
        }

        public void Update(GameTime gametime)
        {
            player.pose = Player.PlayerPose.Crouch;

            UpdateVelocity();

            player.currentSprite = SetSprite(gametime);

        }
        public AnimatedSpritePlayer SetSprite(GameTime gametime)
        {
            if (player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioCrouchLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnSprite(p.MarioCrouchLeft);
            }
            else if (!player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioCrouchRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnSprite(p.MarioCrouchRight);
            }

            if (player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiCrouchLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnSprite(p.LuigiCrouchLeft);
            }
            else if (!player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiCrouchRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnSprite(p.LuigiCrouchRight);
            }

            return player.currentSprite;
        }
    }
}
