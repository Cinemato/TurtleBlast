using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp = 5;
    [SerializeField] int damage;
    [SerializeField] ParticleSystem deathVFX;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Projectile>())
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();           
            ParticleSystem hitVFX = Instantiate(projectile.getHitVFX(), collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(hitVFX, 2f);

            recieveDamage(projectile.getDamage());
        }

        else if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            ParticleSystem explodeVFX = Instantiate(deathVFX, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            explode();
        }
    }

    void recieveDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            explode();
        }
    }

    void explode()
    {
        ParticleSystem explodeVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explodeVFX, 2f);
        EnemySpawner.count--;
        Destroy(gameObject);
    }
}
