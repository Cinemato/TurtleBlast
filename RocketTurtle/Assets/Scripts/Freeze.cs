using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    [SerializeField] float freezeTime = 5f;
    [SerializeField] Color freezeColor;
    [SerializeField] GameObject freezeVFX;
    [SerializeField] AudioClip pickupSound;

    Enemy[] enemies;

    public float timer = 0;

    bool hit = false;
    bool done = false;

    private void Update()
    {
        if(hit)
        {
            timer += Time.deltaTime;

            if(timer >= freezeTime && !done)
            {
                stopFreeze(enemies);
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            GameObject vfx = Instantiate(freezeVFX, transform.position, Quaternion.identity);
            Destroy(vfx, 3f);

            hit = true;
            Enemy[] enemies = FindObjectsOfType<Enemy>();

            for(int i = 0; i < enemies.Length; i++)
            {
                this.enemies = enemies;
                enemies[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

                if(enemies[i].GetComponent<Animator>())
                    enemies[i].GetComponent<Animator>().enabled = false;

                enemies[i].GetComponent<SpriteRenderer>().color = freezeColor;

                if(enemies[i].transform.childCount > 0)
                {
                    if(enemies[i].transform.GetChild(0).GetComponent<SpriteRenderer>())
                        enemies[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = freezeColor;
                }
                    
            }

            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<TrailRenderer>().enabled = false;
            Destroy(gameObject, 10f);
        }
    }

    void stopFreeze(Enemy[] enemies)
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i] != null)
            {
                Rigidbody2D rb = enemies[i].GetComponent<Rigidbody2D>();
                if (enemies[i].GetComponent<Animator>())
                    enemies[i].GetComponent<Animator>().enabled = true;

                enemies[i].GetComponent<SpriteRenderer>().color = Color.white;
                if (enemies[i].transform.childCount > 0)
                {
                    if (enemies[i].transform.GetChild(0).GetComponent<SpriteRenderer>())
                        enemies[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                }

                rb.constraints = RigidbodyConstraints2D.None;

                if (enemies[i].GetComponent<MoveObject>())
                    enemies[i].GetComponent<MoveObject>().move();
                else if (enemies[i].GetComponent<EnemyProjectileMovement>())
                    enemies[i].GetComponent<EnemyProjectileMovement>().move();
                else if (rb.isKinematic == false)
                {
                    rb.isKinematic = true;
                    rb.isKinematic = false;
                }
            }
        }          
        done = true;
    }
}
