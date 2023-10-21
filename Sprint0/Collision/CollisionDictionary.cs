using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0;
using Sprint0.Characters;
using Sprint0.Commands;
using Sprint0.Commands.Mario;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;


public class CollisionDictionary
{
    public enum Side { Left, Right, Top, Bottom };

    // dictionary for each possible combination of collisions (enemy, player), (player, player), (player block), (enemies, block)

    public Dictionary<Tuple<List<ICharacter>, List<IEnemies>, Side>, Tuple<ICommand, ICommand>> enemyPlayerDict;

    public Dictionary<Tuple<List<ICharacter>, List<ICharacter>, Side>, Tuple<ICommand, ICommand>> playerPlayerDict;

    public Dictionary<Tuple<List<ICharacter>, List<IBlock>, Side>, Tuple<ICommand, ICommand>> playerBlockDict;

    public Dictionary<Tuple<List<IEnemies>, List<IBlock>, Side>, Tuple<ICommand, ICommand>> enemiesBlockDict;


    public CollisionDictionary()
    {

        enemyPlayerDict = new Dictionary<Tuple<List<ICharacter>, List<IEnemies>, Side>, Tuple<ICommand, ICommand>>();
        playerPlayerDict = new Dictionary<Tuple<List<ICharacter>, List<ICharacter>, Side>, Tuple<ICommand, ICommand>>();
        playerBlockDict = new Dictionary<Tuple<List<ICharacter>, List<IBlock>, Side>, Tuple<ICommand, ICommand>>();
        enemiesBlockDict = new Dictionary<Tuple<List<IEnemies>, List<IBlock>, Side>, Tuple<ICommand, ICommand>>();

    }
}