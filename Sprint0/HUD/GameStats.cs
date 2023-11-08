using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.HUD
{
    public class GameStats
    {
        private Sprint0 sprint;
        // Constants
        private static readonly int MAXCOINS = 100;
        private static readonly int ZERO = 0;
        private static readonly int STARTINGLIVES = 3;

        // Stat variables
        public int coins { get; set; }
        public int lives { get; set; }
        public int score { get; set; }
        public int player { get; set; }
        public int gameTimer { get; set; }
        public int powerBoost { get; set; }

        // Sprite information
        private HUDFactory mySpriteFactory;
        private ISprite staticSprite;
        private ISprite coinSprite;
        private ISprite lifeSprite;
        private ISprite scoreSprite;
        private ISprite timerSprite;
        private ISprite powerSprite;

        public GameStats(Sprint0 sprint)
        {
            this.sprint = sprint;

            // Initial stats
            coins = ZERO;
            lives = STARTINGLIVES;
            score = 0;
            gameTimer = 500;

            // Initialize Factory
            mySpriteFactory = new HUDFactory(sprint);
            mySpriteFactory.LoadAllTextures(sprint.Content);

            // Create initial game stats
            staticSprite = mySpriteFactory.CreateHud("static");
            coinSprite = mySpriteFactory.UpdateCoins(coins);
            lifeSprite = mySpriteFactory.UpdateLives(lives);
            //scoreSprite = mySpriteFactory.UpdateScore(score);
            //timerSprite = mySpriteFactory.UpdateTimer(score);
            //powerSprite = mySpriteFactory.UpdatePower(score);

        }

        public void IncrementCoin()
        {
            coins++;
            if (coins == MAXCOINS)
            {
                IncrementLives();
                coins = ZERO;
            }

            coinSprite = mySpriteFactory.UpdateCoins(coins);
        }

        public void IncreaseScore(int points)
        {
            score += points;
        }

        public void IncrementLives()
        {
            lives++;
            lifeSprite = mySpriteFactory.UpdateLives(lives);
        }

        public void DecrementLives()
        {
            lives--;
            if (lives == ZERO)
            {
                // Is game over screen called here or handled somewhere else?
                lives = STARTINGLIVES;
            }
            else
            {
                lifeSprite = mySpriteFactory.UpdateLives(lives);
            }
        }
        public void PowerLevel()
        {
            // For mario and luigi's raccoon power boost
        }

        public void Update(GameTime gametime)
        {
            gameTimer--;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            // Magic numbers will be removed later
            staticSprite.Draw(spritebatch, new Vector2(50, 450));
            coinSprite.Draw(spritebatch, new Vector2(330, 464));
            lifeSprite.Draw(spritebatch, new Vector2(115, 480));
        }
    }
}
