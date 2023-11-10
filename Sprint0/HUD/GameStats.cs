using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using Sprint0.Utility;

namespace Sprint0.HUD
{
    public class GameStats : IGameObject
    {
        private Sprint0 sprint;
        private HudNumbers numbers;
        private AudioManager audioManager = AudioManager.Instance;
        private FileNames fileNames = new FileNames();
       
        // Stat variables
        private int coins { get; set; }
        private int lives { get; set; }
        private int score { get; set; }
        private int player { get; set; }
        private int gameTimer { get; set; }
        private int powerBoost { get; set; }

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
            numbers = new HudNumbers();

            // Initial stats
            coins = 0;
            lives = numbers.STARTINGLIVES;
            score = 0;
            gameTimer = numbers.gameTimer;

            // Initialize Factory
            mySpriteFactory = new HUDFactory(sprint);
            mySpriteFactory.LoadAllTextures(sprint.Content);

            // Create initial game stats
            staticSprite = mySpriteFactory.CreateHud(numbers.staticHUD);
            coinSprite = mySpriteFactory.UpdateDigits(coins);
            lifeSprite = mySpriteFactory.UpdateDigits(lives);
            scoreSprite = mySpriteFactory.UpdateDigits(score);
            timerSprite = mySpriteFactory.UpdateDigits(gameTimer);
            //powerSprite = mySpriteFactory.UpdatePower(score);

        }

        public void IncrementCoin()
        {
            coins++;
            if (coins == numbers.MAXCOINS)
            {
                IncrementLives();
                coins = 0;
            }
            mySpriteFactory = new HUDFactory(sprint);
            coinSprite = mySpriteFactory.UpdateDigits(coins);
            audioManager.PlaySFX(fileNames.coinSFX);
        }

        public void IncreaseScore(int points)
        {
            score += points;

            mySpriteFactory = new HUDFactory(sprint);
            scoreSprite = mySpriteFactory.UpdateDigits(points);
        }

        public void IncrementLives()
        {
            lives++;
            if (lives < 99)
            {
                mySpriteFactory = new HUDFactory(sprint);
                lifeSprite = mySpriteFactory.UpdateDigits(lives);
            }
        }

        public void DecrementLives()
        {
            lives--;
            if (lives == 0)
            {
                // Is game over screen called here or handled somewhere else?
                lives = numbers.STARTINGLIVES;
            }
            else
            {
                mySpriteFactory = new HUDFactory(sprint);
                lifeSprite = mySpriteFactory.UpdateDigits(lives);
            }
        }
        public void PowerLevel()
        {
            // For mario and luigi's raccoon power boost
        }

        public void Update(GameTime gametime)
        {
            gameTimer--;
            mySpriteFactory = new HUDFactory(sprint);
            //timerSprite = mySpriteFactory.UpdateDigits(gameTimer);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            staticSprite.Draw(spritebatch, numbers.staticStartingPosition);
            coinSprite.Draw(spritebatch, numbers.coinStartingPosition);
            lifeSprite.Draw(spritebatch, numbers.livesStartingPosition);
            scoreSprite.Draw(spritebatch, numbers.scoreStartingPosition);
            timerSprite.Draw(spritebatch, numbers.timerStartingPosition);
        }
    }
}
