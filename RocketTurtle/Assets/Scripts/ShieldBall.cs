using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBall : MonoBehaviour
{
    [SerializeField] AudioClip pickupSound;
    [SerializeField] GameObject explosionVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            FindObjectOfType<PlayerStats>().setHasShieldOn(true);
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(vfx, 3f);
            Destroy(gameObject);
        }
    }
}
