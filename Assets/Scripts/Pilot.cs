using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : StorageItem
{
    public int totalXP;
    public pilotLevelUpSkills pilotLevelUp1, pilotLevelUp2;
    public PilotSpecialSkills specialSkill;
}

public enum pilotLevelUpSkills
{
    none, gridDef, hp, move, reactor
}

public enum PilotSpecialSkills
{
    noSkill, experienced, frenziedRepair, armored, startingShield, maneuverable, preemptiveStrike, flying, impulsive, sidestep, evasion, temporalReset, doubleShot, fireAndForget, mantis, zoltan, rockman
}