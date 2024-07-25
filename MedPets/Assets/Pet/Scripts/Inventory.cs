using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static int[] items;
    private bool started = false;


    private void Start()
    {
        if(started == false)
        {
            items = new int[BerryHolder.itemCount];
            started = true;
        }
    }

    public static void SavePet()
    {
        SaveSystem.SavePet();
    }

    public static void LoadPet()
    {
        PetData data = SaveSystem.LoadPet();

        for(int i = 0; i < items.Length;)
        {
            items[i] = data.items[i];
        }
    }
    
    /*

    public void UseInsulin(){
        if(insulin > 0){
            insulin -= 1;
            //NeedsController.ChangeHappiness(10);
            NeedsController.ChangeBlood(-10);
            SavePet();
        }
    }

    public void UseMetformin(){
        if(metformin > 0){
            metformin -= 1;
            //NeedsController.ChangeEnergy(10);
            NeedsController.ChangeBlood(-10);
            SavePet();
        }
    }

    public void UseCorn(){
        if(corn > 0){
            corn -= 1;
            NeedsController.ChangeFood(10);
            NeedsController.ChangeBlood(-10);
            SavePet();
        }
    }

    public void UseFlour(){
        if(flour > 0){
            flour -= 1;
            NeedsController.ChangeFood(20);
            NeedsController.ChangeBlood(10);
            SavePet();
        }
    }
    */
}
