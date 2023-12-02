using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Camera;
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
        private int gameTimer { get; set; }
        private int delay { get; set; }

        // Sprite information
        private HUDFactory mySpriteFactory;
        private ISprite staticSprite;
        private ISprite letter;
        private ISprite world;
        private ISprite coinSprite;
        private ISprite lifeSprite;
        private ISprite scoreSprite;
        private ISprite timerSprite;
        private ISprite cardSprite;
        private ISprite powerSprite;

        private Vector2 staticPosition;
        private Vector2 letterPosition;
        private Vector2 powerPosition;
        private Vector2 worldPosition;
        private Vector2 coinPosition;
        private Vector2 livesPosition;
        private Vector2 scorePosition;
        private Vector2 cardPosition;
        private Vector2 timerPosition;

        private PlayerCamera camera;

        public GameStats(Sprint0 sprint)
        {
            this.sprint = sprint;
            numbers = new HudNumbers();

            // Initial stats
            coins = 0;
            lives = numbers.STARTINGLIVES;
            score = 0;
            gameTimer = numbers.gameTimer;
            delay = numbers.delay;

            // Initialize Factory
            mySpriteFactory = new HUDFactory(sprint);
            mySpriteFactory.LoadAllTextures(sprint.Content);

            // Create initial game stats
            staticSprite = mySpriteFactory.CreateHud(numbers.staticHUD);
            letter = mySpriteFactory.Letter(numbers.letter);
            world = mySpriteFactory.World();
            coinSprite = mySpriteFactory.UpdateDigits(coins);
            lifeSprite = mySpriteFactory.UpdateDigits(lives);
            scoreSprite = mySpriteFactory.UpdateDigits(score);
            timerSprite = mySpriteFactory.UpdateDigits(gameTimer);
            cardSprite = mySpriteFactory.Cards(numbers.card);
            powerSprite = mySpriteFactory.UpdatePower(numbers.level0);

            // Initialize starting location for HUD
            staticPosition = numbers.staticStartingPosition;
            letterPosition = numbers.letterStartingPosition;
            worldPosition = numbers.worldStartingPosition;
            coinPosition = numbers.coinStartingPosition;
            livesPosition = numbers.livesStartingPosition;
            scorePosition = numbers.scoreStartingPosition;
            timerPosition = numbers.timerStartingPosition;
            cardPosition = numbers.cardStartingPosition;
            powerPosition = numbers.powerStartingPosition;
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
            mySpriteFactory.LoadAllTextures(sprint.Content);
            coinSprite = mySpriteFactory.UpdateDigits(coins);
            audioManager.PlaySFX(fileNames.coinSFX);
        }

        public void IncreaseScore(int points)
        {
            score += points;

            mySpriteFactory = new HUDFactory(sprint);
            mySpriteFactory.LoadAllTextures(sprint.Content);
            scoreSprite = mySpriteFactory.UpdateDigits(score);
        }

        public void IncrementLives()
        {
            lives++;
            if (lives == 0)
            {
                // game over
            }
            mySpriteFactory = new HUDFactory(sprint);
            mySpriteFactory.LoadAllTextures(sprint.Content);
            lifeSprite = mySpriteFactory.UpdateDigits(lives);
            audioManager.PlaySFX(fileNames.oneUpSFX);
        }

        public void DecrementLives()
        {
            lives--;
            if (lives == 0)
            {
                mySpriteFactory = new HUDFactory(sprint);
                mySpriteFactory.LoadAllTextures(sprint.Content);
                lifeSprite = mySpriteFactory.UpdateDigits(lives);
                sprint.gamestates = GameStates.GAMEOVER;
            }
            else
            {
                mySpriteFactory = new HUDFactory(sprint);
                mySpriteFactory.LoadAllTextures(sprint.Content);
                lifeSprite = mySpriteFactory.UpdateDigits(lives);
            }
        }
        public void PowerLevel(string value)
        {
            mySpriteFactory = new HUDFactory(sprint);
            mySpriteFactory.LoadAllTextures(sprint.Content);
            powerSprite = mySpriteFactory.UpdatePower(value);
        }

        public void Timer()
        {
            gameTimer--;
            mySpriteFactory = new HUDFactory(sprint);
            mySpriteFactory.LoadAllTextures(sprint.Content);
            timerSprite = mySpriteFactory.UpdateDigits(gameTimer);
        }

        public void Update(GameTime gametime)
        {
            delay--;
            if (delay <= 0)
            {
                delay = numbers.delay;
                Timer();
                
            }
            if (gameTimer <= 0)
            {
                //gameover
            }

        }
        public void Draw(SpriteBatch spritebatch)
        {
            staticSprite.Draw(spritebatch, staticPosition);
            letter.Draw(spritebatch, letterPosition);
            world.Draw(spritebatch, worldPosition);
            coinSprite.Draw(spritebatch, coinPosition);
            lifeSprite.Draw(spritebatch, livesPosition);
            scoreSprite.Draw(spritebatch, scorePosition);
            timerSprite.Draw(spritebatch, timerPosition);
            cardSprite.Draw(spritebatch, cardPosition);
            powerSprite.Draw(spritebatch, powerPosition);
        }
    }
}
