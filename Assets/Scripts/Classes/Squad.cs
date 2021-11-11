using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Squad
{
    public SquadType type;
    public int price;
    public bool unlocked;
    public Color color;
    public Mech[] Mechs = new Mech[3];

    //Wins
    public bool easyWin2Islands, easyWin3Islands, easyWin4Islands;
    public bool mediumWin2Islands, mediumWin3Islands, mediumWin4Islands;
    public bool hardWin2Islands, hardWin3Islands, hard4Win4Islands;
}

public enum SquadType
{
    riftWalkers, rustingHulks, zenithGuard, blitzkrieg, steelJudoka, flameBehemoths, frozenTitans, hazardousMechs, secretSquad, random, custom
}
