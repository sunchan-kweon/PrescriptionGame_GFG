using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PetData
{
    public int food;
    public int happiness;
    public int energy;
    public bool playedOnce;

    public int caffeine;
    public int insulin;
    public int metformin;


    public PetData(){
        food = NeedsController.food;
        happiness = NeedsController.happiness;
        energy = NeedsController.energy;
        playedOnce = NeedsController.playedOnce;
        caffeine = Inventory.caffeine;
        insulin = Inventory.insulin;
        metformin = Inventory.metformin;
    }
}
