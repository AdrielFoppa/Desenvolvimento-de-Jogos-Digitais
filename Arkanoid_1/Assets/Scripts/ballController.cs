using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D meuRb;
    public GameObject player;
    public bool launched = false;

    // Start is called before the first frame update
    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched)
        {
            startBall();
        }
        
    }


    public void startBall()
    {
        transform.position = player.transform.position + new Vector3(0,0.25f,0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            meuRb.velocity = new Vector2(0.5f,.85f) * speed;
            launched = true;
        }
    }
}
