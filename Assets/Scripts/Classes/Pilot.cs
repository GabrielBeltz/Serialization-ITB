using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Pilot", menuName = "Pilot", order = 54)]
public class Pilot : StorageItem
{
    public int totalXP;
    public pilotLevelUpSkills pilotLevelUp1, pilotLevelUp2;
    public PilotSpecialSkills specialSkill;
    // Infos que vão sendo coletadas em runs e adicionadas ao save
    public TimeTravellerSavedInfo savedInfo;
}

public enum pilotLevelUpSkills
{
    none, gridDef, hp, move, reactor
}

public enum PilotSpecialSkills
{
    noSkill, experienced, frenziedRepair, armored, startingShield, maneuverable, preemptiveStrike, flying, impulsive, sidestep, evasion, temporalReset, doubleShot, fireAndForget, mantis, zoltan, rockman
}

[System.Serializable]
public class TimeTravellerSavedInfo
{
    public string baseName;
    public bool unlocked;
    public int battles, timeJumps, totalKills, totalDeaths;
}