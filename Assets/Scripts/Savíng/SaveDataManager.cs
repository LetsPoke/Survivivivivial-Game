using System.Collections.Generic;
using UnityEngine;

public static class SaveDataManager
{
    public static void SaveJsonData(ISaveable saveable)
    {
        SaveData sd = new SaveData();
        saveable.PopulateSaveData(sd);

        if (FileManager.WriteToFile("SaveData01.dat", sd.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }
    
    public static void LoadJsonData(ISaveable saveable)
    {
        if (FileManager.LoadFromFile("SaveData01.dat", out var json))
        {
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);

            saveable.LoadFromSaveData(sd);
            
            Debug.Log("Load complete");
        }
    }
}