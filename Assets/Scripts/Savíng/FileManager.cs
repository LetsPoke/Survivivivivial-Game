using System;
using System.Collections;
using System.IO;
using UnityEngine;

public static class FileManager
{
    public static bool WriteToFile(string fileName, string fileContents)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            File.WriteAllText(fullPath, fileContents);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
            return false;
        }
    }

    public static bool LoadFromFile(string fileName, out string result)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            result = File.ReadAllText(fullPath);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to read from {fullPath} with exception {e}");
            result = "";
            return false;
        }
    }

    public static bool[] CheckForSaveFiles()
    {
        var fullPath = Application.persistentDataPath;
        try
        {
            bool[] existingFiles = new bool[]{false, false, false};
            if (File.Exists(Path.Combine(Application.persistentDataPath, "SaveData1.dat")))
            {
                existingFiles[0] = true;
            }
            if (File.Exists(Path.Combine(Application.persistentDataPath, "SaveData2.dat")))
            {
                existingFiles[1] = true;
            }
            if (File.Exists(Path.Combine(Application.persistentDataPath, "SaveData3.dat")))
            {
                existingFiles[2] = true;
            }

            return existingFiles;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed with exception {e}");
            throw;
        }
    }
}