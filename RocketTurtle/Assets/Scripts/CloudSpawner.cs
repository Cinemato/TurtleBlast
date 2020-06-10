using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] clouds;
    int index = 0;

    private void Start()
    {
        StartCoroutine(spawnCloudCor());
    }

    IEnumerator spawnCloudCor()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            spawnCloud();
        }
    }

    void spawnCloud()
    {
        GameObject cloud = Instantiate(clouds[index], transform.position, Quaternion.identity);
        cloud.transform.position = new Vector2(transform.position.x, Random.Range(-3, 3.5f));
        index++;

        if(index == clouds.Length)
        {
            index = 0;
        }

        Destroy(cloud, 6f);
    }
}
