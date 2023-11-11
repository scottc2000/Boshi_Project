using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
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
        public int itemPoints { get; } = 1000;
        public int gameTimer { get; } = 500;
        public Vector2 staticStartingPosition { get; } = new Vector2(50, 450);
        public Vector2 coinStartingPosition { get; } = new Vector2(330, 464);
        public Vector2 livesStartingPosition { get; } = new Vector2(115, 480);
        public Vector2 scoreStartingPosition { get; } = new Vector2(250, 480);
        public Vector2 timerStartingPosition { get; } = new Vector2(330, 480);
        public Vector2 letterStartingPosition { get; } = new Vector2(55, 480);
        public Vector2 cardsStartingPosition { get; } = new Vector2(375, 450);
        public Vector2 worldStartingPosition { get; } = new Vector2(125, 464);

        public int staticPositionOffsetX { get; } = 35;
        public int coinPositionOffsetX { get; } = 280;
        public int livesPositionOffsetX { get; } = 65;
        public int scorePositionOffsetX { get; } = 200;
        public int timerPositionOffsetX { get; } = 280;
        public int letterPositionOffsetX { get; } = 5;
        public int cardsPositionOffsetX { get; } = 325;
        public int worldPositionOffsetX { get; } = 75;

        // need to fix later
        public int staticPositionOffsetY { get; } = 240;
        public int coinPositionOffsetY { get; } = 0;
        public int livesPositionOffsetY { get; } = 0;
        public int scorePositionOffsetY { get; } = 0;
        public int timerPositionOffsetY { get; } = 30;
        public int letterPositionOffsetY { get; } = 0;
        public int cardsPositionOffsetY { get; } = 0;
        public int worldPositionOffsetY { get; } = 10;

        // Sprite details
        public string staticHUD { get; } = "static";
        public string letter { get; } = "letter";
        public string card { get; } = "cards";
        public string lightTriangle { get; } = "lightTriangle";
        public string darkTriangle { get; } = "darkTriangle";
        public string lightPower { get; } = "lightPower";
        public string darkPower { get; } = "darkPower";
    }
}