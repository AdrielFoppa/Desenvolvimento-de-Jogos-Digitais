using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Controller : MonoBehaviour
{
    public int points;
    public Invaders invaders;
    public Player player;
    private int hp;
    public TextMeshProUGUI vidasText;
    public TextMeshProUGUI pointsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void AtualizarText()
    {
        if (vidasText != null)
        {
            vidasText.text = "Vidas: " + hp.ToString();
        }
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        AtualizarText();
        hp = player.hp;
        if (invaders.percentKilled == 1)
        {
            SceneManager.LoadScene("victory");
            Debug.Log("Proxima cena");
        }else if(hp == 0 || player.defeat == true)
        {
            SceneManager.LoadScene("defeat");
            Debug.Log("perdeu");
        }
       
    }
}
