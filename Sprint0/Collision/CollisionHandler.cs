using Microsoft.Xna.Framework;
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
        List<ICharacter> Players;
        List<IEnemies> Enemies;
        List<Item> Items;
        List<IBlock> Blocks;
        CollisionDictionraryRegister register;
       

        public CollisionHandler(Sprint0 sprint)
        {
            Players = sprint.objects.Players;
            Enemies = new List<IEnemies>();
            Items = new List<Item>();
            Blocks = new List<IBlock>();
            register = new CollisionDictionraryRegister(sprint);
            
            register.generate();
        }

        public void playerUpdate()
        {
            foreach (ICharacter character in Players)
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
                    //if (character.hitbox)
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

                foreach (Item item in Items)
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

                foreach (Item item in Items)
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
