using Sprint0.Commands.Collision;
using Sprint0.Commands.Collisions;
using Sprint0.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace Sprint0.Collision
{
    public class CollisionDictionary
    {
        private ICollidable mario;
        private ICollidable luigi;
        private ICollidable item;
        private ICollidable enemy;
        private ICollidable staticBlock;
        private ICollidable questionBlock;
        private ICollidable coins;
        public enum Side { None, Vertical, Horizontal, Left, Right, Top, Bottom, Any}

        public Dictionary<(ICollidable, ICollidable, Side), (ConstructorInfo, ConstructorInfo)> collision;

        public CollisionDictionary()
        {
            collision = new Dictionary<(ICollidable, ICollidable, Side), (ConstructorInfo, ConstructorInfo)>();
        }

        public void generateDictionary()
        {
            /*_____ Get Constructors ______*/
            ConstructorInfo marioStuckX = typeof(CMarioStuckX).GetConstructor(new[] { typeof(Sprint0) });
            ConstructorInfo luigiStuckX = typeof(CLuigiStuckX).GetConstructor(new[] { typeof(Sprint0) });
            ConstructorInfo marioStuckY = typeof(CMarioStuckY).GetConstructor(new[] { typeof(Sprint0) });
            ConstructorInfo luigiStuckY = typeof(CLuigiStuckY).GetConstructor(new[] { typeof(Sprint0) });

            ConstructorInfo marioTakeDamage = typeof(CMarioTakeDamage).GetConstructor(new[] { typeof(Sprint0) });
            ConstructorInfo powerUp = typeof(CMarioPowerUp).GetConstructor(new[] { typeof(Sprint0), typeof(IItem) });

            //ConstructorInfo luigiTakeDamage = typeof(CLuigiTakeDamage).GetConstructor(new[] { typeof(Sprint0) });

            ConstructorInfo getCoin = typeof(CGetCoin).GetConstructor(new[] { typeof(Sprint0) });

            ConstructorInfo itemRemove = typeof(CItemDisappear).GetConstructor(new[] { typeof(Sprint0) });  // Add parameters as needed
            //ConstructorInfo blockRemove = typeof(CBlockRemove).GetConstructor(new[] {typeof(Sprint0) });  // Add parameters as needed
            //ConstructorInfo enemyRemove = typeof(CEnemyRemove).GetCOnstructor(new[] {typeof(Sprint0) });  // Add parameters as needed



            /*____ Mario and Luigi ______*/
            collision.Add((mario, luigi, Side.Horizontal), (marioStuckX, luigiStuckX));
            collision.Add((mario, luigi, Side.Vertical), (marioStuckY, luigiStuckY));

            /*____ Mario and Block ______*/
            collision.Add((mario, staticBlock, Side.Horizontal), (marioStuckX, null));
            collision.Add((mario, staticBlock, Side.Vertical), (marioStuckY, null));
            collision.Add((mario, coins, Side.Any), (getCoin, null)); // replace null with remove block

            /*____ Mario and Item _______*/
            collision.Add((mario, item, Side.Any), (powerUp, itemRemove));

            /*____ Mario and Enemy _____*/
            collision.Add((mario, enemy, Side.Horizontal), (marioTakeDamage, null));
            //collision.Add((mario, enemy, Side.Top), (null, enemyRemove));

            /*____ Luigi and Block ______*/

            /*_____ Luigi and Item ______*/
        }
    }
}
