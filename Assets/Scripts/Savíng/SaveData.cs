using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class SaveData
{
    [System.Serializable]
    public struct InGameObject
    {
        public string name; //maybe replace with UUID or other ways to precisely determine which GameObject is meant
        public Vector3 position;
        public Quaternion rotation;
        public bool isActive;
    }

    public InGameObject player;
    public List<InGameObject> trees = new List<InGameObject>();
    public List<InGameObject> rocks = new List<InGameObject>();
    public List<InGameObject> terrain = new List<InGameObject>();
    public List<InGameObject> smallObjects = new List<InGameObject>();
    public string dateTime;

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
