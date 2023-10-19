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
	//public Dictionary<Tuple<IObject, IObject, Side>, Tuple<ICommand, ICommand>> commandDictionary;

    public CollisionDictionary()
	{
      //  commandDictionary = new Dictionary<Tuple<IObject, IObject, Side>, Tuple<ICommand, ICommand>>();
    }

  /*  public void RegisterCommand(Tuple<IObject, IObject, Side> collisionType, Tuple<ICommand, ICommand> commands)
    {
           commandDictionary.Add(collisionType, commands);
    }*/
}
