using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp = 5;
    [SerializeField] int damage;
    [SerializeField] GameObject deathVFX = null;
    [SerializeField] AudioClip explosionSFX = null;
    [SerializeField] AudioClip hitSFX = null;


    PlayerFire pf;

    private void Start()
    {
        pf = FindObjectOfType<PlayerFire>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Projectile>())
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();           
            GameObject hitVFX = Instantiate(projectile.getHitVFX(), collision.gameObject.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position, 4);
            Destroy(collision.gameObject);
            Destroy(hitVFX, 2f);

            
            recieveDamage(projectile.getDamage());
        }

        else if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            GameObject explodeVFX = Instantiate(deathVFX, collision.gameObject.transform.position, Quaternion.identity);
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
        
        else
        {
            pf.shakeCamera(0.05f, 0.05f);
        }
    }

    void explode()
    {
        GameObject explodeVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explodeVFX, 2f);
        EnemySpawner.count--;
        AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position, 0.6f);
        pf.shakeCamera(0.3f, 0.05f);
        Destroy(gameObject);
    }
}
