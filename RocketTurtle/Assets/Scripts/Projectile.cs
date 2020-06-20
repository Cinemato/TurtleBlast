﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    BulletManager bm;

    //Will Get Input From Bullet Manager
    float speed;
    float timeTilNext;
    int damage;
    GameObject hitVFX;

    void Start()
    {
        //Defining Bullet Manager
        bm = FindObjectOfType<BulletManager>();

        //Getting Different Results From BM Depending On Ammo Used
        switch (tag)
        {
            case "CannonBall":
                speed = bm.getCannonBallSpeed();
                timeTilNext = bm.getCannonBallTime();
                damage = bm.getCannonBallDamage();
                hitVFX = bm.getCannonVFX();
                break;

            case "Laser":
                speed = bm.getLaserSpeed();
                timeTilNext = bm.getLaserTime();
                damage = bm.getLaserDamage();
                hitVFX = bm.getLaserVFX();
                break;

            case "Ray":
                speed = bm.getRaySpeed();
                timeTilNext = bm.getRayTime();
                damage = bm.getRayDamage();
                hitVFX = bm.getRayVFX();
                break;
        }
    }

    void Update()
    {
        //Moving Projectile To The Right Using Rigidbody
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    public float getTime()
    {
        //To Be Used In BM Class
        return timeTilNext;
    }

    public int getDamage()
    {
        return damage;
    }

    public GameObject getHitVFX()
    {
        return hitVFX;
    }
}
