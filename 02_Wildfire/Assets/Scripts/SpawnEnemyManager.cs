using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemyManager : MonoBehaviour
{

    public GameObject[] enemies;

    private int animalIndex;
    private float spawnRangeX = 15;
    private float spawnPosZ;

    [SerializeField, Range(0, 3)]
    private float startDelay = 2f;
    [SerializeField, Range(0.1f, 3f)]
    private float spawnInterval = 1f;

    private void Start()
    {
        spawnPosZ = this.transform.position.z;
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
  


    void SpawnRandomAnimal()
    {

        //posicion de spawn
        float xRand = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(xRand, 0, spawnPosZ);

        animalIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[animalIndex], spawnPos, enemies[animalIndex].transform.rotation);
    }
}
