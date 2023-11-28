using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Sprint0.Camera;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using Sprint0.Utility;
using System.ComponentModel.Design;

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
        private int powerBoost { get; set; }

        // Sprite information
        private HUDFactory mySpriteFactory;
        private ISprite staticSprite;
        private ISprite letter;
        private ISprite world;
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

        private PlayerCamera camera;

        public GameStats(Sprint0 sprint, PlayerCamera camera)
        {
            this.sprint = sprint;
            this.camera = camera;
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
            //powerSprite = mySpriteFactory.UpdatePower(score);

            // Initialize starting location for HUD
            staticPosition = new Vector2(camera.center.X + numbers.staticPositionOffsetX, camera.center.Y + numbers.staticPositionOffsetY);
            letterPosition = new Vector2(camera.center.X + numbers.letterPositionOffsetX, camera.center.Y + numbers.letterPositionOffsetY);
            worldPosition = new Vector2(camera.center.X + numbers.worldPositionOffsetX, camera.center.Y + numbers.worldPositionOffsetY);
            coinPosition = new Vector2(camera.center.X + numbers.coinPositionOffsetX, camera.center.Y + numbers.coinPositionOffsetY);
            livesPosition = new Vector2(camera.center.X + numbers.livesPositionOffsetX, camera.center.Y + numbers.livesPositionOffsetY);
            scorePosition = new Vector2(camera.center.X + numbers.scorePositionOffsetX, camera.center.Y + numbers.scorePositionOffsetY);
            timerPosition = new Vector2(camera.center.X + numbers.timerPositionOffsetX, camera.center.Y + numbers.timerPositionOffsetY);
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

        public void Timer()
        {
            gameTimer--;
            mySpriteFactory = new HUDFactory(sprint);
            mySpriteFactory .LoadAllTextures(sprint.Content);
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

            // adjust position based on camera posiiton
            staticPosition.X = camera.center.X + numbers.staticPositionOffsetX;
            letterPosition.X = staticPosition.X + numbers.letterPositionOffsetX;
            worldPosition.X = staticPosition.X + numbers.worldPositionOffsetX;
            coinPosition.X = staticPosition.X + numbers.coinPositionOffsetX;
            livesPosition.X = staticPosition.X + numbers.livesPositionOffsetX;
            scorePosition.X = staticPosition.X + numbers.scorePositionOffsetX;
            timerPosition.X = staticPosition.X + numbers.timerPositionOffsetX;

            staticPosition.Y = camera.center.Y + numbers.staticPositionOffsetY;
            letterPosition.Y = staticPosition.Y + numbers.letterPositionOffsetY;
            worldPosition.Y = staticPosition.Y + numbers.worldPositionOffsetY;
            coinPosition.Y = staticPosition.Y + numbers.coinPositionOffsetY;
            livesPosition.Y = staticPosition.Y + numbers.livesPositionOffsetY;
            scorePosition.Y = staticPosition.Y + numbers.scorePositionOffsetY;
            timerPosition.Y = staticPosition.Y + numbers.timerPositionOffsetY;

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
            timerSprite.Draw(spritebatch, timerPosition);
        }
    }
}
