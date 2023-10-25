using Microsoft.Xna.Framework;
using Sprint0.Characters;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using Sprint0.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision
{
    public class CollisionHandler
    {
        
        List<IEnemies> Enemies;
        List<Item> Items;
        List<IBlock> Blocks, TopCollidableBlocks, BottomCollidableBlocks, SideCollidableBlocks;
        CollisionDictionraryRegister register;
        Rectangle blockHitbox;
        ICharacter luigi;
        ICharacter mario;
        

        public CollisionHandler(Sprint0 sprint, ObjectManager objects)
        { 
            Enemies = new List<IEnemies>();
            Items = new List<Item>();
            Blocks = objects.Blocks;
            TopCollidableBlocks = objects.TopCollidableBlocks;
            BottomCollidableBlocks = objects.BottomCollidableBlocks;
            SideCollidableBlocks = objects.SideCollidableBlocks;

            luigi = objects.luigi;
            mario = objects.mario;

            register = new CollisionDictionraryRegister(sprint);

            register.generate();
        }

        public void luigiUpdate()
        {
            
            foreach (IEnemies enemeny in Enemies)
               {
                    //if (character.hitbox)
               }

                foreach (Item item in Items)
                {
                    //if (character.hitbox)
                }

                foreach (IBlock block in Blocks)
                {
                    blockHitbox = new Rectangle(block.x, block.y, block.width, block.height);

                    if (luigi.destination.Intersects(blockHitbox))
                    {               
                        //register.collisions.playerBlockDict[new Tuple<List<ICharacter>, List<IBlock>, CollisionDictionary.Side>(Players, Blocks, CollisionDictionary.Side.Top)].Item1.Execute();

                            
                        if (Rectangle.Intersect(luigi.destination, blockHitbox).Width >= Rectangle.Intersect(luigi.destination, blockHitbox).Height)
                        {
                            if (blockHitbox.Y > luigi.destination.Y)
                            {
                                if (TopCollidableBlocks.Contains(block))
                                {   
                                    register.collisions.luigiBlock[new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(luigi, Blocks, CollisionDictionary.Side.Top)].Item1.Execute();
                                }
                            }

                            else if (blockHitbox.Y < luigi.destination.Y)
                            {
                                if (BottomCollidableBlocks.Contains(block))
                                {
                                    register.collisions.luigiBlock[new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(luigi, Blocks, CollisionDictionary.Side.Bottom)].Item1.Execute();
                                }
                            }
                        }


                        else
                        {
                            if (SideCollidableBlocks.Contains(block))
                            {
                                if (blockHitbox.X > luigi.destination.X)
                                {
                                    register.collisions.luigiBlock[new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(luigi, Blocks, CollisionDictionary.Side.Left)].Item1.Execute();
                                }

                                else if (blockHitbox.X < luigi.destination.X)
                                {
                                    register.collisions.luigiBlock[new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(luigi, Blocks, CollisionDictionary.Side.Right)].Item1.Execute();
                                }
                            }
                        }



                    }
                        
                }

                


                
                if (mario.destination.Intersects(luigi.destination))
                    {
                        register.collisions.luigiMario[new Tuple<ICharacter, ICharacter, CollisionDictionary.Side>(mario, luigi, CollisionDictionary.Side.Left)].Item1.Execute();
                        register.collisions.luigiMario[new Tuple<ICharacter, ICharacter, CollisionDictionary.Side>(mario, luigi, CollisionDictionary.Side.Left)].Item2.Execute();

                // if objects hit on x axis (left or right)
                        if (Rectangle.Intersect(mario.destination, luigi.destination).Width <= Rectangle.Intersect(mario.destination, luigi.destination).Height)
                             {
                           

                              }
       
                    }
                

                
            
        }

        public void blockUpdate()
        {
            foreach (IBlock block in Blocks)
            {
                foreach (IEnemies enemeny in Enemies)
                {
                    //if (character.hitbox)
                }

                foreach (Item item in Items)
                {
                    //if (character.hitbox)
                }

                

            }
        }
        


        public void enemyUpdate()
        {
            foreach (IEnemies enemy in Enemies)
            {
                foreach (IBlock block in Blocks)
                {
                    //if (character.hitbox)
                }

                foreach (Item item in Items)
                {
                    //if (character.hitbox)
                }

                

            }
        }


            public void Update()
        {



        }
    }
}
