using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using Sprint0.GameMangager;
using Sprint0.HUD;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private SpriteBatch sprites;
        private ObjectManager objectManager;
        private GameStats hud;

        public ScrnManager(Sprint0 sprint, SpriteBatch spriteBatch)
        {
            state = new HomeScreen(sprint, this);
            sprites = spriteBatch;
            objectManager = sprint.objects;
            mario = sprint.levelLoader.mario;
            luigi = sprint.levelLoader.luigi;
            hud = sprint.levelLoader.hud;
        }

        public void Death()
        {
            state.Death();
            state.Draw(sprites);
        }

            public void Draw()
            {
                state.Draw(sprites);
                //terrain.Draw(spriteBatch); // need to draw terrain before any game objects
                hud.Draw(sprites);

                // Draw each game object
                foreach (var block in objectManager.Blocks)
                {
                    block.Draw(sprites);
                }
                foreach (var item in objectManager.Items)
                {
                    item.Draw(sprites);
                }
                foreach (var enemy in objectManager.Enemies)
                {
                    enemy.Draw(sprites);
                }
                foreach (var proj in objectManager.Projectiles)
                {
                    proj.Draw(sprites);
                }

                mario.Draw(sprites);
                luigi.Draw(sprites);
            }


        public void Home()
        {
            state.Home();
            state.Draw(sprites);
        }

        public void Level1()
        {
            state.Level1();
            state.Draw(sprites);
        }
    }
}
