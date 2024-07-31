using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetUIController : MonoBehaviour
{
    public Image foodImage;
    public Slider bloodSliderImage;
    public Image energyImage;

    public void UpdateFoodBar(float maxFood, float currentFood)
    {
        float result = currentFood / maxFood;
        if(foodImage.fillAmount < result)
        {
            foodImage.fillAmount += 0.045f / maxFood;
        }
        else if (foodImage.fillAmount > result)
        {
            foodImage.fillAmount -= 0.045f / maxFood;
        }
    }

    public void UpdateBloodBar(float currentBlood)
    {
        float result = currentBlood;
        if (bloodSliderImage.value < result)
        {
            bloodSliderImage.value += 0.1f;
        }
        else if (bloodSliderImage.value > result)
        {
            bloodSliderImage.value -= 0.1f;
        }
    }

    public void UpdateEnergyBar(float maxEnergy, float currentEnergy)
    {
        float result = currentEnergy / maxEnergy;
        if(energyImage.fillAmount < result)
        {
            energyImage.fillAmount += 0.045f / maxEnergy;
        }
        else if (energyImage.fillAmount > result)
        {
            energyImage.fillAmount -= 0.045f / maxEnergy;
        }
    }
}
