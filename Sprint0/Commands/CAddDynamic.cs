using Sprint0.Interfaces;
using Sprint0.GameMangager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    internal class CAddDynamic : ICommand
    {
        private ICollidable entity;
        private ObjectManager objectManager;
        public CAddDynamic(ICollidable entity, ObjectManager objectManager)
        {
            this.entity = entity;
            this.objectManager = objectManager;
        }

        public void Execute()
        {
            objectManager.EntitiesToAdd.Add(entity);
        }
    }
}
