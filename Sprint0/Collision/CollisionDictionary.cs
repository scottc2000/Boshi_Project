using Sprint0.Characters;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

public class CollisionDictionary
{
    public enum Side { None, Left, Right, Top, Bottom, Dont_Care };

    //New collision handler dictionary
    public Dictionary<(ICollidable, ICollidable, Side), (ConstructorInfo, ConstructorInfo)> collision;


    public CollisionDictionary()
    {
        collision = new Dictionary<(ICollidable, ICollidable, Side), (ConstructorInfo, ConstructorInfo)>();
    }
}