using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //Save inventory data in a save file and change it to binary format
    public static void SavePet()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/pet.exe";
        FileStream stream = new FileStream(path, FileMode.Create);

        PetData data = new PetData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    //Load inventory data if save file exists, change format back to normal format
    public static PetData LoadPet(){
        string path = Application.persistentDataPath + "/pet.exe";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PetData data = formatter.Deserialize(stream) as PetData;
            stream.Close();

            return data;
        }
        else{
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
