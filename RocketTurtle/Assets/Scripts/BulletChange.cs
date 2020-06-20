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
            switch (tag)
            {
                case "CannonBall": 
                    bm.setCurrentProjectile(bm.getCannonBallPrefab()); 
                    break;

                case "Laser":
                    bm.setCurrentProjectile(bm.getLaserPrefab());
                    break;

                case "Ray":
                    bm.setCurrentProjectile(bm.getRayPrefab());
                    break;
            }
      
            bm.showIcon(); //Showing Icon Of New Ammo
            Destroy(gameObject);  //Destroying Egg After Collision With Player
        }
    }
}
