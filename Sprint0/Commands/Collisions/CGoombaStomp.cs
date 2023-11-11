using Sprint0.Characters;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Sprint0.Enemies;
using System.Runtime.Serialization;

namespace Sprint0.Commands.Collisions
{
    public class CGoombaStomp : ICommand
    {
        private Sprint0 sprint;
        private Goomba goomba;
        ObjectManager objectManager;

        public CGoombaStomp(Sprint0 sprint)
        {
            this.sprint = sprint;
            //objectManager = sprint.objects;
        }

        public void Execute()
        {
            goomba.BeStomped();       
        }

    }
}
