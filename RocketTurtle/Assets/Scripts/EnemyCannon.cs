using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    [SerializeField] GameObject bullet = null;
    [SerializeField] GameObject shootVFX = null;
    [SerializeField] GameObject cannonTip = null;
    [SerializeField] AudioClip shootSFX = null;
    [SerializeField] float movementSpeed = 5;
    [SerializeField] float offset = 0f;
    [SerializeField] float timeBeforeFire = 3f;
    [SerializeField] float timeBeforeStopMin = 3f;
    [SerializeField] float timeBeforeStopMax = 4f;

    PlayerMovement player;
    Rigidbody2D rb;
    bool isMoving = true;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-movementSpeed, 0);
        StartCoroutine(moveAndStop());
    }

    private void Update()
    {
        if(player != null)
        {
            if (!isMoving && player.transform.position.x < transform.position.x && rb.constraints == RigidbodyConstraints2D.None)
            {
                Vector2 difference = player.transform.position - transform.position;
                float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
            }
            
            if(transform.position.x >= 9.67 && rb.constraints == RigidbodyConstraints2D.FreezeAll)
            {
                EnemySpawner.count--;
                Destroy(gameObject);
            }
        }
    }

    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBeforeFire);
            if(player.GetComponent<PlayerMovement>().enabled && rb.constraints == RigidbodyConstraints2D.None)
            {
                if (player.transform.position.x < transform.position.x)
                {
                    GameObject b = Instantiate(bullet, cannonTip.transform.position, Quaternion.identity);
                    GameObject vfx = Instantiate(shootVFX, cannonTip.transform.position, Quaternion.identity);
                    AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position);
                    Destroy(b, 15f);
                    Destroy(vfx, 1f);
                }
            }                                  
        }
    }

    IEnumerator moveAndStop()
    {
        rb.velocity = new Vector2(-movementSpeed, 0);
        yield return new WaitForSeconds(Random.Range(timeBeforeStopMin, timeBeforeStopMax));
        isMoving = false;
        StartCoroutine(shoot());
        rb.velocity = new Vector2(0, 0);
    }

}
