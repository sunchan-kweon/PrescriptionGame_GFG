using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public static int food;
    public static int happiness;
    public static int energy;
    public static bool playedOnce;

    public PetUIController foodBar;
    public PetUIController happinessBar;
    public PetUIController energyBar;

    public void SavePet()
    {
        SaveSystem.SavePet();
    }

    public void LoadPet()
    {
        PetData data = SaveSystem.LoadPet();

        food = data.food;
        happiness = data.happiness;
        energy = data.energy;
    }

    public void Initialize(int food, int happiness,int energy)
    {
        NeedsController.food = food;
        NeedsController.happiness = happiness;
        NeedsController.energy = energy;
        //PetUIController.instance.UpdateImages(food);
    }

    public void Start()
    {
        //foodBar = GetComponentInChildren<PetUIController>();
    }

    public void Update()
    {
        foodBar.UpdateFoodBar(100, food);
        happinessBar.UpdateHappinessBar(100, happiness);
        energyBar.UpdateEnergyBar(100, energy);

        if (TimingManager.gameHourTimer < 0)
        {
            //PetUIController.instance.UpdateImages(food);
        }
    }

    public void ChangeFood(int amount)
    {
        food += amount;
        
        if (food <= 0)
        {
            food = 0;
            //PetController.Sad();
        } 
        else if (food >= 100)
        {
            food = 100;
        }
        
    }

    public void ChangeHappiness(int amount)
    {
        happiness += amount;

        if (happiness <= 0)
        {
            happiness = 0;
            //PetController.Sad();
        }
        else if (happiness >= 100)
        {
            happiness = 100;
        }

    }

    public void ChangeEnergy(int amount)
    {
        energy += amount;

        if (energy <= 0)
        {
            energy = 0;
            //PetController.Sad();
        }
        else if (energy >= 100)
        {
            energy = 100;
        }

    }
}
