using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Registrator
{
    private static readonly List<ChairLogic> chairs = new List<ChairLogic>();
    private static readonly List<VisitorLogic> visitors = new List<VisitorLogic>();

    public static void registerChair(ChairLogic chair)
    {
        chairs.Add(chair);
        //Debug.Log("Chair registered");
    }

    public static void registerVisitor(VisitorLogic visitor)
    {
        visitors.Add(visitor);
        //Debug.Log("Visitor registered");
    }

    public static List<ChairLogic> getFreeChairs()
    {
        return chairs.Where(chair => chair.isFree()).ToList();
    }
}
