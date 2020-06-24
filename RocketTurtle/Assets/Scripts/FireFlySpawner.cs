using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlySpawner : MonoBehaviour
{
    [SerializeField] GameObject fireFlyPrefab;
    [SerializeField] float timeTilNextFireFly = 5f;

    void Start()
    {
        StartCoroutine(spawnFireFliesCor());
    }

    void spawnFireFlies()
    {
        GameObject fireFly = Instantiate(fireFlyPrefab, transform.position, Quaternion.identity);
        fireFly.transform.position = new Vector2(transform.position.x, Random.Range(3.7f, -3.7f));
    }

    IEnumerator spawnFireFliesCor()
    {
        while(true)
        {
            if (!DayNight.anime.GetBool("isDay"))
            {
                yield return new WaitForSeconds(timeTilNextFireFly);
                spawnFireFlies();
            }

            else
            {
                yield return null;
            }
        }     
    }

}
