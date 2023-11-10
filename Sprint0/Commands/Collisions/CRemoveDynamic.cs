using Sprint0.GameMangager;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.Collisions
{
    public class CRemoveDynamic: ICommand
    {
        private IEntity entity;
        private ObjectManager objectManager;
        public CRemoveDynamic(ObjectManager objectManager, IEntity entity)
        {
            this.objectManager = objectManager;
            this.entity = entity;
        }

        public void Execute()
        {
            objectManager.EntitiesToRemove.Add(entity);
        }
    }
}
