using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float intervalo = 3f; // Intervalo em segundos entre as tentativas de spawn
    [Range(0f, 1f)]
    public float chanceSpawn = 0.5f; // Chance de spawn entre 0 e 1 (0% a 100%)

    public float variacaoVertical = 2.5f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalo);

            if (Random.value <= chanceSpawn)
            {
                Vector3 posicaoSpawn = transform.position + new Vector3(0, Random.Range(-variacaoVertical,variacaoVertical),0);
                Instantiate(enemyPrefab, posicaoSpawn, Quaternion.identity);
            }
        }
    }
}
