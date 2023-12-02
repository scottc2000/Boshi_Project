using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using Sprint0.Camera;
using Sprint0.GameMangager;
using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Background
{
    public class ScrnManager
    {

        public IScreen state;
        private IPlayer luigi;
        private IPlayer mario;
        private Texture2D terrain;
        private ISprite sprite;
        private Vector2 location;
        StaticCamera startCamera;
        PlayerCamera playerCamera;

        private SpriteBatch spriteBatch;
        private ObjectManager objectManager;
        public enum Camera {Start, Player, Dead};
        public Camera currentCamera { get; set; }

        public ScrnManager(Sprint0 sprint, SpriteBatch _spriteBatch, GraphicsDevice graphicsDevice)
        {
            spriteBatch = _spriteBatch;
            objectManager = sprint.objects;
            mario = sprint.levelLoader.mario;
            luigi = sprint.levelLoader.luigi;
            startCamera = new StaticCamera(graphicsDevice.Viewport, 300, 100);
            playerCamera = new PlayerCamera(graphicsDevice.Viewport);
            terrain = sprint.Content.Load<Texture2D>("smb_background");
            
        }

        public void Draw()
        {
            //terrain.Draw(spriteBatch); // need to draw terrain before any game objects

            // Draw each game object
            switch (currentCamera)
            {
                case Camera.Start:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                null, null, null, null, startCamera.transform);
                    sprite = new DrawBackground(terrain, new Rectangle(0, 0, 2816, 626));
                    startCamera.Update(mario, luigi);
                    break;
                case Camera.Player:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                null, null, null, null, playerCamera.transform);
                    sprite = new DrawBackground(terrain, new Rectangle(0, 0, 2816, 626));
                    playerCamera.Update(mario, luigi);
                    break;
            }

            foreach (var block in objectManager.Blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (var item in objectManager.Items)
            {
                item.Draw(spriteBatch);
            }
            foreach (var enemy in objectManager.Enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (var proj in objectManager.Projectiles)
            {
                proj.Draw(spriteBatch);
            }
            startCamera.Update(mario, luigi);

            mario.Draw(spriteBatch);
            luigi.Draw(spriteBatch);
        }
    }
}

