using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFirstTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(NeedsController.firstTimePlaying == true)
        {
            NeedsController.firstTimePlaying = false;
            NeedsController.food = 100;
            NeedsController.happiness = 100;
            NeedsController.energy = 100;
        }
        SaveSystem.SavePet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
