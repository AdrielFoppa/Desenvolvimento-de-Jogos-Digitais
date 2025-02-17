using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{

    public Rigidbody2D rb;
    private Vector2 velocity;
    public float velocidade;
    public float limiteHorizontal = 12f;
    public AudioClip boing;
    public Transform posicaoCamera;
    public float delay = 1.5f;//1.5 segundos
    private bool jogoIniciado = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //iniciando bola com delay
        delay = delay - Time.deltaTime;


        if(delay <= 0 && !jogoIniciado) {
            jogoIniciado=true;
            velocidade = 5f;
            float direcao = Random.Range(1, 5);
            if (direcao == 1)
            {
                velocity.y = velocidade;
                velocity.x = velocidade;
            }
            else if (direcao == 2)
            {
                velocity.y = -velocidade;
                velocity.x = velocidade;
            }
            else if (direcao == 3)
            {
                velocity.y = velocidade;
                velocity.x = -velocidade;
            }
            else
            {
                velocity.y = -velocidade;
                velocity.x = -velocidade;
            }
            rb.velocity = velocity;
        }

        //Verificando se a bola saiu do limite da tela
        if(transform.position.x > limiteHorizontal ||  transform.position.x  < -limiteHorizontal) {
            //Recarreando a cena
            SceneManager.LoadScene(0);
        }

    }

    //Criando evento de colisão da bola para fazer o som
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(boing,posicaoCamera.position);
    }
}
