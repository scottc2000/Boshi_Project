using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface ICharacterState
    {
        public void MoveRight();

        public void MoveLeft();

        public void JumpLeft();

        public void JumpRight();

        public void CrouchLeft();

        public void CrouchRight();

        public void StopLeft();

        public void StopRight();

        public void Update();
    }
}
