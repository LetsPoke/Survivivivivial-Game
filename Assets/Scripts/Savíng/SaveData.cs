using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    [System.Serializable]
    public struct InGameObject
    {
        public string name; //maybe replace with UUID or other ways to precisely determine which GameObject is meant
        public Transform position;
        public bool isActive;
    }

    public InGameObject player;
    public HashSet<List<InGameObject>> objects = new HashSet<List<InGameObject>>();

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
}

public interface ISaveable
{
    void PopulateSaveData(SaveData saveData);
    void LoadFromSaveData(SaveData saveData);
}
