﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public interface IController
    {
        void Update();

        void RegisterCommand(Keys key, ICommand command);

        void RegisterMouseCommand(String mouseState, ICommand command);
    }
}
