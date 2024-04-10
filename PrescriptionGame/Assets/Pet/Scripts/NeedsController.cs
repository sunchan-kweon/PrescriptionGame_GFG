using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public static int food;
    public int foodTickRate;

    public static int happiness;
    public int happinessTickRate;

    public static int energy;
    public int energyTickRate;

    public static bool firstTimePlaying = true;

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

    public void Initialize(int food, int foodTickRate, int happiness, int happinessTickRate, int energy, int energyTickRate)
    {
        NeedsController.food = food;
        this.foodTickRate = foodTickRate;
        NeedsController.happiness = happiness;
        this.happinessTickRate = happinessTickRate;
        NeedsController.energy = energy;
        this.energyTickRate = energyTickRate;
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
        //Debug.Log(food);
        if (TimingManager.gameHourTimer < 0)
        {
            ChangeFood(-foodTickRate);
            ChangeHappiness(-happinessTickRate);
            ChangeEnergy(-energyTickRate);
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
