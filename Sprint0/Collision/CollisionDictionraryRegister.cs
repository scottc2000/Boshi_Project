using Sprint0.Characters;
using Sprint0.Blocks;
using Sprint0.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision
{

    public class CollisionDictionraryRegister
    {
        public CollisionDictionary collisions;

        public CollisionDictionraryRegister()
        {
            collisions = new CollisionDictionary();
        }

        public void generate()
        {
            //collisions.RegisterCommand(Tuple<Mario, Block, CollisionDictionary.Side.Left>, Tuple </*moveMarioLeft*/, null >);
            //Needs every possible collision combination registered
        }
    }
}
