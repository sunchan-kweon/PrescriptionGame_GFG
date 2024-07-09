using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static int caffeine;
    public static int insulin;
    public static int metformin;

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
            NeedsController.ChangeHappiness(10);
            SavePet();
        }
    }

    public void UseMetformin(){
        if(metformin > 0){
            metformin -= 1;
            NeedsController.ChangeFood(10);
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
        
    }
}
