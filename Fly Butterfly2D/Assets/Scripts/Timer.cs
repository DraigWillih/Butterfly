using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   public float timeLevel;
    public Text timeLevelTxt;
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
            timeLevel = timeLevel + Time.deltaTime;
            timeLevelTxt.text = timeLevel.ToString("F0");
        }
    }
}
