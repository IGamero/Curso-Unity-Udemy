using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject poweUpPrefab;

    public bool gameOver;

    private float spawnRange = 9;

    public int enemyCount;
    public int enemyWave = 1;
    public int powerUpCount;

    public float enemyHighSpawn = 10;
    public float powerUpHighSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PermaSpawnEnemyWave(enemyWave));
    }


    //IMPORTANTE esta wea entra en el EXAMEN de Unity 100%
    /// <summary>
    /// Genera una posición aleatoria dentro de la zona de juego
    /// </summary>
    /// <para name = "high">indica la altura a la que spawnear</para>
    /// <returns>Devuelve una posicion aleatoria dentro de la zona de juego</returns>
    private Vector3 GenerateRandomSpawnPosition(float high)
    {

        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionY = high;
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);

        return randomPosition;
    }

    /// <summary>
    /// Genera un numero de enemigos determinados en pantalla.
    /// </summary>
    /// <param name="numerOfEnemies"></param>
  
    private void SpawnEnemyWave(int enemyWave)
    {
        for (int i = 0; i < enemyWave; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomSpawnPosition(enemyHighSpawn), enemyPrefab.transform.rotation);
        }
    }
   
    IEnumerator PermaSpawnEnemyWave(int enemyWave)
    {

        do
        {
            powerUpCount = GameObject.FindGameObjectsWithTag("PowerUp").Length;
            Debug.Log("powerUpCount = " + powerUpCount);

            SpawnEnemyWave(enemyWave);
            enemyWave++;

            if (powerUpCount == 0 && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().hasPowerUp == false)
            {
                Instantiate(poweUpPrefab, GenerateRandomSpawnPosition(powerUpHighSpawn), enemyPrefab.transform.rotation);
            }

            yield return new WaitForSeconds(10);
            
        } while (gameOver == false);
       

    }
}
