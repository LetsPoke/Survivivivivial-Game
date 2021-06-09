using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour, ISaveable
{
    public GameObject world;
    public GameObject player;
    
    private void Start()
    {
        SaveDataManager.LoadJsonData(this);
    }

    private void OnApplicationQuit()
    {
        SaveDataManager.SaveJsonData(this);
    }

    public void PopulateSaveData(SaveData saveData)
    {
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