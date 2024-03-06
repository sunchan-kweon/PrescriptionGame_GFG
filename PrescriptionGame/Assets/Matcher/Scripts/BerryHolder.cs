using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryHolder : MonoBehaviour
{
    //Static Container that can be added to in the inspector when on an object
    [SerializeField] Berry[] container;

    //Method to get Berry by ID/position in the container
    public Berry getBerry(int id)
    {
        return container[id];
    }

    
}
