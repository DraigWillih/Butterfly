using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timeLevelTxt;
    public static bool stopTime;

    private GameController gameController;
    
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
    }
}
