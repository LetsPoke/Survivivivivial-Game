using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SaveManager : MonoBehaviour, ISaveable
{
    public GameObject world;
    public GameObject player;

    private int saveStateNumber = 1;
    private long counter = 0;
    private bool startBool;

    private void Start()
    {
        var t = PlayerPrefs.GetInt("currentSave");
        if (t>= 1 && t<=3)
        {
            saveStateNumber = PlayerPrefs.GetInt("currentSave");
        }

        bool[] files = SaveDataManager.ExistingFiles();
        for (var i=0; i<files.Length;i++)
        {
            if (!files[i])
            {
                SaveProgress((i+1));
            }
        }

        startBool = true;
        LoadProgress(saveStateNumber);
        startBool = false;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("currentSave", saveStateNumber);
        SaveProgress(saveStateNumber);
    }

    public void LoadProgress(int save)
    {
        if (!startBool)
        {
            SaveProgress(saveStateNumber);
        }
        saveStateNumber = save;
        SaveDataManager.LoadJsonData(this, saveStateNumber.ToString());
    }

    public void SaveProgress(int save)
    {
        saveStateNumber = save;
        SaveDataManager.SaveJsonData(this, saveStateNumber.ToString());
    }

    private void FixedUpdate()
    {
        if (counter >= 60000)
        {
            counter = 0;
            SaveProgress(saveStateNumber);
        }
        else
        {
            counter++;
        }
    }

    public void TestReset()
    {
        PlayerPrefs.SetInt("currentSave", 1);
    }

    public void PopulateSaveData(SaveData saveData)
    {
        string datetime = DateTime.Now.ToString("yyyy-MM-dd\\ HH:mm:ss");
        saveData.dateTime = datetime;

        SaveData.InGameObject pInGameObject = new SaveData.InGameObject();
        pInGameObject.name = player.name;
        pInGameObject.position = player.transform.position;
        pInGameObject.rotation = player.transform.rotation;
        pInGameObject.isActive = player.activeSelf;
        saveData.player = pInGameObject;

        List<SaveData.InGameObject> trees = new List<SaveData.InGameObject>(),
            rocks = new List<SaveData.InGameObject>(),
            terrain = new List<SaveData.InGameObject>(),
            smallObjects = new List<SaveData.InGameObject>();
        for (int i = 0; i < world.transform.childCount; i++)
        {
            for (int j = 0; j < world.transform.GetChild(i).childCount; j++)
            {
                var obj = world.transform.GetChild(i).GetChild(j).transform;
                var o = obj.gameObject;
                SaveData.InGameObject ig = new SaveData.InGameObject
                {
                    name = o.name, position = obj.position, rotation = obj.rotation, isActive = o.activeSelf
                };

                switch (obj.parent.name)
                {
                    case "Trees":
                        trees.Add(ig);
                        break;
                    case "Rocks":
                        rocks.Add(ig);
                        break;
                    case "SmallObjects":
                        smallObjects.Add(ig);
                        break;
                    case "Terrain":
                        terrain.Add(ig);
                        break;
                }
            }
        }

        saveData.trees = trees;
        saveData.rocks = rocks;
        saveData.terrain = terrain;
        saveData.smallObjects = smallObjects;
    }

    public void LoadFromSaveData(SaveData saveData)
    {
        SaveData.InGameObject t = saveData.player;
        player.transform.position = t.position;
        player.transform.rotation = t.rotation;
        player.SetActive(t.isActive);
        
        for (int i = 0; i < world.transform.childCount; i++)
        {
            for (int j = 0; j < world.transform.GetChild(i).childCount; j++)
            {
                var obj = world.transform.GetChild(i).GetChild(j).transform;
                SaveData.InGameObject temp = new SaveData.InGameObject();

                switch (obj.parent.name)
                {
                    case "Trees":
                        temp = saveData.trees[j];
                        break;
                    case "Rocks":
                        temp = saveData.rocks[j];
                        break;
                    case "SmallObjects":
                        temp = saveData.smallObjects[j];
                        break;
                    case "Terrain":
                        temp = saveData.terrain[j];
                        break;
                }

                obj.position = temp.position;
                obj.rotation = temp.rotation;
                obj.gameObject.SetActive(temp.isActive);
            }
        }
    }
}