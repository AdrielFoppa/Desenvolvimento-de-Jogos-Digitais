using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puckController : MonoBehaviour
{

    public Rigidbody2D meuRb;
    public AudioClip collisionSound; // Som a ser reproduzido na colisão
    private AudioSource audioSource;  // Referência ao AudioSource


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meuRb = GetComponent<Rigidbody2D>();
        Invoke("startPuck", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startPuck()
    {
        //gera um numero aleatorio para decidir de qual lado o disco ira iniciar
        float rand = Random.Range(0, 3);
        
        //inicializara do lado encima
        if(rand > 1)
        {
            transform.position = new Vector3(0, 2, 0);
        }
        else
        {
            transform.position = new Vector3(0, -2, 0);
        }
    }

    //função que irá verificar se algo entrar em contato com o disco
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //verifica se o que entrou em contato com o disco é um jogador
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Oponent"))
        {
            playerController pc = collision.gameObject.GetComponent<playerController>();
            if (pc != null)
            {
                Vector2 playerVel = pc.velocity;
                float forceMultiplier = 0.05f;

                // Aplica uma força no disco na direção do movimento do player
                meuRb.AddForce(playerVel * forceMultiplier, ForceMode2D.Impulse);
                Debug.Log("Força aplicada baseada na velocidade do player: " + playerVel);
            }
        }

        // Toca o som de colisão
        if (audioSource != null && collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("underGoal"))
        {
            meuRb.velocity = Vector3.zero;
            transform.position = new Vector3(0, -2, 0);
            gameController.instance.AtualizarPlacar(1);
        }
        else if (collision.CompareTag("upperGoal"))
        {
            meuRb.velocity = Vector3.zero;
            transform.position = new Vector3(0, 2, 0);
            gameController.instance.AtualizarPlacar(2);
        }
    }
}
