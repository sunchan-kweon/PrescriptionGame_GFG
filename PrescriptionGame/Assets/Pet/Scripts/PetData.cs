using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PetData
{
    public int food;
    public int happiness;
    public int energy;

    public PetData(NeedsController pet){
        food = pet.food;
        happiness = pet.happiness;
        energy = pet.energy;
    }
}
