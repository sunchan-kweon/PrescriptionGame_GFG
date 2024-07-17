using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public static int food;
    public static int blood;
    public static int energy;
    public static bool playedOnce;

    public PetUIController foodBar;
    public PetUIController bloodBar;
    public PetUIController energyBar;

    public PetController controller;

    public void SavePet()
    {
        SaveSystem.SavePet();
    }

    public void LoadPet()
    {
        PetData data = SaveSystem.LoadPet();

        food = data.food;
        blood = data.blood;
        energy = data.energy;
    }

    public void Update()
    {
        foodBar.UpdateFoodBar(100, food);
        bloodBar.UpdateBloodBar(blood);
        energyBar.UpdateEnergyBar(100, energy);

        if (TimingManager.gameHourTimer < 0)
        {
            //PetUIController.instance.UpdateImages(food);
        }

        if (food <= 20)
        {
            controller.Hungry();
        }

        if(blood < 80)
        {
            controller.Sad();
        }
        else if(blood > 140)
        {
            controller.Sad();
        }

        if(energy <= 20)
        {
            controller.Bored();
        }

        if(food >= 80 && blood > 80 && blood < 140 && energy >= 80)
        {
            controller.Happy();
        }
    }

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

    public static void ChangeBlood(int amount)
    {
        blood += amount;

        if (blood <= 0)
        {
            blood = 0;
            //PetController.Sad();
        }
        else if (blood >= 100)
        {
            blood = 100;
        }

    }

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
