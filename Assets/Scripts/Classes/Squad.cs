using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Squad
{
    public SquadSavedInfo savingInfo;
    public Color color;
    public Mech[] Mechs = new Mech[3];
}

[System.Serializable]
public class SquadSavedInfo
{
    public SquadType baseType;
    // Além de salvar o preço, dá pra setar isso pra 0 no save e subentender q o squad está unlocked
    public int price;
    public int totalGames, score, totalKills;
    //Wins
    public bool easyWin2Islands, easyWin3Islands, easyWin4Islands;
    public bool mediumWin2Islands, mediumWin3Islands, mediumWin4Islands;
    public bool hardWin2Islands, hardWin3Islands, hardWin4Islands;
    public int win2Islands, win3Islands, win4Islands;
}

public enum SquadType
{
    riftWalkers, rustingHulks, zenithGuard, blitzkrieg, steelJudoka, flameBehemoths, frozenTitans, hazardousMechs, secretSquad, random, custom
}
