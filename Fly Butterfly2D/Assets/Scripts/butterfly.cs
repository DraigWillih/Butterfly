using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class butterfly : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rig;

    public GameObject GameOver;
    public TMP_Text nectarText;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        GameController.instance.nectarText = nectarText;
        GameController.instance.StartMission();
    }

    // Update is called once per frame
    void Update()        
    {
        if (Input.GetMouseButtonDown(0))
        {
            rig.velocity = Vector2.up * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        GameOver.SetActive(true);
        Time.timeScale = 0;
        Timer.stopTime = true;
        GameController.instance.data.Save(GameController.instance.nectar_current, GameController.instance.score_current);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.instance.nectar_current++;
        GameController.instance.nectarText.text = GameController.instance.nectar_current.ToString();
    }

    public void LoadScenes(string cena)
    {
        GameController.instance.LoadScenes(cena);
    }

}
