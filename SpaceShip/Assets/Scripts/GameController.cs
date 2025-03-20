using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public float points = 0;
    public playerController player;
    public int vida;
    public bool slow = false;
    public EnemySpawner spawner;
    public TextMeshProUGUI vidasText;
    public TextMeshProUGUI pointsText;

    private float proximoEfeito = 1000f; // Comeca no primeiro multiplo de 1000 pontos

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        if (player == null)
        {
            Debug.LogError("Player nao encontrado ou sem o script 'playerController'");
        }
    }

    
    void AtualizarText()
    {
        if (vidasText != null)
        {
            vidasText.text = "Lifes: " + vida.ToString();
        }
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points.ToString();
        }
    }

    void Update()
    {
        AtualizarText();
        vida = player.vida;
        Debug.Log(vida);
        Debug.Log(points);

        //rotina que verifica que os pontos sao suiciente para bonus de reducao de velocidade
        if (points >= proximoEfeito && !slow)
        {
            //transforma a variavel slow em true para ser usada nos scripts reduzindo sua velocidade
            StartCoroutine(SlowEffect());
            proximoEfeito += 1000f; // Define o proximo multiplo de 1000
            spawner.intervalo = spawner.intervalo - 0.2f;
        }

        if (points >= 5000){
            SceneManager.LoadScene("Victory");
            Debug.Log("Vitoria");
        }else if(vida == 0){
            SceneManager.LoadScene("GameOver");
            Debug.Log("perdeu");
        }
    }

    IEnumerator SlowEffect()
    {
        slow = true;                   
        yield return new WaitForSeconds(6f); 
        slow = false;                  
    }

}
