using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

// This script is part of the "Persistent Data - How to Save Your Game States and Settings"
// by UnityNow at this website:
// https://resources.unity.com/unitenow/onlinesessions/persistent-data-how-to-save-your-game-states-and-settings
// (alternative video link: https://youtu.be/uD7y4T4PVk0)

[System.Serializable]
public class SaveData
{
    public List<Vector3> positionOfWorldObjects;
    public List<Quaternion> rotationOfWorldObjects;
    public List<bool> selfActiveOfWorldObjects;

    public Vector3 playerPos;
    public Quaternion playerRot;
    public float playerHealth;
    public float playerHunger;
    public float playerThirst;

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
