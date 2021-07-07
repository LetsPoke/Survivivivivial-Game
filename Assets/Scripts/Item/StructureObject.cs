using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Structure Object", menuName = "Inventory System/Items/Structure")]
public class StructureObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Structure;
    }
}
