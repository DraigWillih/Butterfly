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
    }
    public void Save(float favo,  float score)
    {
        data.distance = score;
        data.nectar = favo;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public void Load()
    {
        string json = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(json, data);
    }
}

public class SaveData
{
    public float distance;
    public float nectar;
}