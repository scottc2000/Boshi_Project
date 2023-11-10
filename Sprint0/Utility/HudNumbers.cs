﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Utility
{
    public class HudNumbers
    {
        // Constants
        public int MAXCOINS { get; } = 100;
        public int MAXLIVES { get; } = 99;
        public int STARTINGLIVES { get; } = 3;
        public int brickPoints { get; } = 50;
        public int enemyPonts { get; } = 100;
        public int coinPoints { get; } = 200;
        public int oneUpPoints { get; } = 1000;
        public int gameTimer { get; } = 500;
        public Vector2 staticStartingPosition { get; } = new Vector2(50, 450);
        public Vector2 coinStartingPosition { get; } = new Vector2(330, 464);
        public Vector2 livesStartingPosition { get; } = new Vector2(115, 480);
        public Vector2 scoreStartingPosition { get; } = new Vector2(250, 480);
        public Vector2 timerStartingPosition { get; } = new Vector2(330, 480);

        // Sprite details
        public string staticHUD { get; } = "static";
        public int digitOffset { get; } = 16;
    }
}