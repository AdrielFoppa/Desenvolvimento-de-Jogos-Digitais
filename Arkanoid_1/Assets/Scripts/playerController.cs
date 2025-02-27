using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D meuRb;
    public float limiteHorizontal = 4.8f;

    // Start is called before the first frame update
    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            meuRb.velocity = new Vector3(-speed, 0, 0);
        }else if (Input.GetKey(KeyCode.RightArrow)) {
            meuRb.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            meuRb.velocity = Vector3.zero;
        }

        LimitarPosicao();
    }

    private void LimitarPosicao()
    {
        float posX = Mathf.Clamp(transform.position.x, -limiteHorizontal, limiteHorizontal);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
