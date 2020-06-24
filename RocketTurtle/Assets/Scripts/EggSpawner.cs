using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] eggs;
    [SerializeField] float timeTilNextEgg = 30f;


    private void Start()
    {
        StartCoroutine(spawnEgg());
    }

    IEnumerator spawnEgg()
    {
        //Coroutine That Spawns Eggs Forever
        while(true)
        {
            yield return new WaitForSeconds(timeTilNextEgg);
            spawnNextEgg();
        }
    }

    void spawnNextEgg()
    {
        GameObject eggIndex = eggs[Random.Range(0, eggs.Length)];  //Setting Index To A Random Egg From Array
        while(eggIndex.tag == BulletContainer.currentBullet.getPrefab().tag)  //Checking If The Chosen Egg Is The Same As The Current Ammo
        {
            eggIndex = eggs[Random.Range(0, eggs.Length)];  //If So Then Chaning It To Another Random Egg From Array
        }

        GameObject egg = Instantiate(eggIndex, transform.position, Quaternion.identity);        
        egg.transform.position = new Vector2(Random.Range(-8f, 8f), transform.position.y);  //Spawning Chosen Egg To Random X Axis Position Using Egg Index
    }
}
