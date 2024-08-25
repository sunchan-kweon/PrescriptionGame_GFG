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
        for (int i = 0; i < PatientInfo.medications.Count; i++)
        {
            PlayerPrefs.SetInt("Med" + i, PatientInfo.medications[i]);
        }
        PlayerPrefs.SetInt("MedAmount", PatientInfo.medications.Count);
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
        int medAmount = PlayerPrefs.GetInt("MedAmount", 0);
        Progression.progressionCounter = PlayerPrefs.GetInt("Progression", Progression.progressionCounter);
        NeedsController.playedOnce = GetBool("PetVisited", NeedsController.playedOnce);
        PatientInfo.petName = PlayerPrefs.GetString("PetName", PatientInfo.petName);
        for (int i = 0; i < medAmount; i++)
        {
            Debug.Log("Before Med" + i + " " + PlayerPrefs.GetInt("Med" + i, 0));
            PatientInfo.addMedication(PlayerPrefs.GetInt("Med" + i, 0));
            Debug.Log("After Med");
        }
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
