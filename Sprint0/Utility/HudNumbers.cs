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
        public int enemyPoints { get; } = 100;
        public int coinPoints { get; } = 100;
        public int itemPoints { get; } = 1000;
        public int gameTimer { get; } = 500;
        public int delay { get; } = 75;

        public Vector2 staticStartingPosition { get; } = new Vector2(50, 390);
        public Vector2 coinStartingPosition { get; } = new Vector2(460, 410);
        public Vector2 livesStartingPosition { get; } = new Vector2(150, 435);
        public Vector2 scoreStartingPosition { get; } = new Vector2(370, 435);
        public Vector2 timerStartingPosition { get; } = new Vector2(470, 435);
        public Vector2 letterStartingPosition { get; } = new Vector2(60, 435);
        public Vector2 cardStartingPosition { get; } = new Vector2(520, 390);
        public Vector2 worldStartingPosition { get; } = new Vector2(165, 410);
        public Vector2 powerStartingPosition { get; } = new Vector2(205, 410);

        // Sprite details
        public string staticHUD { get; } = "static";
        public string letter { get; } = "letter";
        public string card { get; } = "cards";
        public string level0 { get; } = "level0";
        public string level1 { get; } = "level1";
        public string level2 { get; } = "level2";
        public string level3 { get; } = "level3";
        public string level4 { get; } = "level4";
    }
}