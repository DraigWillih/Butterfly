using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    //public int nectar;
    public TMP_Text nectarText;

    private MissionBase[] missions;

    private float nectar_max;
    [HideInInspector]
    public float nectar_current;
    private float score_max;
    [HideInInspector]
    public float score_current;
    [HideInInspector]
    public SaveController data;
    [HideInInspector]
    public AdsManager ads;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }

        missions = new MissionBase[2];
        for (int i = 0; i < missions.Length; i++)
        {
            GameObject newMission = new GameObject("Mission" + i);
            newMission.transform.SetParent(transform);
            MissionType[] missionType = { MissionType.SingleRun, MissionType.NectarSingleRun, MissionType.TotalMeters };
            int randomType = Random.Range(0, missionType.Length);
            if (randomType == (int)MissionType.SingleRun)
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
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
        Time.timeScale = 1;
    }

    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
        Time.timeScale = 1;
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
