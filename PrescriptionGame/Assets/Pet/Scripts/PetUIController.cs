using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetUIController : MonoBehaviour
{
    public Image foodImage;

    public static PetUIController instance;

    /*private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }*/

    public void UpdateImages(int food)
    {
        //this.food = food;
        foodImage.fillAmount = (float) food / 100;
    }
}
