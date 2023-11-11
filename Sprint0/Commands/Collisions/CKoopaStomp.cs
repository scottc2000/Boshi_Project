using Sprint0.Characters;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Sprint0.Enemies;
using Sprint0.GameMangager;


namespace Sprint0.Commands.Collisions
{
    public class CKoopaStomp : ICommand
    {
        private Sprint0 sprint;
        private Koopa koopa;
        private ObjectManager objects;

        public CKoopaStomp(Sprint0 sprint)
        {
            this.sprint = sprint;
            objects = sprint.objects;
        }

        public void Execute()
        {
                  
        }

        public void Execute(Koopa koopa)
        {
            objects.RemoveFromList(koopa);
        }
    }
}
