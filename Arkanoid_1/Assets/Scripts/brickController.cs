using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class brickController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameController gc = FindObjectOfType<gameController>();
            if (gc != null)
            {
                gc.BrickDestroyed();
            }
        }

        Destroy(gameObject, 0.1f);
    }
}
