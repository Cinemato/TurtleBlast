using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemies = null;   
    [SerializeField] float timeTilEachSpawn = 3;
    [SerializeField] int maxEnemyCount = 10;
    [SerializeField] int requiredScoreDifferneceForDifficulty = 5;

    public static int count = 0;

    int previousScore = 0;
    Vector2 enemyPosition;
    float minY = -4f;
    float maxY = 4f;

    private void Start()
    {
        count = 0;
        StartCoroutine(spawnEnemies());
    }

    private void Update()
    {
        if (timeTilEachSpawn > 0.5f)
            checkScoreForSpawnLevel();

        if (ScoreManager.currentScore >= 60)
            maxEnemyCount = 20;

        if (ScoreManager.currentScore >= 150)
            timeTilEachSpawn = 0.325f           
                ;
        if (ScoreManager.currentScore >= 350)
            timeTilEachSpawn = 0.3f;

        if (ScoreManager.currentScore >= 600)
            timeTilEachSpawn = 0.275f;
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
            //if(player.transform.position.y >= 0)
            //{
            //    minY = 0;
            //    maxY = 4;
            //}

            //else
            //{
            //    minY = -4;
            //    maxY = 0;
            //}

            enemyPosition = new Vector2(transform.position.x, Random.Range(minY, maxY));
            int enemyIndex = Random.Range(0, enemies.Length);
            Enemy enemy = enemies[enemyIndex];

            if (GameObject.FindGameObjectsWithTag(enemy.tag).Length >= enemy.getSpawnLimit())
            {
                Debug.Log("Too Many" + enemy.tag + "Count: " + GameObject.FindGameObjectsWithTag(enemy.tag).Length);
                enemyIndex = randomNumberExcept(0, enemies.Length, enemyIndex);
                enemy = enemies[enemyIndex];
            }       

            if (Random.value > enemy.getSpawnChance() && ScoreManager.currentScore >= enemy.getScoreToSpawn())
            {
                Instantiate(enemy, enemyPosition, Quaternion.identity);
                count++;
            }
            
            else
            {
                spawnEnemy();
            }
        }       
    }

    void checkScoreForSpawnLevel()
    {
        if (ScoreManager.currentScore - previousScore >= requiredScoreDifferneceForDifficulty)
        {
            previousScore = ScoreManager.currentScore;

            if (ScoreManager.currentScore < 30 || ScoreManager.currentScore >= 50)
            {
                timeTilEachSpawn -= 0.25f;
            }           
        }
    }

    private int randomNumberExcept(int min, int max, int except)
    {
        int number = Random.Range(min, max);

        while(number == except)
            number = Random.Range(min, max);

        return number;
    }
}
