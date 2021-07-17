using System.Collections.Generic;
using UnityEngine;

// This script is part of the "Persistent Data - How to Save Your Game States and Settings"
// by UnityNow at this website:
// https://resources.unity.com/unitenow/onlinesessions/persistent-data-how-to-save-your-game-states-and-settings
// (alternative video link: https://youtu.be/uD7y4T4PVk0)

public static class SaveDataManager
{
    public static void SaveJsonData(ISaveable saveable, string fileNumber)
    {
        SaveData sd = new SaveData();
        saveable.PopulateSaveData(sd);

        // TODO: variable file name for multiple save files
        if (FileManager.WriteToFile("SaveData"+fileNumber+".dat", sd.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }
    
    public static void LoadJsonData(ISaveable saveable, string fileNumber)
    {
        // TODO: variable file name for multiple save files
        if (FileManager.LoadFromFile("SaveData"+fileNumber+".dat", out var json))
        {
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);

            saveable.LoadFromSaveData(sd);
            
            Debug.Log("Load complete");
        }
    }

    public static bool[] ExistingFiles()
    {
        return FileManager.CheckForSaveFiles();
    }
}