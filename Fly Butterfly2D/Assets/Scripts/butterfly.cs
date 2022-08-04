using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class butterfly : MonoBehaviour
{
<<<<<<< HEAD
    private GameController gameController;

    public float score;

    public int nectar;
    public TextMeshProUGUI nectarText;

=======
>>>>>>> f05da8ad0ffc11422a59a2bfa8eccb0c79d8d266
    public float speed = 1f;
    private Rigidbody2D rig;
    private bool is_collect;

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
<<<<<<< HEAD
            nectar++;
            nectarText.text = nectar.ToString();        
=======
        if (is_collect == false)
        {
            is_collect = true;
            GameController.instance.nectar_current++;
            GameController.instance.nectarText.text = GameController.instance.nectar_current.ToString();
            StartCoroutine(Collect());
        }
>>>>>>> f05da8ad0ffc11422a59a2bfa8eccb0c79d8d266
    }

    public void LoadScenes(string cena)
    {
        GameController.instance.LoadScenes(cena);
    }

    IEnumerator Collect()
    {
        yield return new WaitForSeconds(2);
        is_collect = false;
    }

}
