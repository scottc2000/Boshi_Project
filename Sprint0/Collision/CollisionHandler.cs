using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;

namespace Sprint0.Collision
{
    public class CollisionHandler
    {
        List<ICharacter> Players;
        List<IEnemies> Enemies;
        List<IItem> Items;
        List<IBlock> Blocks;
        CollisionDictionraryRegister register;
        Rectangle blockHitbox;


        public CollisionHandler(Sprint0 sprint)
        {
            Players = sprint.objects.Players;
            Enemies = sprint.objects.Enemies;
            Items = sprint.objects.Items;
            Blocks = sprint.objects.Blocks;
            register = new CollisionDictionraryRegister(sprint);

            register.generate();
        }

        public void playerUpdate()
        {
            foreach (ICharacter character in Players)
            {
                foreach (IEnemies enemy in Enemies)
                {
                    if (character.destination.Intersects(enemy.destination))
                    {
                        // if objects hit on x axis (left or right)
                        if (Rectangle.Intersect(character.destination, enemy.destination).Width <= Rectangle.Intersect(character.destination, enemy.destination).Height)
                        {
                            register.collisions.enemyPlayerDict[new Tuple<List<ICharacter>, List<IEnemies>, CollisionDictionary.Side>(Players, Enemies, CollisionDictionary.Side.Left)].Item1.Execute();
                            register.collisions.enemyPlayerDict[new Tuple<List<ICharacter>, List<IEnemies>, CollisionDictionary.Side>(Players, Enemies, CollisionDictionary.Side.Right)].Item1.Execute();

                            System.Diagnostics.Debug.WriteLine("Player hit enemy");
                        }
                    }
                }

                foreach (IItem item in Items)
                {
                    //if (character.hitbox)
                }

                foreach (IBlock block in Blocks)
                {
                    blockHitbox = new Rectangle(block.x, block.y, block.width, block.height);
                    if (character.destination.Intersects(blockHitbox))
                    {

                        if (Rectangle.Intersect(character.destination, blockHitbox).Width <= Rectangle.Intersect(character.destination, blockHitbox).Height)
                        {
                            register.collisions.playerBlockDict[new Tuple<List<ICharacter>, List<IBlock>, CollisionDictionary.Side>(Players, Blocks, CollisionDictionary.Side.Left)].Item1.Execute();

                        }
                        else if (Rectangle.Intersect(character.destination, blockHitbox).Y < character.destination.Y)
                        {
                            register.collisions.playerBlockDict[new Tuple<List<ICharacter>, List<IBlock>, CollisionDictionary.Side>(Players, Blocks, CollisionDictionary.Side.Top)].Item1.Execute();
                        }
                        else
                        {
                            
                            // if object below
                            ;
                        }
                    }

                }
                foreach (ICharacter character1 in Players)
                {
                    if (character.destination.Intersects(character1.destination) && !(character.Equals(character1)))
                    {

                        // if objects hit on x axis (left or right)
                        if (Rectangle.Intersect(character.destination, character1.destination).Width <= Rectangle.Intersect(character.destination, character1.destination).Height)
                        {
                            register.collisions.playerPlayerDict[new Tuple<List<ICharacter>, List<ICharacter>, CollisionDictionary.Side>(Players, Players, CollisionDictionary.Side.Left)].Item1.Execute();
                            register.collisions.playerPlayerDict[new Tuple<List<ICharacter>, List<ICharacter>, CollisionDictionary.Side>(Players, Players, CollisionDictionary.Side.Left)].Item2.Execute();
                            System.Diagnostics.Debug.WriteLine("Player hit player");
                        }
                        else
                        {
                            if (Rectangle.Intersect(character.destination, character1.destination).Y < character.destination.Y)
                            {

                                // if object above
                                ;
                            }

                            else
                            {

                                // if object below
                                ;
                            }
                        }

                        Console.WriteLine("HIT");
                    }
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

                foreach (IItem item in Items)
                {
                    //if (character.hitbox)
                }

                foreach (ICharacter player in Players)
                {

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


                foreach (ICharacter player in Players)
                {

                }

            }
        }


        public void Update()
        {



        }
    }
    }
