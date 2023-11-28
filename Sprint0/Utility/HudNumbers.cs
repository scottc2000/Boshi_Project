using Microsoft.Xna.Framework;

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
        public int delay { get; } = 75;

        public int staticPositionOffsetX { get; } = 10;
        public int coinPositionOffsetX { get; } = 280;
        public int livesPositionOffsetX { get; } = 65;
        public int scorePositionOffsetX { get; } = 200;
        public int timerPositionOffsetX { get; } = 280;
        public int letterPositionOffsetX { get; } = 5;
        public int cardsPositionOffsetX { get; } = 325;
        public int worldPositionOffsetX { get; } = 75;

        // need to fix later
        public int staticPositionOffsetY { get; } = 190;
        public int coinPositionOffsetY { get; } = 15;
        public int livesPositionOffsetY { get; } = 30;
        public int scorePositionOffsetY { get; } = 30;
        public int timerPositionOffsetY { get; } = 30;
        public int letterPositionOffsetY { get; } = 30;
        public int cardsPositionOffsetY { get; } = 190;
        public int worldPositionOffsetY { get; } = 15;

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