using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChange : MonoBehaviour
{
    private void Start()
    {
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
                    BulletContainer.setCurrentProjectile(BulletContainer.cannonBall); 
                    break;

                case "Laser":
                    BulletContainer.setCurrentProjectile(BulletContainer.laser);
                    break;

                case "Ray":
                    BulletContainer.setCurrentProjectile(BulletContainer.rayBeam);
                    break;
            }
      
            BulletContainer.currentBulletTime = 0;
            Destroy(gameObject);  //Destroying Egg After Collision With Player
        }
    }
}
