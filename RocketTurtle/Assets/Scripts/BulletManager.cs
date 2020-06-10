using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [Header("Cannon Ball")]
    [SerializeField] float cannonBallSpeed = 8f;
    [SerializeField] float timeInSecondsTilNextCannon = 2f;
    [SerializeField] Projectile cannonBallPrefab;

    [Header("Laser")]
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float timeInSecondsTilNextLaser = 0;
    [SerializeField] Projectile laserPrefab;

    [Header("Bullet Icons")]
    [SerializeField] GameObject[] icons;

    //Current Bullet
    Projectile currentProjectile;
    float currentProjectileTime;


    void Start()
    {
        currentProjectile = cannonBallPrefab;
        currentProjectileTime = 0;

        showIcon();
    }
    
    void Update()
    {
        currentProjectileTime -= Time.deltaTime;
    }

    public float getCannonBallSpeed()
    {
        return cannonBallSpeed;
    }

    public float getCannonBallTime()
    {
        return timeInSecondsTilNextCannon;
    }

    public void restartCurrentProjectileTime()
    {
        if(currentProjectile.tag == "CannonBall")
        {
            currentProjectileTime = timeInSecondsTilNextCannon;
        }

        if(currentProjectile.tag == "Laser")
        {
            currentProjectileTime = timeInSecondsTilNextLaser;
        }
    }

    public void showIcon()
    {
        foreach(GameObject icon in icons)
        {
            if(icon.tag.Equals(currentProjectile.tag))
            {
                icon.SetActive(true);
            }

            else
            {
                icon.SetActive(false);
            }
        }
    }

    public float getLaserSpeed()
    {
        return laserSpeed;
    }

    public float getLaserTime()
    {
        return timeInSecondsTilNextLaser;
    }

    public Projectile getCannonBallPrefab()
    {
        return cannonBallPrefab;
    }

    public Projectile getLaserPrefab()
    {
        return laserPrefab;
    }

    public void setCurrentProjectile(Projectile projectile)
    {
        currentProjectile = projectile;
        currentProjectileTime = projectile.getTime();
    }

    public Projectile getCurrentProjectile()
    {
        return currentProjectile;
    }

    public float getCurrentProjectileTime()
    {
        return currentProjectileTime;
    }

}
