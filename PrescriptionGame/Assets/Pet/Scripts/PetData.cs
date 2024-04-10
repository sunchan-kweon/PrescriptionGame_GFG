using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PetData
{
    public int food;
    public int happiness;
    public int energy;
    public bool firstTimePlaying;

    public PetData(){
        food = NeedsController.food;
        happiness = NeedsController.happiness;
        energy = NeedsController.energy;
        firstTimePlaying = NeedsController.firstTimePlaying;
    }
}
