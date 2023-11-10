using Microsoft.Xna.Framework;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Utility;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.LuigiStates
{
    internal class LuigiThrowState : ICharacterState
    {
        private Luigi luigi;
        private FileNames FileNames = new FileNames();

        public LuigiThrowState(Luigi luigi)
        {
            this.luigi = luigi;
        }

        public void Move()
        {
            luigi.State = new LuigiMoveState(luigi);
        }

        public void Jump()
        {
            luigi.State = new LuigiJumpState(luigi);
            AudioManager audioManager = AudioManager.Instance;
            audioManager.PlaySFX(FileNames.jumpSFX);
        }
        public void Fly() { }
        public void Fall()
        {

        }
        public void Crouch()
        {
            luigi.State = new LuigiCrouchState(luigi);
        }

        public void Stop()
        {
            luigi.State = new LuigiIdleState(luigi);
        }

        public void Throw()
        {

        }

        public void TakeDamage() { }
        public void Die()
        {
            // mario.marioSprite = CharacterSpriteFactory.Instance.CreateDeadMarioSprite();
        }
        public void Update(GameTime gametime)
        {
            luigi.pose = Luigi.LuigiPose.Throwing;

            if (luigi.health == Luigi.LuigiHealth.Fire)
            {
                if (luigi.facingLeft)
                {
                    if (luigi.currentSprite.spriteName.Equals("LuigiThrowLeft"))
                    {

                        luigi.currentSprite.Update(gametime);
                    }
                    else
                    {
                        luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiThrowLeft");
                    }
                }
                else
                {
                    if (luigi.currentSprite.spriteName.Equals("LuigiThrowRight"))
                    {

                        luigi.currentSprite.Update(gametime);
                    }
                    else
                    {
                        luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiThrowRight");
                    }
                }
            }
            
        }
    }
}