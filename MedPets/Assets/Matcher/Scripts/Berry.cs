using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    [SerializeField] new string name;
    [SerializeField] string description;
    //Make sure this is the Index in the Berry Holder script in BoardManager
    [SerializeField] int id;
    [SerializeField] string[] tags;
    //Ids of incompatible berries
    [SerializeField] int[] incompatibility;
    [SerializeField] string[] requiredTags;
    [SerializeField] bool doesGravity;
    [SerializeField] int numToMatch;
    public int locX;
    public int locY;
    [SerializeField] private bool added = false;

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

    public int getId()
    {
        return id;
    }

    public int getNum2Match()
    {
        return numToMatch;
    }

    public void setPosition(int x, int y)
    {
        locX = x;
        locY = y;
    }

    public bool getAdded()
    {
        return added;
    }

    public void setAdded(bool b)
    {
        added = b;
    }

    public int getX()
    {
        return locX;
    }

    public int getY()
    {
        return locY;
    }

    public string[] getTags()
    {
        return tags;
    }

    public string[] getRequiredTags()
    {
        return requiredTags;
    }
}
