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
       
        // Stat variables
        private int coins { get; set; }
        private int lives { get; set; }
        private int score { get; set; }
        private int player { get; set; }
        private int gameTimer { get; set; }
        private int powerBoost { get; set; }

        // Sprite information
        private HUDFactory mySpriteFactory;
        private ISprite staticSprite = null;
        private ISprite coinSprite = null;
        private ISprite lifeSprite = null;
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
            IncrementCoin();

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
            if (coins == numbers.MAXCOINS)
            {
                IncrementLives();
                coins = 0;
            }
            mySpriteFactory = new HUDFactory(sprint);
            coinSprite = mySpriteFactory.UpdateCoins(coins);
        }

        public void IncreaseScore(int points)
        {
            score += points;
        }

        public void IncrementLives()
        {
            lives++;
            mySpriteFactory = new HUDFactory(sprint);
            lifeSprite = mySpriteFactory.UpdateLives(lives);
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
