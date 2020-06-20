using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] bool day;

    Animator anime;
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(day)
        {
            anime.SetBool("isDay", true);
        }

        else if(!day)
        {
            anime.SetBool("isDay", false);
        }
    }
}
