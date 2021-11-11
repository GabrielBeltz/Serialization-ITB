using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 52)]
[System.Serializable]
public class Weapon : Usable
{
    public Damage damage;
    public WeaponType type;
}

public enum WeaponType
{
    TitanFist, ElectricWhip, BurstBeam, SpartanShield, RockLauncher, SidewinderFist, RocketFist, ViceFist, FlameThrower, ExplosiveVents, PrimeSpear, HydraulicLegs, VortexFist, TitaniteBlade, MercuryFist, TaurusCannon, AerialBombs, JanusCannon, PhaseCannon, GrapplingHook, DefShrapnel, RailCannon, ShockCannon, RammingEngines, UnstableCannon, HeavyRocket, ShrapnelCannon, AstraBombs, HermesEngines, ArtemisArtillery, RockAccelerator, ClusterArtillery, RocketArtillery, VulcanArtillery, MicroArtillery, ArgonMortar, CryoLauncher, SmokeMortar, BurningMortar, RammingDeath, HeavyArtillery, GeminiMissiles, AttractionPulse, GravWell, Repulse, Teleporter, AcidProjector, ConfuseShot, SmokePellets, ShieldProjector, FireBeam, FrostBeam, ShieldArray, PushBeam, Boosters, SmokeBombs, HeatConverter, SelfDestruct, TargetedStrike, SmokeDrop, RepairDrop, MissileBarrage, WindTorrent, IceGenerator, LightTank, ShieldTank, AcidTank, PullTank, RammingSpeed, NeedleShot, ExplosiveGoo
}