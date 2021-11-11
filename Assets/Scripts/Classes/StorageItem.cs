using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StorageItem", menuName = "StorageItem", order = 55)]
public class StorageItem : ScriptableObject
{
    public Sprite sprite;
    public storageType storageType;
}

public enum storageType
{
    pilot, passive, weapon
}
