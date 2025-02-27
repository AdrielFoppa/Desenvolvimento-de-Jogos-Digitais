using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{

    [SerializeField] private string nomeDaFase;
    // Start is called before the first frame update
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDaFase);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Menu");
    }
}
