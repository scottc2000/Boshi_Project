using Sprint0.Interfaces;
using System.Reflection;
using static Sprint0.Collision.CollisionDictionary;

namespace Sprint0.Collision
{
    public class MarioCollisionHandler
    {
        private Sprint0 sprint;
        private CollisionDictionary dictionary;

        public MarioCollisionHandler(Sprint0 sprint, CollisionDictionary dictionary) 
        {
            this.sprint = sprint;
            this.dictionary = dictionary;
        }
        public void MarioStaticBlockCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            if (dictionary.collision.TryGetValue((entity1, entity2, side), out var collisionLogic))
            {
                ConstructorInfo constructorInfo = collisionLogic.Item1;
                object instance = constructorInfo.Invoke(new object[] { sprint });
            }
        }
    }
}
