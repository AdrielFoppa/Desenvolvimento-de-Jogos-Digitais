using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float velocidade = 5f;
    public Rigidbody2D rb;

    public GameObject laser;


    Vector2 movimento;

    public float intervaloTiro = 2f;
    public float proximoTiro = 0f;

    public int vida = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");  // A, D ou setas horizontais
        movimento.y = Input.GetAxisRaw("Vertical");    // W, S ou setas verticais
        shoot();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movimento.normalized * velocidade * Time.fixedDeltaTime);
    }

    private void shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time >= proximoTiro) {
            Instantiate(laser,transform.position,Quaternion.Euler(0,0,90));
            proximoTiro = Time.time + intervaloTiro;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Laser")
        {
            vida--;
            collision.gameObject.SetActive(false);
        }
    }
}
