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
        if (removeBullets)
        {
            if (collision.gameObject.GetComponent<Projectile>())
            {
                Destroy(collision.gameObject);
            }
        }

        if (removeClouds)
        {
            if (collision.gameObject.CompareTag("Cloud"))
            {
                Destroy(collision.gameObject);
            }
        }

        if(removeEnemies)
        {
            if(collision.gameObject.GetComponent<Enemy>())
            {
                EnemySpawner.count--;
                Destroy(collision.gameObject);
            }
        }
    }
}
