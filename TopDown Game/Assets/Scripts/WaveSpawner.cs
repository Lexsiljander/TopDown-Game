using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Text waveCountText;
    int waveCount = 0;

    public float spawnRate = 1.0f;
    public float timeBetweenWaves = 5.0f;

    public int enemyCount;

    public GameObject enemy;
    public GameObject shootingEnemy;

    bool waveIsDone = true;



    [SerializeField]
    private float spawnRadius = 7;

    public GameObject[] enemies;
    public GameObject player;

    void Update()
    {
        waveCountText.text = "Wave: " + waveCount.ToString();


        print(GameObject.FindGameObjectsWithTag("Enemy").Length);

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            // Show 'Cleared' UI menu

            waveIsDone = true;
        }

        if (waveIsDone == true)
        {
            StartCoroutine(waveSpawner());
           
        }
    }
    

    IEnumerator waveSpawner()
    {

        waveIsDone = false;

        for (int i = 0; i < enemyCount; i++)
        {
            //GameObject enemyClone = Instantiate(enemy);


            Vector2 spawnPos = GameObject.Find("Player").transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);


            yield return new WaitForSeconds(spawnRate);
        }

        spawnRate -= 0.1f;
        enemyCount += 1;
        waveCount += 1;

        //yield return new WaitForSeconds(timeBetweenWaves);

       
    }
   
   
}
