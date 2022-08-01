using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
	
	public Text[] missionDescription, missionReward, missionProgress;
	public GameObject[] RecompensaBtn;
	private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
		gameController = FindObjectOfType(typeof(GameController)) as GameController;
		SetMission();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void SetMission()
	{
		for (int i = 0; i < 2; i++)
		{
			MissionBase missions = gameController.GetMission(i);
			missionDescription[i].text = missions.GetMissionDescription();
			missionReward[i].text = "Recompensa: " + missions.reward;
			missionProgress[i].text = missions.progress + missions.currentProgress + " / " + missions.max;
			if (missions.GetMissionComplete())
			{
				RecompensaBtn[i].SetActive(true);
			}
		}
	}
}
