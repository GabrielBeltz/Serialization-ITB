using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipable", menuName = "Equipable", order = 56)]
public class Equipable : StorageItem
{
    public bool active;
    public int power;
    public string description;
    public EquipableUpgrade upgrade1, upgrade2;
    public EquipableType equipableType;
}

[System.Serializable]
public class EquipableUpgrade
{
    public bool active;
    public UpgradeTypes type;
    public int cost;
    public string description;

    public EquipableUpgrade(UpgradeTypes type, int cost)
    {
        this.cost = cost;
        this.type = type;
    }
}

public enum EquipableType
{
    Passive, Weapon
}

public enum UpgradeTypes
{
    none, plus1Damage, plus2Damage, dash, buildingChain, allyImmune, gainShield, rocket, plus1Range, ACIDTip, minus1SelfDamage, plus1Use, phaseShield, shieldAlly, plus1MaxDamage, plus1DamageEach, buildingsImmune, backburn, noSelfDamage, shieldSelf, plus3Area, plus1Size, unlimitedUse, projectile, push, flying, smokeBehind, rangeAndDamage, plus1Tile
}
