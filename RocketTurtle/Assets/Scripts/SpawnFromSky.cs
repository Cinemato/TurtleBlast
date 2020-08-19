using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFromSky : MonoBehaviour
{
    [SerializeField] GameObject[] objects = null;
    [SerializeField] float minX = -8f;
    [SerializeField] float maxX = 8f;
    [SerializeField] bool spawnEggs;
    [SerializeField] bool spawnNearPlayer;
    [SerializeField] float minDuration;
    [SerializeField] float maxDuration;
    [SerializeField] GameObject player;

    GameObject index;

    private void Start()
    {
        StartCoroutine(spawnObjects());
    }


    IEnumerator spawnObjects()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minDuration, maxDuration));
            spawn();
        }
    }

    void spawn()
    {
        index = objects[Random.Range(0, objects.Length)];
        if (spawnEggs)
            spawnEgg();
        GameObject thing = Instantiate(index, transform.position, Quaternion.identity);

        if(spawnNearPlayer)
        {
            minX = Mathf.Clamp(player.transform.position.x - 4, -8, 8);
            maxX = Mathf.Clamp(player.transform.position.x + 4, -8, 8);
        }

        thing.transform.position = new Vector2(Random.Range(minX, maxX), transform.position.y);
    }

    void spawnEgg()
    {
        while (index.tag == BulletContainer.currentBullet.getPrefab().tag)  //Checking If The Chosen Egg Is The Same As The Current Ammo
        {
            index = objects[Random.Range(0, objects.Length)];  //If So Then Chaning It To Another Random Egg From Array
        }

        return;
    }
}
