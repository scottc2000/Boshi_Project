using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Background;
using Sprint0.Camera;
using Sprint0.Characters;
using Sprint0.HUD;
using Sprint0.Collision;
using Sprint0.Interfaces;
using System.Collections.Generic;

namespace Sprint0.GameMangager
{
    public class ObjectManager : IGameObject
    {
        public string Name { get; }

        public MarioCamera camera;

        private Terrain terrain;
        public GameStats hud;
        public List<IBlock> Blocks { get; set; }
        public List<IBlock> TopCollidableBlocks { get; set; }
        public List<IBlock> BottomCollidableBlocks { get; set; }
        public List<IBlock> SideCollidableBlocks { get; set; }
        public List<IItem> Items { get; set; } 
        public List<IEnemies> Enemies { get;set; }
        public List<IProjectile> Projectiles { get; set; }

        public Luigi luigi;
        public IMario mario;

        private Sprint0 sprint;
        
        public ObjectManager(Sprint0 sprint0, MarioCamera camera)
        {
            sprint = sprint0;
            this.camera = camera;
            terrain = new Terrain(sprint);
            hud = new GameStats(sprint);
            Items = new List<IItem>();
            Enemies = new List<IEnemies>();
            Blocks = new List<IBlock>();
            TopCollidableBlocks = new List<IBlock>();
            BottomCollidableBlocks = new List<IBlock>();
            SideCollidableBlocks = new List<IBlock>();
            Projectiles = new List<IProjectile>();

            mario = new Mario(sprint);
            luigi = new Luigi(sprint);
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            terrain.Draw(spriteBatch); // need to draw terrain before any game objects

            // Draw each game object
            foreach (var block in Blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach(var item in Items)
            {
                item.Draw(spriteBatch);
            }
            foreach(var enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }

            mario.Draw(spriteBatch);
            luigi.Draw(spriteBatch);
            hud.Draw(spriteBatch);

        }


        public void Update(GameTime gameTime, CollisionHandler collision)
        {
            terrain.Update(gameTime);   // need to update terrain before any game objects

            // Update each game object
            foreach (var block in Blocks)
            {
                block.Update(gameTime);
            }
            foreach(var item in Items)
            {
                item.Update(gameTime);
            }
            foreach (var enemy in Enemies)
            {
                enemy.Update(gameTime);
            }
            mario.Update(gameTime);
            luigi.Update(gameTime);
            collision.Update();

            camera.Update(gameTime, mario);
            hud.Update(gameTime);
            
        }
    }

}