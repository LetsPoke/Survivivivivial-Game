using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

// This script is part of the "Persistent Data - How to Save Your Game States and Settings"
// by UnityNow at this website:
// https://resources.unity.com/unitenow/onlinesessions/persistent-data-how-to-save-your-game-states-and-settings
// (alternative video link: https://youtu.be/uD7y4T4PVk0)

public class SaveManager : MonoBehaviour, ISaveable
{
    public GameObject world;
    public GameObject player;
    public InventoryObject invObj;

    private int saveStateNumber = 1;
    private long counter = 0;
    private bool startBool;
    private PlayerManager playerMan;

    private Transform[] worldObjects;

    private void Start()
    {
        playerMan = GetComponent<PlayerManager>();
        worldObjects = world.GetComponentsInChildren<Transform>();

        var t = PlayerPrefs.GetInt("currentSave");
        if (t >= 1 && t <= 3)
        {
            saveStateNumber = PlayerPrefs.GetInt("currentSave");
        }

        bool[] files = SaveDataManager.ExistingFiles();
        for (var i = 0; i < files.Length; i++)
        {
            if (!files[i])
            {
                SaveProgress((i + 1));
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

    public void PopulateSaveData(SaveData saveData)
    {
        var p = new List<Vector3>();
        var a = new List<bool>();
        var q = new List<Quaternion>();
        foreach (var t in worldObjects)
        {
            p.Add(t.position);
            a.Add(t.gameObject.activeSelf);
            q.Add(t.rotation);
        }

        saveData.positionOfWorldObjects = p;
        saveData.rotationOfWorldObjects = q;
        saveData.selfActiveOfWorldObjects = a;

        saveData.playerPos = player.transform.position;
        saveData.playerRot = player.transform.rotation;

        var il = new List<ItemObject>();
        var al = new List<int>();
        for (int i = 0; i < invObj.Container.Count; i++)
        {
            il.Add(invObj.Container[i].item);
            al.Add(invObj.Container[i].amount);
        }

        saveData.items = il;
        saveData.amount = al;

        saveData.playerHealth = playerMan.health;
        saveData.playerHunger = playerMan.hunger;
        saveData.playerThirst = playerMan.thirst;
        
        invObj.Container.Clear();
    }

    public void LoadFromSaveData(SaveData saveData)
    {
        invObj.Container.Clear();
        
        playerMan.health = saveData.playerHealth;
        playerMan.hunger = saveData.playerHunger;
        playerMan.thirst = saveData.playerThirst;
        
        var p = saveData.positionOfWorldObjects;
        var a = saveData.selfActiveOfWorldObjects;
        var q = saveData.rotationOfWorldObjects;

        for (int i = 0; i < worldObjects.Length; i++)
        {
            worldObjects[i].position = p[i];
            worldObjects[i].rotation = q[i];
            worldObjects[i].gameObject.SetActive(a[i]);
        }

        player.transform.position = saveData.playerPos;
        player.transform.rotation = saveData.playerRot;

        for (int i = 0; i < saveData.items.Count; i++)
        {
            invObj.Container.Add(new InventorySlot(saveData.items[i], saveData.amount[i]));
        }
    }
}