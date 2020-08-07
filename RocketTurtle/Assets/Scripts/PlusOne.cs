using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOne : MonoBehaviour
{
    PlayerStats ps;
    PlayerFire pf;

    [SerializeField] GameObject powerUpVFX;
    [SerializeField] AudioClip powerUpSFX;

    private void Start()
    {
        ps = FindObjectOfType<PlayerStats>();
        pf = FindObjectOfType<PlayerFire>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            AudioSource.PlayClipAtPoint(powerUpSFX, Camera.main.transform.position);
            ps.incrementWeapons();
            pf.changeNumberOfWeapons();
            GameObject vfx = Instantiate(powerUpVFX, transform.position, Quaternion.identity);
            Destroy(vfx, 3f);
            Destroy(gameObject);
        }
    }
}
