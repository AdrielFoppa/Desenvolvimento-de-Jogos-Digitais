using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;
    public int points;

    public System.Action killed;

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;
    private Controller controller;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject gameController = GameObject.Find("GameController");
        if( gameController != null)
        {
            controller = gameController.GetComponent<Controller>();
        }
        else
        {
            Debug.LogWarning("Nao encontrado");
        }
    }

    void Start()
    {
        InvokeRepeating(nameof(animateSprite), this.animationTime, this.animationTime);
    }

    private void animateSprite() {
        _animationFrame++;

        if(_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            controller.points += this.points;
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}