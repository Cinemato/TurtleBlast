using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] PlayerStats ps;
    [SerializeField] LoseMenu loseMenu;
    [SerializeField] GameObject adMenu;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip explodeSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>())
        {   
            if(!ps.getHasShieldOn())
            {
                GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, 0.8f);
                AudioSource.PlayClipAtPoint(explodeSFX, Camera.main.transform.position);               

                if (ps.getHasRespawned())
                {
                    bool newScore = ScoreManager.compareScore();
                    loseMenu.showLoseMenu(newScore);
                }
                    
                else
                    adMenu.SetActive(true);

                Destroy(vfx, 5f);
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
            }           
        }
    }
}
