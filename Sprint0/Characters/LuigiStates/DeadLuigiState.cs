using System;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters.LuigiStates
{
	public class DeadLuigiState : ICharacterState
	{
        Luigi luigi;
		public DeadLuigiState(Luigi luigi)
		{
            this.luigi = luigi;
		}

        public void Crouch()
        {
            throw new NotImplementedException();
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public void Fall()
        {
            throw new NotImplementedException();
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Jump()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Throw()
        {
            throw new NotImplementedException();
        }
        public void Update(GameTime gametime)
        {
            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("LuigiDead");
            luigi.position = new Vector2(luigi.position.X, luigi.position.Y - 1);
        }
    }
}

