using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameController : MonoBehaviour
{
    public ballController ball;
    public int vidas = 3;
    public TextMeshProUGUI vidasText;
    public int remainingBricks;
    public int proximaFase;

    // Start is called before the first frame update
    void Start()
    {
        AtualizarVidasText();
        remainingBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        Debug.Log(remainingBricks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BrickDestroyed()
    {
        remainingBricks--;

        if (remainingBricks <= 0)
        {
            if(proximaFase == 2)
            {
                SceneManager.LoadScene("fase2");
            }else if(proximaFase == 3)
            {
                SceneManager.LoadScene("Victory");
            }
            
        }
    }



    void AtualizarVidasText()
    {
        if (vidasText != null)
        {
            vidasText.text = "Vidas: " + vidas.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        vidas--;
        AtualizarVidasText();
        if(vidas > 0)
        {
            ball.launched = false;
            ball.startBall();
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }
}
