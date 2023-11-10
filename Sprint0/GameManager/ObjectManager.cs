using Sprint0.Interfaces;
using System.Collections.Generic;

namespace Sprint0.GameMangager
{
    public class ObjectManager
    {
        public List<IBlock> TopCollidableBlocks { get; set; }
        public List<IBlock> BottomCollidableBlocks { get; set; }
        public List<IBlock> SideCollidableBlocks { get; set; }
        public List<IBlock> ThroughCollidableBlocks { get; set; }
        public List<IProjectile> Projectiles { get; set; }
        public List<IItem> Items { get; set; }
        public List<IBlock> Blocks { get; set; }
        public List<IEnemies> Enemies { get; set; }
        public List<ICollidable> StaticEntities { get; set; }
        public List<ICollidable> DynamicEntities { get; set; }
        public List<ICollidable> EntitiesToAdd { get; set; }
        public List<ICollidable> EntitiesToRemove { get; set; }

        private Sprint0 sprint;
        
        public ObjectManager(Sprint0 sprint0)
        {
            sprint = sprint0;

            Items = new List<IItem>();
            Blocks = new List<IBlock>();
            Enemies = new List<IEnemies>();

            TopCollidableBlocks = new List<IBlock>();
            BottomCollidableBlocks = new List<IBlock>();
            SideCollidableBlocks = new List<IBlock>();
            ThroughCollidableBlocks = new List<IBlock>();
            Projectiles = new List<IProjectile>();
            
            StaticEntities = new List<ICollidable>();
            DynamicEntities = new List<ICollidable>();
            EntitiesToAdd = new List<ICollidable>();
            EntitiesToRemove = new List<ICollidable>();            
        }

        public void AddToList()
        {

        }
        public void RemoveFromList()
        {

        }
       
    }

}