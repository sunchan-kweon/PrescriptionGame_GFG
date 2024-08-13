using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimePet : MonoBehaviour
{
    public static bool firstTime = true;

    void Start()
    {
        if (firstTime)
        {
            //enable tutorial panel
            firstTime = false;
        }
    }
}
