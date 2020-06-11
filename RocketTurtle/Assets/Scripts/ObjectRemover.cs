    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] bool removeBullets;
    [SerializeField] bool removeEnemies;
    [SerializeField] bool removeClouds;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroying Objects Depending On Boolean Input
        if(removeBullets)
        {
            if(collision.gameObject.GetComponent<Projectile>())
            {
                Destroy(collision.gameObject);
            }
        }

        if(removeClouds)
        {
            if(collision.gameObject.GetComponent<Cloud>())
            {
                Destroy(collision.gameObject);
            }
        }

        if(removeEnemies)
        {
            //Remove Enemies (WIP)
        }
    }
}
