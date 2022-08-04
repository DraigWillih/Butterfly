using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public enum MissionType
{
    SingleRun,TotalMeters, NectarSingleRun
}
public abstract class MissionBase : MonoBehaviour
{
    public int max; //quanto falta para completar a missão
    public int progress;
    public int reward;
    public butterfly butterfly;
    public int currentProgress;
    public MissionType missionType;

    public abstract void Created();
    public abstract string GetMissionDescription();
    public abstract void RunStart();
    public abstract void Update();

    public bool GetMissionComplete()
    {
        if((progress + currentProgress) >= max)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class SingleRun : MissionBase
{
    public override void Created()
    {
        missionType = MissionType.SingleRun;
        int[] maxValues = {100,200,200,400,500};
        int randomMaxValue = Random.Range(0, maxValues.Length);
        int[] rewards = { 10, 20, 30, 40, 50 };
        reward = rewards[randomMaxValue];
        max = maxValues[randomMaxValue];
        progress = 0;
    }

    public override string GetMissionDescription()
    {
        return "Voe" + max + "m em uma fase";
    }

    public override void RunStart()
    {
        progress = 0;
        butterfly = FindObjectOfType<butterfly>();
    }

    public override void Update()
    {
        if (butterfly == null) return;

        progress = (int)butterfly.score;
    }
}

public class TotalMeters : MissionBase
{
    public override void Created()
    {
        missionType = MissionType.TotalMeters;
        int[] maxValues = { 100, 200, 300, 400, 500 };
        int randomMaxValue = Random.Range(0, maxValues.Length);
        int[] rewards = { 100, 200, 300, 400, 500 };
        reward = rewards[randomMaxValue];
        max = maxValues[randomMaxValue];
        progress = 0;
    }

    public override string GetMissionDescription()
    {
        return "Voe" + max + "m no total";
    }

    public override void RunStart()
    {
        progress += currentProgress;
        butterfly = FindObjectOfType<butterfly>();
    }

    public override void Update()
    {
        if (butterfly == null) return;
        currentProgress = (int)butterfly.score;
    }
}

public class NectarSingleRun : MissionBase
{
    public override void Created()
    {
        missionType = MissionType.NectarSingleRun;
        int[] maxValues = { 10, 20, 30};
        int randomMaxValue = Random.Range(0, maxValues.Length);
        int[] rewards = { 100, 200, 300, 400, 500 };
        reward = rewards[randomMaxValue];
        max = maxValues[randomMaxValue];
        progress = 0;
    }

    public override string GetMissionDescription()
    {
        return "colete" + max + "nectars em uma corrida";
    }

    public override void RunStart()
    {
        progress = 0;
        butterfly = FindObjectOfType<butterfly>();
    }

    public override void Update()
    {
        if (butterfly == null) return;
        progress = (int)butterfly.nectar;
    }
}

