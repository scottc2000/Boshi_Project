using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using Sprint0.Utility;

namespace Sprint0.Characters.PlayerStates
{
    public class PlayerMoveState : ICharacterState
    {
        private Player player;
        private PlayerNumbers p;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames FileNames = new FileNames();

        public PlayerMoveState(Player player)
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
            player.State = new PlayerThrowState(player);
        }
        public void Die()
        {
            player.State = new DeadPlayerState(player);
        }

        public void UpdateVelocity()
        {
            if (player.runningTimer < p.runningMax)
            {
                player.velocity.X = 2.0f;
                player.boosted = false;
            }
            else if (player.runningTimer > p.runningMax)
            {
                player.velocity.X = 3.0f;
                player.boosted = true;
            }
            player.velocity.Y *= 0;
        }


        public void Update(GameTime gametime)
        {
            player.pose = Player.PlayerPose.Walking;

            if (player.boosted)
                player.currentSprite = BoostedSetSprite(gametime);
            else
                player.currentSprite = NormalSetSprite(gametime);

            UpdateVelocity();
        }
        public AnimatedSpritePlayer BoostedSetSprite(GameTime gametime)
        {
            // if player is mario
            if (player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioBoostLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnMarioSprite(p.MarioBoostLeft);
            }
            else if (!player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioBoostRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnMarioSprite(p.MarioBoostRight);
            }

            // if player is luigi
            if (player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiBoostLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnMarioSprite(p.LuigiBoostLeft);
            }
            else if (!player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiBoostRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnMarioSprite(p.LuigiBoostRight);
            }

            return player.currentSprite;
        }
        public AnimatedSpritePlayer NormalSetSprite(GameTime gametime) 
        {
            // if player is mario
            if (player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioMoveLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnMarioSprite(p.MarioMoveLeft);
            }
            else if (!player.facingLeft && player.number == p.mario)
            {
                if (player.currentSprite.spriteName.Equals(p.MarioMoveRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnMarioSprite(p.MarioMoveRight);
            }

            // if player is luigi
            if (player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiMoveLeft))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnLuigiSprite(p.LuigiMoveLeft);
            }
            else if (!player.facingLeft && player.number == p.luigi)
            {
                if (player.currentSprite.spriteName.Equals(p.LuigiJumpRight))
                    player.currentSprite.Update(gametime);
                else
                    player.currentSprite = player.mySpriteFactory.returnLuigiSprite(p.LuigiMoveRight);
            }

            return player.currentSprite;
        }
    }
}