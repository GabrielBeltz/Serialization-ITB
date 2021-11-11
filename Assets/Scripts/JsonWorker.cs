using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonWorker : MonoBehaviour
{
    public GameInfoSetter gameInfo;
    public StorageItem storageItem0;
    public Weapon weapon0;
    public Passive passive0;
    public Pilot pilot0;

    public void LoadSave()
    {
        File.ReadAllText(Application.persistentDataPath + "/Mech" + 1.ToString() + ".json");
        JsonUtility.FromJsonOverwrite(File.ReadAllText(Application.persistentDataPath + "/InventoryItem0.json"), storageItem0);

        switch (storageItem0.storageType)
        {
            case storageType.pilot:
                JsonUtility.FromJsonOverwrite(File.ReadAllText(Application.persistentDataPath + "/InventoryItem0.json"), pilot0);
                break;
            case storageType.passive:
                JsonUtility.FromJsonOverwrite(File.ReadAllText(Application.persistentDataPath + "/InventoryItem0.json"), passive0);
                break;
            case storageType.weapon:
                JsonUtility.FromJsonOverwrite(File.ReadAllText(Application.persistentDataPath + "/InventoryItem0.json"), weapon0);
                break;
            default:
                break;
        }
    }

    public void SaveSave()
    {
        //string json = JsonUtility.ToJson(gameInfo.baseRunToSave, true);
        //string dataPath = Application.persistentDataPath + "/IntoTheBreach Save.json";
        //StreamWriter sw =  File.CreateText(dataPath);
        //sw.Close();
        //File.WriteAllText(dataPath, json);

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

    void SaveMech(Mech mech, int index)
    {
        string json = JsonUtility.ToJson(mech, true);
        string dataPath = Application.persistentDataPath + "/Mech" + index.ToString() + ".json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    void SaveMechPilot(Pilot pilot, int index)
    {
        string json = JsonUtility.ToJson(pilot, true);
        string dataPath = Application.persistentDataPath + "/Mech" + index.ToString() + "Pilot.json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    void SaveWeapon(Equipable mechEquip, int mechIndex, int weaponIndex)
    {
        string json = JsonUtility.ToJson(mechEquip as Weapon, true);
        string dataPath = Application.persistentDataPath + "/Mech" + mechIndex.ToString() + "Equipable" + weaponIndex.ToString() + ".json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    void SavePassive(Equipable mechEquip, int mechIndex, int weaponIndex)
    {
        string json = JsonUtility.ToJson(mechEquip as Passive, true);
        string dataPath = Application.persistentDataPath + "/Mech" + mechIndex.ToString() + "Equipable" + weaponIndex.ToString() + ".json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    void SaveInventoryPilot(StorageItem item, int index)
    {
        string json = JsonUtility.ToJson(item as Pilot, true);
        string dataPath = Application.persistentDataPath + "/InventoryItem" + index.ToString() + ".json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    void SaveInventoryPassive(StorageItem item, int index)
    {
        string json = JsonUtility.ToJson(item as Passive, true);
        string dataPath = Application.persistentDataPath + "/InventoryItem" + index.ToString() + ".json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    void SaveInventoryWeapon(StorageItem item, int index)
    {
        string json = JsonUtility.ToJson(item as Weapon, true);
        string dataPath = Application.persistentDataPath + "/InventoryItem" + index.ToString() + ".json";
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }
}
