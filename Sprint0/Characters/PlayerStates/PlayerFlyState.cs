using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Utility;

namespace Sprint0.Characters.PlayerStates
{
    public class PlayerFlyState : ICharacterState
    {
        private Player player;
        private PlayerNumbers p;
        private float yVelocity = -4f;

        public PlayerFlyState(Player player)
        {
            this.player = player;
            p = new PlayerNumbers();
        }
        public void Crouch()
        {
            player.State = new PlayerCrouchState(player);
        }
        public void Die()
        {
            player.State = new DeadPlayerState(player);
        }

        public void Fall()
        {
            yVelocity = 0f;
        }

        public void Fly()
        {
            player.State = new PlayerFlyState(player);
        }

        public void Jump()
        {
            player.State = new PlayerJumpState(player);
        }

        public void Move()
        {
            player.velocity.X= 2;
        }

        public void Stop()
        {

        }
        public void Throw()
        {
            player.State = new PlayerThrowState(player);
        }

        public void UpdateVelocity(GameTime gametime)
        {
            if (player.flyingTimer < p.flyingMax)
                player.velocity.Y = yVelocity;
            else
                player.velocity.Y = 0;

            player.flyingTimer += gametime.ElapsedGameTime.Milliseconds;

            if (player.flyingTimer > p.flyingMax)
            {
                player.boosted = false;
                player.flyingTimer = 0;
                player.State = new PlayerIdleState(player);
            }
        }

        public void Update(GameTime gametime)
        {
            player.pose = Player.PlayerPose.Jump;

            UpdateVelocity(gametime);

            player.currentSprite = SetSprites(gametime);

            if (player.flyingTimer > p.flyingMax)
                player.Stop();
        }

        public AnimatedSpritePlayer SetSprites(GameTime gametime)
        {
            // if player is mario
            if (player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioFlyLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnMarioSprite(p.MarioFlyLeft);
            }
            else if (!player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioFlyRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnMarioSprite(p.MarioFlyRight);
            }

            // if player is luigi
            if (player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiFlyLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnLuigiSprite(p.LuigiFlyLeft);
            }
            else if (!player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiFlyRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnLuigiSprite(p.LuigiFlyRight);
            }

            return player.currentSprite;
        }
    }
}

