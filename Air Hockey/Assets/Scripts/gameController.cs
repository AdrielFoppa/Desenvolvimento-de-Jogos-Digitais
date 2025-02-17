using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static gameController instance;

    // Placar para cada time
    public int placarTime1 = 0;
    public int placarTime2 = 0;

    // Referências para os textos da UI (arraste no Inspector)
    public TextMeshProUGUI placarTextTime1;
    public TextMeshProUGUI placarTextTime2;

    private void Awake()
    {
        // Implementação simples de Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para atualizar o placar; o parâmetro "time" indica qual time marcou o gol
    public void AtualizarPlacar(int time)
    {
        if (time == 1)
        {
            placarTime1++;
        }
        else if (time == 2)
        {
            placarTime2++;
        }
        AtualizarUI();
    }

    // Atualiza os textos da UI com os valores atuais do placar
    void AtualizarUI()
    {
        if (placarTextTime1 != null)
            placarTextTime1.text = placarTime1.ToString();
        if (placarTextTime2 != null)
            placarTextTime2.text = placarTime2.ToString();
    }
}