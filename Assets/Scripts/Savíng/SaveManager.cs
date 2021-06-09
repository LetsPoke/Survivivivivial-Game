using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour, ISaveable
{
    public GameObject world;
    public GameObject player;

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
        foreach (var obj in world.GetComponentsInChildren<GameObject>())
        {
            SaveData.InGameObject ig = new SaveData.InGameObject();
            ig.name = obj.name;
            ig.position = obj.transform;
            ig.isActive = obj.activeSelf;
            
            switch (obj.transform.parent.name)
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
