using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] clouds;

    //Index To Check Which Cloud To Spawn
    int index;

    private void Start()
    {
        StartCoroutine(spawnCloudCor());
    }

    IEnumerator spawnCloudCor()
    {
        //Non-Stop Coroutine To Spawn Clouds
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            spawnCloud();
        }
    }

    void spawnCloud()
    {
        index = Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[index], transform.position, Quaternion.identity);

        //Spawn Cloud At Random Y Axis Position
        cloud.transform.position = new Vector2(transform.position.x, Random.Range(-3, 3.5f));
    }
}
