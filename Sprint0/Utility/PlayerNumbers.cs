using Microsoft.Xna.Framework;

namespace Sprint0.Utility
{
    public class PlayerNumbers
    {
        public Vector2 velocity { get; } = new Vector2(0, 0);
        public int mario { get; } = 1;
        public int luigi { get; } = 2;
        public int sizeDiff { get; } = 25;
        public int reverse { get; } = -1;
        public Vector2 marioPosition { get; } = new Vector2(180, 200);
        public Vector2 luigigPosition { get; } = new Vector2(200, 200);
        public float sixth { get; } = (1.0f / 60.0f);
        public int runningMax { get; } = 75;
        public int flyingMax { get; } = 4000;
        public int timeGapMax { get; } = 500;
        public int gap50 { get; } = 50;

        /*_____________ Sprite Strings _______________*/
        public string PlayerFire { get; } = "PlayerFireRight";
        public string MarioDead { get; } = "MarioDead";
        public string LuigiDead { get; } = "LuigiDead";
        public string LuigiIdleRight { get; } = "LuigiStillRight";
        public string LuigiIdleLeft { get; } = "LuigiStillLeft";
        public string MarioIdleRight { get; } = "MarioStillRight";
        public string MarioIdleLeft { get; } = "MarioStillLeft";
        public string LuigiCrouchLeft { get; } = "LuigiCrouchLeft";
        public string LuigiCrouchRight { get; } = "LuigiCrouchRight";
        public string MarioCrouchLeft { get; } = "MarioCrouchLeft";
        public string MarioCrouchRight { get; } = "MarioCrouchRight";
        public string LuigiFlyLeft { get; } = "LuigiFlyLeft";
        public string LuigiFlyRight { get; } = "LuigiFlyRight";
        public string MarioFlyLeft { get; } = "MarioFlyLeft";
        public string MarioFlyRight { get; } = "MarioFlyRight";
        public string LuigiJumpLeft { get; } = "LuigiJumpLeft";
        public string LuigiJumpRight { get; } = "LuigiJumpRight";
        public string MarioJumpLeft { get; } = "MarioJumpLeft";
        public string MarioJumpRight { get; } = "MarioJumpRight";
        public string LuigiMoveLeft { get; } = "LuigiMoveLeft";
        public string LuigiMoveRight { get; } = "LuigiMoveRight";
        public string MarioMoveLeft { get; } = "MarioMoveLeft";
        public string MarioMoveRight { get; } = "MarioMoveRight";
        public string LuigiBoostLeft { get; } = "LuigiBoostLeft";
        public string LuigiBoostRight { get; } = "LuigiBoostRight";
        public string MarioBoostLeft { get; } = "MarioBoostLeft";
        public string MarioBoostRight { get; } = "MarioBoostRight";
        public string LuigiThrowLeft { get; } = "LuigiThrowLeft";
        public string LuigiThrowRight { get; } = "LuigiThrowRight";
        public string MarioThrowLeft { get; } = "MarioThrowLeft";
        public string MarioThrowRight { get; } = "MarioThrowRight";

    }
}
