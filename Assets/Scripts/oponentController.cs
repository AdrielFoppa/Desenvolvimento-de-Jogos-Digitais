using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oponentController : MonoBehaviour
{
    // Referência para o disco (puck). Arraste o objeto do disco na propriedade no Inspector.
    public Transform puck;
    public float speed = 5f;
    public float reactionDelay = 0.2f;
    private float reactionTimer = 0f;

    public float minY = -4f;
    public float maxY = 4f;

    private Vector3 defaultPosition;

    private bool canMove = false;

    void Start()
    {
        Invoke("startMove", 2);
        defaultPosition = transform.position;
    }


    void Update()
    {
        if(canMove == true)
        {
            if (puck == null) return;

            reactionTimer += Time.deltaTime;

            if (reactionTimer >= reactionDelay)
            {
                reactionTimer = 0f;

                // Define targetPos com as coordenadas x e y do puck (movimento diagonal permitido)
                Vector3 targetPos = new Vector3(puck.position.x, puck.position.y, transform.position.z);

                if (Mathf.Abs(puck.position.x - transform.position.x) > 2f)
                {
                    // Faz uma interpolação entre a posição do puck e a posição padrão
                    targetPos.x = Mathf.Lerp(puck.position.x, defaultPosition.x, 0.5f);
                    targetPos.y = Mathf.Lerp(puck.position.y, defaultPosition.y, 0.5f);
                }

                // Limita o movimento vertical
                targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

                // Move o oponente em direção ao targetPos de forma suave
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            }
        }
        
    }

    private void startMove()
    {
        canMove = true;
    }
}
