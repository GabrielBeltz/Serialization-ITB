using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class JsonWorker : MonoBehaviour
{
    public GameInfoSetter gameInfo;
    public StorageItem[] storageItems;
    public Pilot[] storagePilots;
    public Weapon[] storageWeapons;
    public Passive[] storagePassives;
    public Run save;
    Run tempRun;
    string pDataP;

    public void Awake()
    {
        tempRun = Run.CreateInstance("Run") as Run;
        pDataP = Application.persistentDataPath;
    }

    public void LoadSave()
    {
        JsonUtility.FromJsonOverwrite(File.ReadAllText($"{pDataP}/Run.json"), tempRun);
        save.inventory.Clear();

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
                default:
                    break;
            }
        }
    }

    public void SaveSave()
    {
        //string json = JsonUtility.ToJson(gameInfo.baseRunToSave, true);
        //string dataPath = Application.persistentDataPath + "/IntoTheBreach Save.json";
        //StreamWriter sw =  File.CreateText(dataPath);
        //sw.Close();
        //File.WriteAllText(dataPath, json);

        SaveRun(gameInfo.baseRunToSave);

        for (int i = 0; i < gameInfo.baseRunToSave.selectedSquad.Mechs.Length; i++)
        {

            // Salvando informações dos Mechs
            SaveMech(gameInfo.baseRunToSave.selectedSquad.Mechs[i], i);
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

    void SaveMech(Mech mech, int i)
    {
        string json = JsonUtility.ToJson(mech, true);
        string dataPath = $"{pDataP}/Mech{i}.json";
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
