using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetUIController : MonoBehaviour
{
    public Image foodImage;
    public Image happinessImage;
    public Image energyImage;

    private void Start()
    {
        
    }

    //public static PetUIController instance;

    /*private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }*/

    public void UpdateFoodBar(float maxFood, float currentFood)
    {
        //Debug.Log(currentFood / maxFood);
        foodImage.fillAmount = currentFood / maxFood;
    }

    public void UpdateHappinessBar(float maxHappiness, float currentHappiness)
    {
        //Debug.Log(currentHappiness / maxHappiness);
        happinessImage.fillAmount = currentHappiness / maxHappiness;
    }

    public void UpdateEnergyBar(float maxEnergy, float currentEnergy)
    {
        //Debug.Log(currentEnergy / maxEnergy);
        energyImage.fillAmount = currentEnergy / maxEnergy;
    }
}
