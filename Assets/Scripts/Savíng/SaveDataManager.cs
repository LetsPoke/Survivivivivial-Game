using System.Collections.Generic;
using UnityEngine;

public static class SaveDataManager
{
    public static void SaveJsonData(ISaveable saveable)
    {
        SaveData sd = new SaveData();
        saveable.PopulateSaveData(sd);

        // TODO: variable file name for multiple save files
        if (FileManager.WriteToFile("SaveData.dat", sd.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }
    
    public static void LoadJsonData(ISaveable saveable)
    {
        // TODO: variable file name for multiple save files
        if (FileManager.LoadFromFile("SaveData.dat", out var json))
        {
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);

            saveable.LoadFromSaveData(sd);
            
            Debug.Log("Load complete");
        }
    }
}