using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Damage
{
    public int value;
    public DamageType type;

    public Damage(int value, DamageType type)
    {
        this.value = value;
        this.type = type;
    }
}

public enum DamageType
{
    untyped, fire, acid, explosive
}
