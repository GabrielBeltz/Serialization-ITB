using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipable : StorageItem
{
    public int power;
    public EquipableUpgrade upgrade1, upgrade2;
}

public class EquipableUpgrade
{
    public UpgradeTypes type;
    public int cost;
}

public enum UpgradeTypes
{
    none, plus1Damage, plus2Damage, dash, buildingChain, allyImmune, gainShield, rocket, plus1Range, ACIDTip, minus1SelfDamage, plus1Use, phaseShield, shieldAlly, plus1MaxDamage, plus1DamageEach, buildingsImmune, backburn, noSelfDamage, shieldSelf, plus3Area, plus1Size, unlimitedUse, projectile, push, flying, smokeBehind, rangeAndDamage, plus1Tile
}
