using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        if (is_collect == false)
        {
            is_collect = true;
            GameController.instance.nectar_current++;
            GameController.instance.nectarText.text = GameController.instance.nectar_current.ToString();
            StartCoroutine(Collect());
        }
=======
        GameController.instance.nectar_current++;
        GameController.instance.nectarText.text = GameController.instance.nectar_current.ToString();
        Destroy(collision.gameObject);
>>>>>>> f73092f068d1119246e59e44ba9c4d08fe6946c7
    }

    public void LoadScenes(string cena)
    {
        GameController.instance.LoadScenes(cena);
    }
}
