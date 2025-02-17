using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{

    // Referência para o GameObject do disco
    public GameObject puck;

    // Define a posição central desejada; pode ser Vector3.zero ou outro valor
    public Vector3 centerPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método público que reposiciona o disco
    public void ResetPuckPosition()
    {
        if (puck != null)
        {
            // Reposiciona o disco
            puck.transform.position = centerPosition;

            // Se o disco possuir Rigidbody2D, zere a velocidade para evitar movimento residual
            Rigidbody2D rb = puck.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
    }
}
