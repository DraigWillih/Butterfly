using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timeLevelTxt;
    public static bool stopTime;

    private bool is_finish;

    // Start is called before the first frame update
    void Start()
    {
        stopTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        Score();
    }
    public void Score()
    {
        if (stopTime == false)
        {
            GameController.instance.score_current = GameController.instance.score_current + Time.deltaTime;
            timeLevelTxt.text = GameController.instance.score_current.ToString("F0");
        }
        else if (is_finish == false)
        {
            is_finish = true;
            for (int i = 0; i < GameController.instance.missions.Length; i++)
            {
                if (GameController.instance.missions[i].missionType == MissionType.TotalMeters)
                {
                    print("if");
                    GameController.instance.missions[i].progress += (int)GameController.instance.score_current;
                    print(GameController.instance.missions[i].progress);
                    print(GameController.instance.missions[i].currentProgress);
                }
                else if (GameController.instance.missions[i].missionType == MissionType.NectarSingleRun)
                {
                    print("else if");
                    GameController.instance.missions[i].progress += (int)GameController.instance.nectar_current;
                }
            }
    }
}
}
