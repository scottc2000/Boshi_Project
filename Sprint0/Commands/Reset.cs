using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Background;
using Sprint0.Camera;
using Sprint0.Characters;
using Sprint0.Collision;
using Sprint0.Controllers;
using Sprint0.Enemies;
using Sprint0.GameMangager;
using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactories;
using Sprint0.Utility;
using System.Reflection.Metadata;

namespace Sprint0.Commands
{
    public class Reset : ICommand
    {
        private Sprint0 sprint;
        private SpriteBatch spriteBatch;
        private PlayerNumbers p;

        public Reset(Sprint0 game)
        {
            sprint = game;
            p = new PlayerNumbers();
            
        }
        public void Execute()
        {

            sprint.gamestates = GameStates.TITLE;
            sprint.objects = new ObjectManager(sprint);
            sprint.mario = new Characters.Player(sprint, p.mario);
            sprint.luigi = new Characters.Player(sprint, p.luigi);
            sprint.hud = new GameStats(sprint);
            sprint.camera = new PlayerCamera(sprint.GraphicsDevice.Viewport);
            sprint.levelLoader = new LevelLoader1(sprint, sprint._spriteBatch, sprint.Content, sprint.camera, sprint.mario, sprint.luigi, sprint.hud);
            sprint.KeyboardController = new KeyboardController(sprint, sprint.mario, sprint.luigi, sprint.hud);
            sprint.detector = new CollisionDetector(sprint, sprint.objects);
            spriteBatch = new SpriteBatch(sprint.GraphicsDevice);
        }

    }
}
