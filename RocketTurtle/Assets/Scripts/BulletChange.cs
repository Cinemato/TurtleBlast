using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChange : MonoBehaviour
{
    BulletManager bm;

    private void Start()
    {
        bm = FindObjectOfType<BulletManager>();

        //Destroying Egg After 4 Seconds
        Destroy(gameObject, 4f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Setting Current Projectile Depending On The Taken Egg

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

            bm.showIcon(); //Showing Icon Of New Ammo
            Destroy(gameObject);  //Destroying Egg After Collision With Player
        }
    }
}
