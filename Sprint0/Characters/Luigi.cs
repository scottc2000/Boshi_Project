using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters
{
    public class Luigi : ICharacter
    {
        private LuigiStateMachine stateMachine;
        public Vector2 pos;
        public ISprite currentSprite;

        public Luigi()
        {
            stateMachine = new LuigiStateMachine();
            pos = new Vector2(400, 240);
            currentSprite = new LuigiStill(this);
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void CrouchingLeft()
        {
            throw new NotImplementedException();
        }

        public void BeFlipped()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}