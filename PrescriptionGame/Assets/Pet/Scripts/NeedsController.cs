using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsController : MonoBehaviour
{

    public int food;
    public int foodTickRate;
    
    public void Initialize(int food, int foodTickRate)
    {
        this.food = food;
        this.foodTickRate = foodTickRate;
        PetUIController.instance.UpdateImages(food);
    }

    // Update is called once per frame
    void Update()
    {
        if(TimingManager.gameHourTimer < 0)
        {
            ChangeFood(-foodTickRate);
            PetUIController.instance.UpdateImages(food);
        }
    }

    public void ChangeFood(int amount)
    {
        food += amount;
        if(food < 10)
        {
            //PetController.Sad();
        } 
        else if (food > 100)
        {
            food = 100;
        }
    }
}
