﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface IEnemyState
    {
        void ChangeDirection();
        void BeStomped();
        void BeFlipped();
        void startSwarm();
        void Update();
    }
}
