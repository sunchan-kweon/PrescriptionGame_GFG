using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFirstTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(NeedsController.playedOnce == false)
        {
            NeedsController.food = 100;
            NeedsController.happiness = 50;
            NeedsController.energy = 100;
        }
        NeedsController.playedOnce = true;
        SaveSystem.SavePet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
