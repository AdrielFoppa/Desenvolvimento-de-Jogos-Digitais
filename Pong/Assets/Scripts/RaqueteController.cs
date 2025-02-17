using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    //Vetor para a posicao [x,y,z] - Privado pois so alteramos o eixo y
    private Vector3 posicao;
    //Valor do eixo Y
    private float eixoY;
    //velocidade 
    public float velocidade;
    //limites
    public float limite = 3.5f;
    //identificando player 1
    public bool player1;
    //Jogador automatico ou manual
    public bool automatico;
    //Pegando a posicao da bola
    public Transform transformBola;


    // Start 
    void Start()
    {
        //Iniciamos passando a posicao inicial da raquete 
        posicao = transform.position;

        //inicializando velocidade
        velocidade = 5f;
    }




    // Update
    void Update()
    {
        //Alteramos o valor do eixo y somente 
        posicao.y = eixoY;
        //Move a raquete para a variavel posicao, onde somente foi alterado o eixo y
        transform.position = posicao;
        //Velocidade Delta
        float velocidadeDelta = velocidade * Time.deltaTime;


        if (!automatico)
        {
            
            if (player1)
            {
                //Retorna true se a setinha para cima esteja pressionada
                if (Input.GetKey(KeyCode.W))
                {
                    //aumenta o valor do eixo y 
                    eixoY = eixoY + velocidadeDelta; //para normalizar para cada taxa de quadros por segundo
                }
                //Retorna true se a s+etinha para baixo esteja pressionada
                else if (Input.GetKey(KeyCode.S))
                {
                    eixoY = eixoY - velocidadeDelta;
                }
            }

            else
            {
                //Retorna true se a setinha para cima esteja pressionada
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    //aumenta o valor do eixo y 
                    eixoY = eixoY + velocidadeDelta; //para normalizar para cada taxa de quadros por segundo
                }
                //Retorna true se a s+etinha para baixo esteja pressionada
                //Mesmo funcao da setinha para cima, porem mais compacto
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    eixoY = eixoY - velocidadeDelta;
                }

                //Se desejar que o player2 volte ao automatico aperte enter
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    automatico = true;
                }
            }
        }
        else
        {

            //se o jogar desejar tirar do automatico, basta comecar a controlar o player2
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)){
                automatico = false;
            }

            //controle para raquete no automatico
            //Para funções matematicas usamos o Mathf
            //usamos essa funcao para controlar o posicionamento da raquete automatica
            eixoY = Mathf.Lerp(eixoY, transformBola.position.y,0.1f);
        }


        //define os limites do mapa
        if(eixoY < -limite)
        {
            eixoY = -limite;
        }
        if(eixoY > limite)
        {
            eixoY = limite;
        }     
    }
}
