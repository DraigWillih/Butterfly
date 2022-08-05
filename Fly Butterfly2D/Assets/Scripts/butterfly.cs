using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class butterfly : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rig;

    public GameObject GameOver, textNectar;
    public TMP_Text nectarText;

    public AudioClip[] soundFx;
    private AudioSource audioSfx;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = GameObject.FindWithTag("GameOver");
        textNectar = GameObject.Find("TMPNectar");
        nectarText = textNectar.GetComponent<TMP_Text>();
        GameOver.SetActive(false);
        rig = GetComponent<Rigidbody2D>();
        GameController.instance.nectarText = nectarText;
        GameController.instance.nectarText.text = GameController.instance.nectar_current.ToString("N0");
        GameController.instance.StartMission();
        audioSfx = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = GameController.instance.anim_Current.runtimeAnimatorController;
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
        GameController.instance.nectar_max += GameController.instance.nectar_current;
        GameController.instance.data.Save(GameController.instance.nectar_max);
        audioSfx.clip = soundFx[0];
        audioSfx.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.instance.nectar_current++;
        GameController.instance.nectarText.text = GameController.instance.nectar_current.ToString();
        Destroy(collision.gameObject);
        audioSfx.clip = soundFx[1];
        audioSfx.Play();
    }

    public void LoadScenes(string cena)
    {
        GameController.instance.LoadScenes(cena);
    }
}
