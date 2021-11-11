using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class JsonWorker : MonoBehaviour
{
    public GameInfoSetter gameInfo;
    public Run save;
    [Header("Squad")]
    public Equipable[] equipped;
    public Pilot[] equippedPilots;
    public Weapon[] equippedWeapons;
    public Passive[] equippedPassives;
    [Header("Inventory")]
    public StorageItem[] storageItems;
    public Pilot[] storagePilots;
    public Weapon[] storageWeapons;
    public Passive[] storagePassives;
    public Pilot emptyPilot;
    public StorageItem emptyStorageItem;
    public Equipable emptyEquipable;
    Run tempRun;
    string pDataP;

    public void Awake()
    {
        tempRun = Run.CreateInstance("Run") as Run;
        pDataP = Application.persistentDataPath;
    }

    public void LoadSave()
    {
        if (!File.Exists($"{pDataP}/Run.json"))
        {
            return;
        }

        save.selectedSquad = new Squad();

        JsonUtility.FromJsonOverwrite(File.ReadAllText($"{pDataP}/Run.json"), tempRun);
        JsonUtility.FromJsonOverwrite(File.ReadAllText($"{pDataP}/Run.json"), save);

        ClearInventory();

        // Load Inventário
        for (int i = 0; i < tempRun.inventory.Count; i++)
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText($"{pDataP}/InventoryItem{i}.json"), storageItems[i]);
            switch (storageItems[i].storageType)
            {
                case storageType.pilot:
                    JsonUtility.FromJsonOverwrite(File.ReadAllText($"{pDataP}/InventoryItem{i}.json"), storagePilots[i]);
                    storageItems[i] = storagePilots[i];
                    break;
                case storageType.passive:
                    JsonUtility.FromJsonOverwrite(File.ReadAllText($"{pDataP}/InventoryItem{i}.json"), storagePassives[i]);
                    storageItems[i] = storagePassives[i];
                    break;
                case storageType.weapon:
                    JsonUtility.FromJsonOverwrite(File.ReadAllText($"{pDataP}/InventoryItem{i}.json"), storageWeapons[i]);
                    storageItems[i] = storageWeapons[i];
                    break;
            }

            save.inventory[i] = storageItems[i];
        }

        for (int i = 0; i < tempRun.selectedSquad.Mechs.Length; i++)
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText($"{pDataP}/Mech{i}Pilot.json"), equippedPilots[i]);
            save.selectedSquad.Mechs[i].pilot = equippedPilots[i];

            for (int j = 0; j < tempRun.selectedSquad.Mechs[i].mechEquip.Length; j++)
            {
                if (!File.Exists($"{pDataP}/Mech{i}Equipable{j}.json"))
                {
                    continue;
                }
                JsonUtility.FromJsonOverwrite(File.ReadAllText($"{pDataP}/Mech{i}Equipable{j}.json"), equipped[i]);
                switch (equipped[i].equipableType)
                {
                    case EquipableType.Passive:
                        JsonUtility.FromJsonOverwrite(File.ReadAllText($"{pDataP}/Mech{i}Equipable{j}.json"), equippedPassives[j]);
                        save.selectedSquad.Mechs[i].mechEquip[j] = equippedPassives[j];
                        break;
                    case EquipableType.Weapon:
                        JsonUtility.FromJsonOverwrite(File.ReadAllText($"{pDataP}/Mech{i}Equipable{j}.json"), equippedWeapons[j]);
                        save.selectedSquad.Mechs[i].mechEquip[j] = equippedWeapons[j];
                        break;
                }
            }
        }
    }

    void ClearInventory()
    {
        save.inventory.Clear();
        for (int i = 0; i < 9; i++)
        {
            save.inventory.Add(emptyStorageItem);
        }
    }

    void ClearMechEquipped()
    {
        foreach (Mech mech in save.selectedSquad.Mechs)
        {
            mech.mechEquip = new Equipable[] { emptyEquipable, emptyEquipable };
        }
    }

    public void SaveSave()
    {
        SaveRun(gameInfo.baseRunToSave);

        for (int i = 0; i < gameInfo.baseRunToSave.selectedSquad.Mechs.Length; i++)
        {

            // Salvando informações dos Mechs
            SaveMechPilot(gameInfo.baseRunToSave.selectedSquad.Mechs[i].pilot, i);

            // Armas e Passivas dos Mechs
            for (int j = 0; j < gameInfo.baseRunToSave.selectedSquad.Mechs[i].mechEquip.Length; j++)
            {
                if (gameInfo.baseRunToSave.selectedSquad.Mechs[i].mechEquip[j] is Weapon)
                {
                    SaveWeapon(gameInfo.baseRunToSave.selectedSquad.Mechs[i].mechEquip[j], i, j);
                }
                else if (gameInfo.baseRunToSave.selectedSquad.Mechs[i].mechEquip[j] is Passive)
                {
                    SavePassive(gameInfo.baseRunToSave.selectedSquad.Mechs[i].mechEquip[j], i, j);
                }
            }
        }

        // Salvando itens do inventário
        for (int i = 0; i < gameInfo.baseRunToSave.inventory.Count; i++)
        {
            if (gameInfo.baseRunToSave.inventory[i] is Pilot)
            {
                SaveInventoryPilot(gameInfo.baseRunToSave.inventory[i], i);
            }
            else if(gameInfo.baseRunToSave.inventory[i] is Passive)
            {
                SaveInventoryPassive(gameInfo.baseRunToSave.inventory[i], i);
            }
            else if (gameInfo.baseRunToSave.inventory[i] is Weapon)
            {
                SaveInventoryWeapon(gameInfo.baseRunToSave.inventory[i], i);
            }
        }
    }

    void SaveRun(Run run)
    {
        string json = JsonUtility.ToJson(run, true);
        string dataPath = $"{pDataP}/Run.json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    void SaveMechPilot(Pilot pilot, int i)
    {
        string json = JsonUtility.ToJson(pilot, true);
        string dataPath = $"{pDataP}/Mech{i}Pilot.json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    void SaveWeapon(Equipable mechEquip, int mechIndex, int weaponIndex)
    {
        string json = JsonUtility.ToJson(mechEquip as Weapon, true);
        string dataPath = $"{pDataP}/Mech{mechIndex}Equipable{weaponIndex}.json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    void SavePassive(Equipable mechEquip, int mechIndex, int weaponIndex)
    {
        string json = JsonUtility.ToJson(mechEquip as Passive, true);
        string dataPath = $"{pDataP}/Mech{mechIndex}Equipable{weaponIndex}.json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    void SaveInventoryPilot(StorageItem item, int i)
    {
        string json = JsonUtility.ToJson(item as Pilot, true);
        string dataPath = $"{pDataP}/InventoryItem{i}.json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    void SaveInventoryPassive(StorageItem item, int i)
    {
        string json = JsonUtility.ToJson(item as Passive, true);
        string dataPath = $"{pDataP}/InventoryItem{i}.json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    void SaveInventoryWeapon(StorageItem item, int i)
    {
        string json = JsonUtility.ToJson(item as Weapon, true);
        string dataPath = $"{pDataP}/InventoryItem{i}.json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }
}
