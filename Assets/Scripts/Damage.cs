using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public int value;
    public DamageType type;
}

public enum DamageType
{
    untyped, fire, acid, explosive
}
