using Sprint0.Blocks;
using Sprint0.Characters;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using System.Collections.Generic;
using static Sprint0.Collision.CollisionDictionary;

namespace Sprint0.Collision
{
    public class CollisionDetector
    {
        private Sprint0 sprint;
        private List<ICollidable> DynamicEntities;
        private List<ICollidable> StaticEntities;
        private MarioCollisionHandler marioCollisionHandler;

        private CollisionDictionary dictionary;
        public CollisionDetector(Sprint0 sprint, ObjectManager objects)
        {
            this.sprint = sprint;
            DynamicEntities = objects.DynamicEntities;
            StaticEntities = objects.StaticEntites;

            dictionary = new CollisionDictionary();
            dictionary.generateDictionary();

            marioCollisionHandler = new MarioCollisionHandler(sprint, dictionary);

            DetectCollision();
        }

        public void DetectCollision() 
        {
            for (int i = 0; i < DynamicEntities.Count; i++)
            {
                ICollidable entity1 = DynamicEntities[i];

                for(int j = i + 1; j < StaticEntities.Count; j++)
                {
                    ICollidable entity2 = DynamicEntities[j];
                    if (entity1.Destination.Intersects(entity2.Destination)) 
                    {
                        if (entity1.Destination.Left <= entity2.Destination.Right && entity1.Destination.Right >= entity2.Destination.Left)
                        {
                            HandleCollision(entity1, entity2, Side.Horizontal);
                        }
                        else if (entity1.Destination.Top <= entity2.Destination.Bottom && entity1.Destination.Bottom >= entity2.Destination.Top)
                        {
                            HandleCollision(entity1, entity2, Side.Vertical);
                        }
                    }
                }
                foreach(ICollidable entity in StaticEntities)
                {
                    if (entity1.Destination.Intersects(entity.Destination))
                    {
                        if (entity1.Destination.Left <= entity.Destination.Right && entity1.Destination.Right >= entity.Destination.Left)
                        {
                            HandleCollision(entity1, entity, Side.Horizontal);
                        }
                        else if (entity1.Destination.Top <= entity.Destination.Bottom && entity1.Destination.Bottom >= entity.Destination.Top)
                        {
                            HandleCollision(entity1, entity, Side.Vertical);
                        }
                    }
                }
            }
        }

        public void HandleCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            if (entity1 is Mario && (entity2 is Floor || entity2 is Clouds || entity2 is LargeBlock || entity2 is Pipe || entity2 is WoodBlocks || entity2 is YellowBrick))
            {
                ICollidable staticBlock = entity2;
                marioCollisionHandler.MarioStaticBlockCollision(entity1, staticBlock, side);
            }

        }
    }
}
