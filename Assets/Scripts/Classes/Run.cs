using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Run", menuName = "Run", order = 51)]
public class Run : ScriptableObject
{
    [Header("Run-Specific Stats")]
    public Squad selectedSquad;
    public List<StorageItem> inventory = new List<StorageItem>();
    public int savedPeople;
    public int gridPower, reputation, reactor, coins;
    [Header("All time Stats")]
    public int win2Islands;
    public int win3Islands, win4Islands, timelinesLost, totalGames, totalTimeTravelers, totalEnemiesKilled, totalSavedCivilians, totalIslandsSecured, podsCollected;
    [Header("Time travellers Info")]
    public TimeTravellerSavedInfo[] timeTravellers;
    [Header("Squads Info")]
    public SquadSavedInfo[] squads;
    [Header("Rift Walkers Achievements")]
    public bool wateryGrave;
    public bool rammingSpeed, islandSecure;
    [Header("Zenith Guard Achievements")]
    public bool getOverHere;
    public bool glitteringCBeam, shieldMastery;
    [Header("Steel Judoka Achievements")]
    public bool unbreakable;
    public bool unwittingAllies, massDisplacement;
    [Header("Frozen Titans Achievements")]
    public bool cryoExpert;
    public bool trickShot, pacifist;
    [Header("Rusting Hulks Achievements")]
    public bool overpowered;
    public bool stormyWeather, perfectBattle;
    [Header("Blitzkrieg Achievements")]
    public bool chainAttack;
    public bool lightningWar, holdTheLine;
    [Header("Flame Behemoths Achievements")]
    public bool quantumEntanglement;
    public bool scorchedEarth, thisIsFine;
    [Header("Hazardous Mechs Achievements")]
    public bool healing;
    public bool immortal, overkill;
    [Header("Randomized Squad Achievements")]
    public bool lootBoxes;
    public bool luckyStart, changeTheOdds;
    [Header("Customized Squad Achievements")]
    public bool mechSpecialist;
    public bool classSpecialist, flightSpecialist;
    [Header("Victories Achievements")]
    public bool victory;
    public bool hardVictory, adaptableVictory, squadsVictory, completeVictory;
    [Header("Metagame Achievements")]
    public bool emergingTechnologies;
    public int reputationSpent, blockedVek, perfectIslands;
    public bool friendsInHighPlaces, immovableObjects, hummanitysSavior, perfectStrategy;
    [Header("Island Challenges Achievements")]
    public bool perfectIsland;
    public bool theDefenders, untouchable, backupBatteries, goodSamaritan;
    [Header("Pilot Challenges Achievements")]
    public bool fieldPromotion;
    public bool bestOfTheBest, comeTogether, imGettingTooOldForThis, distantFriends;
    [Header("Challenge Runs Achievements")]
    public bool sustainableEnergy;
    public bool engeneeringDropout, chronophobia, thereIsNoTry, trustedEquipment;
}
