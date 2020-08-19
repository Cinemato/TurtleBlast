using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBall : MonoBehaviour
{
    [SerializeField] AudioClip pickupSound;
    [SerializeField] GameObject explosionVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(vfx, 3f);

            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach(Enemy e in enemies)
            {
                e.explode();
            }

            Destroy(gameObject);
        }
    }
}
