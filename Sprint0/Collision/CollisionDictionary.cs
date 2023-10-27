using Sprint0.Interfaces;
using System;
using System.Collections.Generic;


public class CollisionDictionary
{
    public enum Side { Left, Right, Top, Bottom, Any };

    // dictionary for each possible combination of collisions (enemy, player), (player, player), (player, block), (enemies, block)

    public Dictionary<Tuple<List<ICharacter>, List<IEnemies>, Side>, Tuple<ICommand, ICommand>> enemyPlayerDict;

    public Dictionary<Tuple<ICharacter, List<IEnemies>, Side>, Tuple<ICommand, ICommand>> luigiEnemy;

    public Dictionary<Tuple<ICharacter, List<IBlock>, Side>, Tuple<ICommand, ICommand>> luigiBlock;

    public Dictionary<Tuple<ICharacter, ICharacter, Side>, Tuple<ICommand, ICommand>> luigiMario;

    public Dictionary<Tuple<ICharacter, List<IEnemies>, Side>, Tuple<ICommand, ICommand>> marioEnemy;

    public Dictionary<Tuple<ICharacter, List<IBlock>, Side>, Tuple<ICommand, ICommand>> marioBlock;

    public Dictionary<Tuple<ICharacter, List<IItem>, Side>, Tuple<ICommand, ICommand>> marioItem;

    public Dictionary<Tuple<List<IEnemies>, List<IBlock>, Side>, Tuple<ICommand, ICommand>> enemiesBlockDict;

    public Dictionary<Tuple<List<IItem>, List<IBlock>, Side>, Tuple<ICommand, ICommand>> itemBlock;


    public CollisionDictionary()
    {

        enemyPlayerDict = new Dictionary<Tuple<List<ICharacter>, List<IEnemies>, Side>, Tuple<ICommand, ICommand>>();
        enemiesBlockDict = new Dictionary<Tuple<List<IEnemies>, List<IBlock>, Side>, Tuple<ICommand, ICommand>>();

        luigiEnemy = new Dictionary<Tuple<ICharacter, List<IEnemies>, Side>, Tuple<ICommand, ICommand>>();
        luigiBlock = new Dictionary<Tuple<ICharacter, List<IBlock>, Side>, Tuple<ICommand, ICommand>>();
        luigiMario = new Dictionary<Tuple<ICharacter, ICharacter, Side>, Tuple<ICommand, ICommand>>();
        marioEnemy = new Dictionary<Tuple<ICharacter, List<IEnemies>, Side>, Tuple<ICommand, ICommand>>();
        marioBlock = new Dictionary<Tuple<ICharacter, List<IBlock>, Side>, Tuple<ICommand, ICommand>>();
        marioItem = new Dictionary<Tuple<ICharacter, List<IItem>, Side>, Tuple<ICommand, ICommand>>();

        itemBlock = new Dictionary<Tuple<List<IItem>, List<IBlock>, Side>, Tuple<ICommand, ICommand>>();

    }
}