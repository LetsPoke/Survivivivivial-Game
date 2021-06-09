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

    private void HandleSaveData(SaveData sd)
    {
        SaveData.InGameObject pInGameObject = new SaveData.InGameObject();
        pInGameObject.name = player.name;
        pInGameObject.position = player.transform;
        pInGameObject.isActive = player.activeSelf;
        sd.player = pInGameObject;

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
                    name = o.name, position = obj, isActive = o.activeSelf
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

        sd.objects.Clear();
        sd.objects.Add(trees);
        sd.objects.Add(rocks);
        sd.objects.Add(terrain);
        sd.objects.Add(smallObjects);
    }

    public void PopulateSaveData(SaveData saveData)
    {
        HandleSaveData(saveData);
    }

    public void LoadFromSaveData(SaveData saveData)
    {
        throw new System.NotImplementedException();
    }
}