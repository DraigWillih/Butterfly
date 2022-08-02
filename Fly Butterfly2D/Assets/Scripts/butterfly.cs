using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butterfly : MonoBehaviour
{
    private GameController gameController;

    public float Nectar;
    public float score;
        
    public float speed = 1f;
    private Rigidbody2D rig;

    public GameObject GameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
        gameController.StartMission();
        GameOver = GameObject.FindWithTag("GameOver");
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.nectar++;
        gameController.nectarText.text = gameController.nectar.ToString();
    }

    IEnumerator closeGameOver()
    {
        yield return 1f;
    }

}
