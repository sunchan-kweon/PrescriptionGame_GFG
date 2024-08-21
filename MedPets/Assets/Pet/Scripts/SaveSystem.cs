using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePet()
    {
        PlayerPrefs.SetFloat("Blood", NeedsController.blood);
        PlayerPrefs.SetFloat("Food", NeedsController.food);
        PlayerPrefs.SetFloat("Energy", NeedsController.energy);
        for(int i = 0; i < Inventory.items.Length; i++)
        {
            PlayerPrefs.SetInt("Item" + i, Inventory.items[i]);
        }
        PlayerPrefs.SetInt("Progression", Progression.progressionCounter);
        SetBool("PetVisited", NeedsController.playedOnce);
        PlayerPrefs.SetString("PetName", PatientInfo.petName);
        PlayerPrefs.Save();
    }

    public static void LoadPet()
    {
        NeedsController.blood = PlayerPrefs.GetFloat("Blood", NeedsController.blood);
        NeedsController.food = PlayerPrefs.GetFloat("Food", NeedsController.food);
        NeedsController.energy = PlayerPrefs.GetFloat("Energy", NeedsController.energy);
        for (int i = 0; i < Inventory.items.Length; i++)
        {
            Inventory.items[i] = PlayerPrefs.GetInt("Item" + i, 0);
        }
        Progression.progressionCounter = PlayerPrefs.GetInt("Progression", Progression.progressionCounter);
        NeedsController.playedOnce = GetBool("PetVisited", NeedsController.playedOnce);
        PatientInfo.petName = PlayerPrefs.GetString("PetName", PatientInfo.petName);
    }

    private static void SetBool(string name, bool value)
    {
        if (value)
        {
            PlayerPrefs.SetInt(name, 1);
        }
        else
        {
            PlayerPrefs.SetInt(name, 0);
        }
    }

    private static bool GetBool(string name, bool dflt)
    {
        if (PlayerPrefs.GetInt(name, 0) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
