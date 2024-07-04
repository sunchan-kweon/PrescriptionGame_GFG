using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetUIController : MonoBehaviour
{
    public Image foodImage;
    public Slider bloodSliderImage;
    public Image energyImage;

    public float maxSlider;
    public float minSlider;

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

    public void UpdateBloodBar(float currentBlood)
    {
        //Debug.Log(currentHappiness / maxHappiness);
        bloodSliderImage.value = currentBlood;
    }

    public void UpdateEnergyBar(float maxEnergy, float currentEnergy)
    {
        //Debug.Log(currentEnergy / maxEnergy);
        energyImage.fillAmount = currentEnergy / maxEnergy;
    }
}
