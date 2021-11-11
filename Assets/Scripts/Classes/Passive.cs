using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Passive", menuName = "Passive", order = 53)]
public class Passive : Equipable
{
    public PassiveAbility ability;
}

public enum PassiveAbility
{
    flameShielding, stormGenerator, visceraNanobots, networkedArmor, repairField, autoShields, stabilizers, kickoffBoosters, medicalSupplies, vekHormones, forceAmp, ammoGenerator, criticalShields, forestryNano
}
