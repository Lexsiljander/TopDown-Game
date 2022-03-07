using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 1.5f;

    public GameObject[] enemies;
    public GameObject player;

    public int enemyCount;

    //public static EnemySpawner instance;
    // Start is called before the first frame update
    void Start()
    {
     
        StartCoroutine(SpawnAnEnemy());
    }
       

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawnAnEnemy()
    {
        /*while (enemyCount < 20)
        {
            Vector2 spawnPos = GameObject.Find("Player").transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
            enemyCount += 1;
            yield return new WaitForSeconds(time);
            StartCoroutine(SpawnAnEnemy());
        }*/

        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
