using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField] float timeTilNextCycle = 180f; //Seconds

    Animator anime;
    void Start()
    {
        anime = GetComponent<Animator>();

        StartCoroutine(DayCycle());

        
    }


    IEnumerator DayCycle()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeTilNextCycle);
            cycle();           
        }
    }

    void cycle()
    {
        if (anime.GetBool("isDay"))
        {
            anime.SetBool("isDay", false);
        }

        else
        {
            anime.SetBool("isDay", true);
        }
    }
}
