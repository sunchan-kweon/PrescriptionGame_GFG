using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    //Status of pet
    public static int food;
    public static int happiness;
    public static int energy;
    public static bool playedOnce;

    //UI reference to status
    public PetUIController foodBar;
    public PetUIController happinessBar;
    public PetUIController energyBar;

    //Save pet data to save file
    public void SavePet()
    {
        SaveSystem.SavePet();
    }

    //Load pet data to save file
    public void LoadPet()
    {
        PetData data = SaveSystem.LoadPet();

        food = data.food;
        happiness = data.happiness;
        energy = data.energy;
    }

    public void Start()
    {
         
    }

    //Update UI corresponding to pet status
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

    //Change satiety level based on actions taken (item, playing)
    public static void ChangeFood(int amount)
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

    //Change blood sugar level based on actions taken (item, playing)
    public static void ChangeHappiness(int amount)
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

    //Change energy level based on actions taken (item, playing)
    public static void ChangeEnergy(int amount)
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
