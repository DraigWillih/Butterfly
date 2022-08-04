using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveController : MonoBehaviour
{
    private SaveData data;
    private string path;

    private void Start()
    {
        GameController.instance.data = this;
        data = new SaveData();
        path = Application.persistentDataPath + "/data.json";
        SaveMission();
    }

    // salva a missão do player 
    public void SaveMission()
    {
        // valores para salvar id, valor, recompensa
        data.mission_id = new List<int>();
        print($"id {GameController.instance.id_mission[0]} id {GameController.instance.id_mission[1]}");
    }
    public void Save(int favo)
    {
        data.nectar = favo;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public void Load()
    {
        string json = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(json, data);
        GameController.instance.nectar_current = data.nectar;
    }
}

public class SaveData
{
    public int nectar;                         // valor total  
    public List<int> mission_max_value;         // valor maximo da missão
    public List<int> mission_id;                // valor id da missão
    public List<int> mission_current_progress; // salva valor acumulado da missão das missões que acumula
    public List<int> reward;                  // valor de recompensas para o player
    public List<string> missionType;         // tipo de missão
}