using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.HUD
{
    public class GameStats
    {
        public static readonly int MAXCOINS = 100;
        public static readonly int MINCOINS = 0;
        public static readonly int STARTINGLIVES = 3;
        public static readonly int GAMEOVER = 0;

        private Sprint0 sprint;
        public int coins { get; set; }
        public int lives { get; set; }
        public int score { get; set; }
        public int player { get; set; }
        public int gameTimer { get; set; }
        public int powerBoost { get; set; }
        public HUDFactory mySpriteFactory;

        public GameStats(Sprint0 sprint)
        {
            this.sprint = sprint;
            coins = MINCOINS;
            lives = STARTINGLIVES;
            score = 0;
            gameTimer = 500;
            mySpriteFactory = new HUDFactory(sprint);
            mySpriteFactory.LoadAllTextures(sprint.Content);
        }

        public void IncrementCoin()
        {
            coins++;
            if (coins == MAXCOINS)
            {
                IncrementLives();
                coins = MINCOINS;
            }
        }

        public void IncreaseScore(int points)
        {
            score += points;
        }

        public void IncrementLives()
        {
            lives++;
        }

        public void DecrementLives()
        {
            lives--;
            if (lives == GAMEOVER)
            {
                // Is game over screen called here or handled somewhere else?
                lives = STARTINGLIVES;
            }
        }

        public void Update(GameTime gametime)
        {
            gameTimer--;
        }
        public void Draw(SpriteBatch spritebatch)
        {

        }
    }
}
