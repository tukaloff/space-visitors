using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairLogic : MonoBehaviour
{
    private static int counter = 0;
    private bool isChairFree = true;
    // Start is called before the first frame update
    void Start()
    {
        name += counter++;
        Registrator.registerChair(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isFree()
    {
        return isChairFree;
    }

    internal void takeThePlace()
    {
        isChairFree = false;
    }

    internal void free()
    {
        isChairFree = true;
    }
}
