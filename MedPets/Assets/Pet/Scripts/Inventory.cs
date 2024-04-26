using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
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

    public void SavePet()
    {
        SaveSystem.SavePet();
    }

    public void LoadPet()
    {
        PetData data = SaveSystem.LoadPet();

        caffeine = data.caffeine;
        insulin = data.insulin;
        metformin = data.metformin;
        corn = data.corn;
        flour = data.flour;
    }

    public void UseCaffeine(){
        if(caffeine > 0){
            caffeine -= 1;
            NeedsController.ChangeEnergy(10);
            SavePet();
        }
    }

    public void UseInsulin(){
        if(insulin > 0){
            insulin -= 1;
            //NeedsController.ChangeHappiness(10);
            NeedsController.ChangeHappiness(-10);
            SavePet();
        }
    }

    public void UseMetformin(){
        if(metformin > 0){
            metformin -= 1;
            //NeedsController.ChangeEnergy(10);
            NeedsController.ChangeHappiness(-10);
            SavePet();
        }
    }

    public void UseCorn(){
        if(corn > 0){
            corn -= 1;
            NeedsController.ChangeFood(10);
            NeedsController.ChangeHappiness(-10);
            SavePet();
        }
    }

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

    // Update is called once per frame
    void Update()
    {
        //caffeinenum.text = caffeine.ToString("D2");
        insulinnum.text = insulin.ToString("D2");
        metforminnum.text = metformin.ToString("D2");
        cornnum.text = corn.ToString("D2");
        flournum.text = flour.ToString("D2");
    }
}
