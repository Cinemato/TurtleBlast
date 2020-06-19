using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] float timeTilEachSpawn = 3;
    [SerializeField] int maxEnemyCount = 10;

    public static int count = 0;

    private void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeTilEachSpawn);
            spawnEnemy();         
        }
    }

    void spawnEnemy()
    {
        if (count < maxEnemyCount)
        {
            Vector2 enemyPosition = new Vector2(transform.position.x, Random.Range(-4, 4));
            Enemy enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);

            count++;
        }       
    }
}
