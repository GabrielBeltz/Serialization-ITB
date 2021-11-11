using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mech
{
    public string name;
    public MechCategory category;
    public int baseHP, baseMove, extraHP, extraMove;
    public bool fireImmunity;
    public Equipable[] mechEquip = new Equipable[2];
    public Pilot pilot;
}

public enum MechCategory
{
    Brute, Cyborg, Prime, Ranged, Science
}
