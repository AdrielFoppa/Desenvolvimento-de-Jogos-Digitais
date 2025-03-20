using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 6f;

    private Vector2 direcao;
    public GameController controller;


    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Calcula a direção para o jogador no momento da criação do tiro
            direcao = (player.transform.position - transform.position).normalized;
        }
        else
        {
            Debug.LogWarning("Player nao encontrado");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Move o tiro constantemente na direção calculada inicialmente
        transform.Translate(direcao * speed * Time.deltaTime);

        if (controller.slow)
        {
            speed = 2f;
        }
        else
        {
            speed = 4f;
        }
    }

}
