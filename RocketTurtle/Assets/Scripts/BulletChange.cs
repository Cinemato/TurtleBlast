using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChange : MonoBehaviour
{
    BulletManager bm;

    private void Start()
    {
        bm = FindObjectOfType<BulletManager>();

        Destroy(gameObject, 4f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            if(tag.Equals("CannonBall"))
            {
                bm.setCurrentProjectile(bm.getCannonBallPrefab());
            }

            if(tag.Equals("Laser"))
            {
                bm.setCurrentProjectile(bm.getLaserPrefab());
            }

            bm.showIcon();
            Destroy(gameObject);
        }
    }
}
