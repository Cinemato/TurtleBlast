using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOneSpawner : MonoBehaviour
{
    [SerializeField] GameObject powerUp = null;
    [SerializeField] PlayerStats ps;
    [SerializeField] float minX = -8f;
    [SerializeField] float maxX = 8f;
    [SerializeField] float timeTilFirstPowerUp = 100;
    [SerializeField] float timeTilSecondPowerUp = 200;

    float time;


    private void Start()
    {
        time = timeTilFirstPowerUp;

        StartCoroutine(spawnPowerUp());
    }

    IEnumerator spawnPowerUp()
    {
        while(true)
        {
            yield return new WaitForSeconds(time);
            if (ps.getNumberOfWeapons() < 3)
                spawn();
        }
    }

    void spawn()
    {
        Vector2 pos = new Vector2(FindObjectOfType<PlayerMovement>().transform.position.x, transform.position.y);
        GameObject stuff = Instantiate(powerUp, pos, Quaternion.identity);
        time = timeTilSecondPowerUp;
    }
}