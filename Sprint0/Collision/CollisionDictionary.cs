using Sprint0.Characters;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;


public class CollisionDictionary
{
    public enum Side { Left, Right, Top, Bottom, Any };

    // dictionary for each possible combination of collisions (enemy, player), (player, player), (player, block), (enemies, block)

    //public Dictionary<(ICharacter, List<IEnemies>, Side), (ICommand c1, ICommand c2)> luigiEnemy;
    public Dictionary<Tuple<ICharacter, List<IEnemies>, Side>, Tuple<ICommand, ICommand>> luigiEnemy;

    public Dictionary<Tuple<ICharacter, List<IBlock>, Side>, Tuple<ICommand, ICommand>> luigiBlock;

    public Dictionary<Tuple<IMario, ICharacter, Side>, Tuple<ICommand, ICommand>> luigiMario;

    public Dictionary<Tuple<IMario, List<IEnemies>, Side>, Tuple<ICommand, ICommand>> marioEnemy;

    public Dictionary<Tuple<IMario, List<IBlock>, Side>, Tuple<ICommand, ICommand>> marioBlock;

    public Dictionary<Tuple<IMario, List<IItem>, Side>, Tuple<ICommand, ICommand>> marioItem;

    public Dictionary<Tuple<List<IEnemies>, List<IBlock>, Side>, Tuple<ICommand, ICommand>> enemiesBlockDict;

    public Dictionary<Tuple<List<IItem>, List<IBlock>, Side>, Tuple<ICommand, ICommand>> itemBlock;

    //New collision handler dictionary
    public Dictionary<(System.Type, System.Type, Side), Action<IEntity, IEntity>> collision;
    //public Dictionary<(IEntity, IEntity, Side), (ICommand, ICommand)> staticDynamicCollide;
    //public Dictionary<(IEntity, IEntity, Side), (ICommand, ICommand)> dynamicDynamicCollide;
    //public Dictionary<(ICharacter, IEnemies, Side), (ICommand, ICommand)> luigiEnemy1;
    //public Dictionary<(ICharacter, IBlock, Side), (ICommand, ICommand)> luigiBlock1;
    //public Dictionary<(ICharacter, IItem, Side), (ICommand, ICommand)> luigiItem1;
    //public Dictionary<(IMario, ICharacter, Side), (ICommand, ICommand)> luigiMario1;
    //public Dictionary<(IMario, IEnemies, Side), (ICommand, ICommand)> marioEnemy1;
    //public Dictionary<(IMario, IBlock, Side), (ICommand, ICommand)> marioBlock1;
    //public Dictionary<(IMario, IItem, Side), (ICommand, ICommand)> marioItem1;
    //public Dictionary<(IEnemies, IBlock, Side), (ICommand, ICommand)> enemyBlock1;
    //public Dictionary<(IItem, IBlock, Side), (ICommand, ICommand)> itemBlock1;


    public CollisionDictionary()
    {
        enemiesBlockDict = new Dictionary<Tuple<List<IEnemies>, List<IBlock>, Side>, Tuple<ICommand, ICommand>>();

        luigiEnemy = new Dictionary<Tuple<ICharacter, List<IEnemies>, Side>, Tuple<ICommand, ICommand>>();
        luigiBlock = new Dictionary<Tuple<ICharacter, List<IBlock>, Side>, Tuple<ICommand, ICommand>>();
        luigiMario = new Dictionary<Tuple<IMario, ICharacter, Side>, Tuple<ICommand, ICommand>>();
        marioEnemy = new Dictionary<Tuple<IMario, List<IEnemies>, Side>, Tuple<ICommand, ICommand>>();
        marioBlock = new Dictionary<Tuple<IMario, List<IBlock>, Side>, Tuple<ICommand, ICommand>>();
        marioItem = new Dictionary<Tuple<IMario, List<IItem>, Side>, Tuple<ICommand, ICommand>>();

        itemBlock = new Dictionary<Tuple<List<IItem>, List<IBlock>, Side>, Tuple<ICommand, ICommand>>();

        collision = new Dictionary<(System.Type, System.Type, Side), Action<IEntity, IEntity>>();

    }
}