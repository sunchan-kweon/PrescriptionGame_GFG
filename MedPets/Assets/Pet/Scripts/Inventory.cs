using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    //Integer values of items and their text UI
    public static int caffeine;
    public static int insulin;
    public static int metformin;
    public static int corn;
    public static int flour;

    //public TextMeshProUGUI caffeinenum;
    public TextMeshProUGUI insulinnum;
    public TextMeshProUGUI metforminnum;
    public TextMeshProUGUI cornnum;
    public TextMeshProUGUI flournum;

    //Save item data to save file
    public void SavePet()
    {
        SaveSystem.SavePet();
    }

    //Load item data from save file
    public void LoadPet()
    {
        PetData data = SaveSystem.LoadPet();

        caffeine = data.caffeine;
        insulin = data.insulin;
        metformin = data.metformin;
        corn = data.corn;
        flour = data.flour;
    }

    //Use caffeine to increase energy
    public void UseCaffeine(){
        if(caffeine > 0){
            caffeine -= 1;
            NeedsController.ChangeEnergy(10);
            SavePet();
        }
    }

    //Use insulin to decrease blood sugar
    public void UseInsulin(){
        if(insulin > 0){
            insulin -= 1;
            //NeedsController.ChangeHappiness(10);
            NeedsController.ChangeHappiness(-10);
            SavePet();
        }
    }

    //Use metformin to decrease blood sugar
    public void UseMetformin(){
        if(metformin > 0){
            metformin -= 1;
            //NeedsController.ChangeEnergy(10);
            NeedsController.ChangeHappiness(-10);
            SavePet();
        }
    }

    //Use corn to increase satiety and decrease blood sugar
    public void UseCorn(){
        if(corn > 0){
            corn -= 1;
            NeedsController.ChangeFood(10);
            NeedsController.ChangeHappiness(-10);
            SavePet();
        }
    }

    //Use flour to increase satiety and increase blood sugar
    public void UseFlour(){
        if(flour > 0){
            flour -= 1;
            NeedsController.ChangeFood(20);
            NeedsController.ChangeHappiness(10);
            SavePet();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update UI with number of items
    void Update()
    {
        //caffeinenum.text = caffeine.ToString("D2");
        insulinnum.text = insulin.ToString("D2");
        metforminnum.text = metformin.ToString("D2");
        cornnum.text = corn.ToString("D2");
        flournum.text = flour.ToString("D2");
    }
}
