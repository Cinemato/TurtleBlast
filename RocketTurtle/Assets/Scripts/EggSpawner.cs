using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] eggs;
    [SerializeField] float timeTilNextEgg = 30f;

    BulletManager bm;

    private void Start()
    {
        bm = FindObjectOfType<BulletManager>();

        StartCoroutine(spawnEgg());
    }

    IEnumerator spawnEgg()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeTilNextEgg);
            spawnNextEgg();
        }
    }

    void spawnNextEgg()
    {
        GameObject eggIndex = eggs[Random.Range(0, eggs.Length)];
        while(eggIndex.tag == bm.getCurrentProjectile().tag)
        {
            eggIndex = eggs[Random.Range(0, eggs.Length)];
        }

        GameObject egg = Instantiate(eggIndex, transform.position, Quaternion.identity);        
        egg.transform.position = new Vector2(Random.Range(-8f, 8f), transform.position.y);
    }
}
