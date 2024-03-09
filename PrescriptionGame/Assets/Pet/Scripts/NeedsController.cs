using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsController : MonoBehaviour
{

    public int food;
    public int foodTickRate;
    
    public void Initialize(int food)
    {
        this.food = food;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimingManager.gameHourTimer < 0)
        {
            ChangeFood(-foodTickRate);
        }
    }

    public void ChangeFood(int amount)
    {
        food += amount;
    }
}
