using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class SaveData
{
    public List<Vector3> positionOfWorldObjects;
    public List<Quaternion> rotationOfWorldObjects;
    public List<bool> selfActiveOfWorldObjects;

    public Vector3 playerPos;
    public Quaternion playerRot;

    public List<ItemObject> items;
    public List<int> amount;

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
