using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gc;


    public int nectar;
    public Text nectarText;

    private MissionBase[] missions;
    

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
            Debug.Log("funcionou");
        }
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
}
