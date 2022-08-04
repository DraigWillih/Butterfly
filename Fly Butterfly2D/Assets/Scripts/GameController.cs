using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Random = UnityEngine.Random;

[Serializable]
public class PlayerData
{
    public int nectar;
    public int[] max; //maximo da missão
    public int[] progress;
    public int[] currentProgress;
    public int[] reward;
    public string[] missionType;
}

public class GameController : MonoBehaviour
{
    public static GameController gc;

    public int nectar;

    private MissionBase[] missions;

    private string filePath;

    
    private void Awake()
    {
        missions = new MissionBase[2];
        for (int i = 0; i < missions.Length; i++)
        {
            GameObject newMission = new GameObject("Mission" + i);
            newMission.transform.SetParent(transform);
            MissionType[] missionType = { MissionType.SingleRun, MissionType.NectarSingleRun, MissionType.TotalMeters };
            int randomType = Random.Range(0, missionType.Length);
            if(randomType == (int)MissionType.SingleRun)
            {
                missions[i] = newMission.AddComponent<SingleRun>();
            }
            else if (randomType == (int)MissionType.TotalMeters)
            {
                missions[i] = newMission.AddComponent<TotalMeters>();
            }
            else if (randomType == (int)MissionType.NectarSingleRun)
            {
                missions[i] = newMission.AddComponent<NectarSingleRun>();
            }
            missions[i].Created();            
        }
        filePath = Application.persistentDataPath + "/playerInfo.dat";
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public MissionBase GetMission(int index)
    {
        return missions[index];
    }

    public void StartMission()
    {
        for (int i = 0; i < 2; i++)
        {
            missions[i].RunStart();
        }
    }

    public void GenerateMission(int index)
    {
        Destroy(missions[index].gameObject);
        GameObject newMission = new GameObject("Mission" + index);
        newMission.transform.SetParent(transform);
        MissionType[] missionType = { MissionType.SingleRun, MissionType.NectarSingleRun, MissionType.TotalMeters };
        int randomType = Random.Range(0, missionType.Length);
        if (randomType == (int)MissionType.SingleRun)
        {
            missions[index] = newMission.AddComponent<SingleRun>();
        }
        else if (randomType == (int)MissionType.TotalMeters)
        {
            missions[index] = newMission.AddComponent<TotalMeters>();
        }
        else if (randomType == (int)MissionType.NectarSingleRun)
        {
            missions[index] = newMission.AddComponent<NectarSingleRun>();
        }
        missions[index].Created();

        FindObjectOfType<MissionController>().SetMission();
    }

    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);

        PlayerData data = new PlayerData();

        data.nectar = nectar;

        data.max = new int[2];
        data.progress = new int[2];
        data.currentProgress = new int[2];
        data.reward = new int[2];
        data.missionType = new string[2];

        for (int i = 0; i < 2; i++)
        {
            data.max[i] = missions[i].max;
            data.progress[i] = missions[i].progress;
            data.currentProgress[i] = missions[i].currentProgress;
            data.reward[i] = missions[i].reward;
            data.missionType[i] = missions[i].missionType.ToString();
        }

        bf.Serialize(file, data);
        file.Close();
    }
}
