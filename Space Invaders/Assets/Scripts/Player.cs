using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public Projectile laserPrefab;

    private bool _laserActive;

    public int hp = 3;
    public bool defeat = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }

    }

    private void shoot() {
        if (!_laserActive)
        {
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += laserDestroyed;
            _laserActive = true;
        }
    }

    private void laserDestroyed() {
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            defeat = true;
        }else{
            hp--;
        }
    }
}
