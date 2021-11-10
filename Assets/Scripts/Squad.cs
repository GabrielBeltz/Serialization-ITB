using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad
{
    public SquadType type;
    public int price;
    public bool unlocked;
    public Color color;
    public Mech[] Mechs = new Mech[3];

    //Wins
    public bool easyWin2Islands, easyWin3Islands, easy4WinIslands;
    public bool mediumWin2Islands, mediumWin3Islands, medium4WinIslands;
    public bool hardWin2Islands, hardWin3Islands, hard4WinIslands;
}

public enum SquadType
{
    riftWalkers, rustingHulks, zenithGuard, blitzkrieg, steelJudoka, flameBehemoths, frozenTitans, hazardousMechs, secretSquad, random, custom
}
