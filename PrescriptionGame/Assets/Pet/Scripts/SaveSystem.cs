using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePet(NeedsController pet)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/pet.exe";
        FileStream stream = new FileStream(path, FileMode.Create);

        PetData data = new PetData(pet);

        formatter.Serialize(stream, data);
        stream.Close();
    }

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
