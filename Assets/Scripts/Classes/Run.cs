using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Run", menuName = "Run", order = 51)]
public class Run : ScriptableObject
{
    public Squad selectedSquad;
    public List<StorageItem> inventory = new List<StorageItem>();

    public int savedPeople, gridPower, reputation, reactor, coins;
}
