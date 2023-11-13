using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
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
        private int powerBoost { get; set; }

        // Sprite information
        private HUDFactory mySpriteFactory;
        private ISprite staticSprite;
        private ISprite letter;
        private ISprite world;
        private ISprite cards;
        private ISprite coinSprite;
        private ISprite lifeSprite;
        private ISprite scoreSprite;
        private ISprite timerSprite;
        private ISprite powerSprite;

        private Vector2 staticPosition;
        private Vector2 letterPosition;
        private Vector2 cardsPosition;
        private Vector2 worldPosition;
        private Vector2 coinPosition;
        private Vector2 livesPosition;
        private Vector2 scorePosition;
        private Vector2 timerPosition;

        private Camera.PlayerCamera camera;

        public GameStats(Sprint0 sprint, Camera.PlayerCamera camera)
        {
            this.sprint = sprint;
            this.camera = camera;
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
            letter = mySpriteFactory.Letter(numbers.letter);
            world = mySpriteFactory.World();
            cards = mySpriteFactory.Cards(numbers.card);
            coinSprite = mySpriteFactory.UpdateDigits(coins);
            lifeSprite = mySpriteFactory.UpdateDigits(lives);
            scoreSprite = mySpriteFactory.UpdateDigits(score);
            timerSprite = mySpriteFactory.UpdateDigits(gameTimer);
            //powerSprite = mySpriteFactory.UpdatePower(score);

            // Initialize starting location for HUD
            staticPosition = numbers.staticStartingPosition;
            letterPosition = numbers.letterStartingPosition;
            cardsPosition = numbers.cardsStartingPosition;
            worldPosition = numbers.worldStartingPosition;
            coinPosition = numbers.coinStartingPosition;
            livesPosition = numbers.livesStartingPosition;
            scorePosition = numbers.scoreStartingPosition;
            timerPosition = numbers.timerStartingPosition;
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
            scoreSprite = mySpriteFactory.UpdateDigits(points);
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
                // Is game over screen called here or handled somewhere else?
                lives = numbers.STARTINGLIVES;
            }
            else
            {
                mySpriteFactory = new HUDFactory(sprint);
                mySpriteFactory.LoadAllTextures(sprint.Content);
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
            mySpriteFactory.LoadAllTextures(sprint.Content);
            //timerSprite = mySpriteFactory.UpdateDigits(gameTimer);


            //need to debug offset to work based of camera offset - not static values
            staticPosition.X = camera.center.X + numbers.staticPositionOffsetX;
            //staticPosition.Y = camera.center.Y + numbers.staticPositionOffsetY;

            letterPosition.X = staticPosition.X + numbers.letterPositionOffsetX;
            //letterPosition.Y = staticPosition.Y + numbers.letterPositionOffsetY;

            cardsPosition.X = staticPosition.X + numbers.cardsPositionOffsetX;
            //cardsPosition.Y = staticPosition.Y + numbers.cardsPositionOffsetY;

            worldPosition.X = staticPosition.X + numbers.worldPositionOffsetX;
            //worldPosition.Y = staticPosition.Y + numbers.worldPositionOffsetY;

            coinPosition.X = staticPosition.X + numbers.coinPositionOffsetX;
            //coinPosition.Y = staticPosition.Y + numbers.coinPositionOffsetY;

            livesPosition.X = staticPosition.X + numbers.livesPositionOffsetX;
            //livesPosition.Y = staticPosition.Y + numbers.livesPositionOffsetY;

            scorePosition.X = staticPosition.X + numbers.scorePositionOffsetX;
            //scorePosition.Y = staticPosition.Y + numbers.scorePositionOffsetY;

            timerPosition.X = staticPosition.X + numbers.timerPositionOffsetX;
            //timerPosition.Y = staticPosition.Y + numbers.timerPositionOffsetY;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            staticSprite.Draw(spritebatch, staticPosition);
            letter.Draw(spritebatch, letterPosition);
            cards.Draw(spritebatch, cardsPosition);
            world.Draw(spritebatch, worldPosition);
            coinSprite.Draw(spritebatch, coinPosition);
            lifeSprite.Draw(spritebatch, livesPosition);
            scoreSprite.Draw(spritebatch, scorePosition);
            timerSprite.Draw(spritebatch, timerPosition);
            timerSprite.Draw(spritebatch, timerPosition);
        }
    }
}
