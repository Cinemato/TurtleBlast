using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    BulletManager bm;

    float speed;
    float timeTilNext;

    void Start()
    {
        bm = FindObjectOfType<BulletManager>();

        if(gameObject.tag == "CannonBall")
        {
            speed = bm.getCannonBallSpeed();
            timeTilNext = bm.getCannonBallTime();
        }

        else if(gameObject.tag == "Laser")
        {
            speed = bm.getLaserSpeed();
            timeTilNext = bm.getLaserTime();
        }

        Destroy(gameObject, 3f);
    }


    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    public float getTime()
    {
        return timeTilNext;
    }
}
