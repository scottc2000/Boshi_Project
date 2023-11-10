using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Background;
using Sprint0.Camera;
using Sprint0.Characters;
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
        public List<IBlock> Blocks { get; set; }
        public List<IBlock> TopCollidableBlocks { get; set; }
        public List<IBlock> BottomCollidableBlocks { get; set; }
        public List<IBlock> SideCollidableBlocks { get; set; }
        public List<IItem> Items { get; set; } 
        public List<IEnemies> Enemies { get;set; }

        public List<IEntity> StaticEntities { get; set; }
        public List<IEntity> DynamicEntities { get; set; }
        public List<IEntity> EntitiesToAdd { get; set; }
        public List<IEntity> EntitiesToRemove { get; set; }

        public IMario mario;
        public ICharacter luigi;

        private Sprint0 sprint;
        
        public ObjectManager(Sprint0 sprint0, MarioCamera camera)
        {
            this.sprint = sprint0;
            this.camera = camera;
            terrain = new Terrain(this.sprint);
            Items = new List<IItem>();
            Enemies = new List<IEnemies>();
            Blocks = new List<IBlock>();
            TopCollidableBlocks = new List<IBlock>();
            BottomCollidableBlocks = new List<IBlock>();
            SideCollidableBlocks = new List<IBlock>();
            StaticEntities = new List<IEntity>();
            DynamicEntities = new List<IEntity>();
            EntitiesToAdd = new List<IEntity>();
            EntitiesToRemove = new List<IEntity>();

            mario = new Mario(sprint);
            luigi = new Luigi(sprint);
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            terrain.Draw(spriteBatch); // need to draw terrain before any game objects

            foreach (var entity in StaticEntities)
            {
                entity.Draw(spriteBatch);
            }
            foreach(var entity in DynamicEntities)
            {
                entity.Draw(spriteBatch);
            }

            mario.Draw(spriteBatch);
            luigi.Draw(spriteBatch);

        }


        public void Update(GameTime gameTime, CollisionHandler collision)
        {
            terrain.Update(gameTime);   // need to update terrain before any game objects

            foreach (var entity in StaticEntities)
            {
                entity.Update(gameTime);
            }
            foreach (var entity in DynamicEntities)
            {
                entity.Update(gameTime);
            }

            foreach (IEntity entity in EntitiesToAdd)
            {
                DynamicEntities.Add(entity);
            }
            foreach (IEntity entity in EntitiesToRemove)
            {
                DynamicEntities.Remove(entity);
            }
            EntitiesToAdd.Clear();
            EntitiesToRemove.Clear();

            mario.Update(gameTime);
            luigi.Update(gameTime);
            collision.Update();

            camera.Update(gameTime, mario);
            
        }
    }

}