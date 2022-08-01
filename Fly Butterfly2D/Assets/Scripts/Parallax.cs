using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght;
    private float startPos;
    private Transform cam;

    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float rePos = cam.transform.position.x * (1 - parallaxEffect);
        float Distance = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPos + Distance, transform.position.y, transform.position.z);

        if(rePos > startPos + lenght) { startPos += lenght; }
    }
}
