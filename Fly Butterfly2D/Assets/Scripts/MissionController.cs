using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionController : MonoBehaviour
{
	public TMP_Text[] missionDescription, missionReward, missionProgress;
	public GameObject[] RecompensaBtn;

	public TextMeshProUGUI nectarText;
	

    // Start is called before the first frame update
    IEnumerator Start()
    {
		yield return new WaitForSeconds(1);
		GameController.instance.nectarText = nectarText;
		GameController.instance.UpdateHUD();
		SetMission();
    }

	public void UpdateNectar(float nectar)
    {
		nectarText.text = nectar.ToString();
    }

	public void SetMission()
	{
		for (int i = 0; i < 2; i++)
		{
			MissionBase missions = GameController.instance.GetMission(i);
			missionDescription[i].text = missions.GetMissionDescription();
			missionReward[i].text = $"Recompensa: {missions.reward}";
			missionProgress[i].text = $"{missions.progress + missions.currentProgress} / {missions.max}";
			if (missions.GetMissionComplete())
			{
				RecompensaBtn[i].SetActive(true);
				GameController.instance.data.SaveMissionComplete(GameController.instance.id_mission[i], true);
			}
		}
	}

	public void PegarRecompensa(int missionIndex)
    {
		GameController.instance.nectar_current += GameController.instance.GetMission(missionIndex).reward;
		UpdateNectar(GameController.instance.nectar_current);
		RecompensaBtn[missionIndex].SetActive(false);
		GameController.instance.GenerateMission(missionIndex);
    }
}
