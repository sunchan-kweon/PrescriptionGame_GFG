using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    [SerializeField] new string name;
    [SerializeField] string description;
    //Make sure this is the Index in the Berry Holder script in BoardManager
    [SerializeField] int id;
    //Ids of incompatible berries
    [SerializeField] int[] incompatibility;
    [SerializeField] bool doesGravity;
    [SerializeField] int numToMatch;

    //No Gravity Constructor
    public Berry(string n, string desc, int i, int numM, int[] incomp)
    {
        name = n;
        description = desc;
        id = i;
        incompatibility = incomp;
        numToMatch = numM;
        doesGravity = true;
    }
    //Constructor for if Gravity needs to be turned off - maybe future stuff.
    public Berry(string n, string desc, int i, int numM, int[] incomp, bool dG) : this(n, desc, i, numM, incomp)
    {
        doesGravity = dG;
    }

    public string getName()
    {
        return name;
    }

    public string getDescription()
    {
        return description;
    }

    public int[] getIncomp()
    {
        return incompatibility;
    }

    public bool gravity()
    {
        return doesGravity;
    }
}