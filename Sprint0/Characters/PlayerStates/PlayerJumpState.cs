using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Utility;

namespace Sprint0.Characters.PlayerStates
{
    public class PlayerJumpState : ICharacterState
    {
        private Player player;
        private PlayerNumbers p;
        private float yVelocity = -3.0f;

        public PlayerJumpState(Player player)
        {
            this.player = player;
            p = new PlayerNumbers();
        }

        public void Move()
        {
            player.velocity.X = 2;
        }

        public void Jump()
        {
            player.State = new PlayerJumpState(player);
        }
        public void Fly() 
        {
            player.State = new PlayerFlyState(player);
        }
        public void Fall()
        {
            yVelocity = 0f;
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
            player.State = new PlayerIdleState(player);
        }

        public void Die()
        {
            player.State = new DeadPlayerState(player);
        }

        public void UpdateVelocity(GameTime gametime)
        {
            if (player.timeGap < p.timeGapMax )
                player.velocity.Y = yVelocity;
            else
                player.velocity.Y = 0;
            
            player.timeGap += gametime.ElapsedGameTime.Milliseconds;
        }

        public void Update(GameTime gametime)
        {
            player.pose = Player.PlayerPose.Jump;

            UpdateVelocity(gametime);

            player.currentSprite = SetSprite(gametime);

            if (player.timeGap > p.gap50)
            {
                player.Stop();
            }
        }
        public AnimatedSpritePlayer SetSprite(GameTime gametime)
        {
            // if player is mario
            if (player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioJumpLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnMarioSprite(p.MarioJumpLeft);
            }
            else if (!player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioJumpRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnMarioSprite(p.MarioJumpRight);
            }

            // if player is luigi
            if (player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiJumpLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnLuigiSprite(p.LuigiJumpLeft);
            }
            else if (!player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiJumpRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnLuigiSprite(p.LuigiJumpRight);
            }

            return player.currentSprite;
        }
    }
    
}