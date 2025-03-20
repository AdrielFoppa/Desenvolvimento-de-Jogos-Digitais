using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    public float parallaxEffect;
    public GameController controller;



    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * parallaxEffect;
        if (transform.position.x < -length)
        {
            transform.position = new Vector3(length,transform.position.y,transform.position.z);
        }

        //reduz a velocidade do parallax durante o tempo que a variavel slow do objeto controller estiver em true
        if (controller.slow)
        {
            parallaxEffect = 0.2f;
        }
        else
        {
            parallaxEffect = 0.7f;
        }
    }
}
