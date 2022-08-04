using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void Menu()
    {
        GameController.instance.LoadScenes("Start");
    }
}

