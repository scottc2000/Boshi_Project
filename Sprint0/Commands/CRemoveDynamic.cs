using Sprint0.GameMangager;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    internal class CRemoveDynamic : ICommand
    {
        private ICollidable entity;
        private ObjectManager objectManager;
        public CRemoveDynamic(ICollidable entity, ObjectManager objectManager)
        {
            this.entity = entity;
            this.objectManager = objectManager;
        }

        public void Execute()
        {
            objectManager.EntitiesToRemove.Add(entity);
        }
    }
}
