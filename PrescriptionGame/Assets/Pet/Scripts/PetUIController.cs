using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetUIController : MonoBehaviour
{
    public Image foodImage;

    private void Start()
    {
        foodImage = GetComponent<Image>();
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
        foodImage.fillAmount = currentFood / maxFood;
    }
}
