using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;

namespace Sprint0.Characters.LuigiStates
{
    public class LuigiFlyState : ICharacterState
    {
        private Luigi luigi;
        private float yVelocity = -4f;

        public LuigiFlyState(Luigi mario)
        {
            this.luigi = mario;
        }
        public void Crouch()
        {
            luigi.State = new LuigiCrouchState(luigi);
        }

        public void Die()
        {
            luigi.State = new DeadLuigiState(luigi);
        }

        public void Fall()
        {
            yVelocity = 0f;
        }

        public void Fly()
        {
            luigi.State = new LuigiFlyState(luigi);
        }

        public void Jump()
        {
            luigi.State = new LuigiJumpState(luigi);
        }

        public void Move()
        {
            luigi.velocityX= 2;
        }

        public void Stop()
        {

        }

        public void Throw()
        {
            luigi.State = new LuigiThrowState(luigi);
        }

        public void UpdateVelocity(GameTime gametime)
        {
            if (luigi.flyingTimer < 4000)
            {
                luigi.velocityY = yVelocity;
            }
            else
            {
                luigi.velocityY = 0;
            }

            luigi.flyingTimer += gametime.ElapsedGameTime.Milliseconds;

            if (luigi.flyingTimer > 4000)
            {
                luigi.boosted = false;
                luigi.flyingTimer = 0;
                luigi.State = new LuigiIdleState(luigi);
            }
        }

        public void Update(GameTime gametime)
        {
            luigi.pose = Luigi.LuigiPose.Jump;

            UpdateVelocity(gametime);

            SetSprites(gametime);

            if (luigi.uphit && luigi.flyingTimer > 4000)
            {
                luigi.Stop();
            }

        }

        public void SetSprites(GameTime gametime)
        {
            if (luigi.facingLeft)
            {
                if (luigi.currentSprite.spriteName.Equals("LuigiFlyLeft"))
                {
                    luigi.currentSprite.Update(gametime);
                }
                else
                {
                    luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiFlyLeft");
                }
            }
            else
            {
                if (luigi.currentSprite.spriteName.Equals("LuigiFlyRight"))
                {
                    luigi.currentSprite.Update(gametime);
                }
                else
                {
                    luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiFlyRight");
                }

            }
        }
    }
}

