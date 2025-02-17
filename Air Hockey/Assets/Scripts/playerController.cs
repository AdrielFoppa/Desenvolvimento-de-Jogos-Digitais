using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Limites para a posição do jogador
    public float minX = -8f;
    public float maxX = -0.85f;
    public float minY = -4f;
    public float maxY = 4f;

    // Armazena a posição anterior para calcular a velocidade (se necessário)
    private Vector3 lastPos;
    public Vector2 velocity;

    // Referência para o Rigidbody2D do jogador
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastPos = transform.position;
    }

    // Use FixedUpdate para movimentação baseada em física
    void Update()
    {
        rb.rotation = 0;
        // Obtem a posição do mouse na tela
        Vector3 mousePos = Input.mousePosition;
        // Converte a posição do mouse para as coordenadas do mundo
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Limita as coordenadas do mundo dentro dos limites estabelecidos
        float clampedX = Mathf.Clamp(worldPos.x, minX, maxX);
        float clampedY = Mathf.Clamp(worldPos.y, minY, maxY);

        // Move o jogador para a posição desejada usando MovePosition
        Vector2 newPosition = new Vector2(clampedX, clampedY);
        rb.MovePosition(newPosition);

        // Calcula a velocidade com base na mudança de posição, se necessário
        velocity = (transform.position - lastPos) / Time.deltaTime;
        lastPos = transform.position;
    }
}

