using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float intervaloTiro = 3f;
    public float proximoTiro = 0f;

    public Rigidbody2D rb;
    public float speed = 2f;

    public float points = 100f;
    public GameController controller;

    public GameObject tiro;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        if(controller == null)
        {
            Debug.Log("Controller nao identificado");
        }
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
        //movimentação do inimigo 
        rb.velocity = Vector3.left * speed;

        if (controller.slow)
        {
            speed = 1f;
            intervaloTiro = 4.5f;
        }
        else
        {
            speed = 2;
            intervaloTiro = 3f;
        }
    }

    public void shoot()
    {
        //atira respeitando o valor de intervalo prederteminado 
        if(Time.time >= proximoTiro)
        {
            Instantiate(tiro,transform.position,Quaternion.identity);
            proximoTiro = Time.time + intervaloTiro;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            controller.points += this.points;
        }
        
    }
}
