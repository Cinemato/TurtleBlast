using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] LoseMenu loseMenu;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip explodeSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>())
        {
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, 0.8f);
            AudioSource.PlayClipAtPoint(explodeSFX, Camera.main.transform.position);
            bool newScore = ScoreManager.compareScore();
            loseMenu.showLoseMenu(newScore);
            Destroy(vfx, 5f);
            Destroy(gameObject);
        }
    }
}
