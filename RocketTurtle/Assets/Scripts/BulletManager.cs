using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [Header("Cannon Ball")]
    [SerializeField] float cannonBallSpeed = 8f;
    [SerializeField] float timeInSecondsTilNextCannon = 2f;
    [SerializeField] int cannonBallDamage = 5;
    [SerializeField] Projectile cannonBallPrefab;
    [SerializeField] GameObject hitCannonVFX;

    [Header("Laser")]
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float timeInSecondsTilNextLaser = 0;
    [SerializeField] int laserDamage = 2;
    [SerializeField] Projectile laserPrefab;
    [SerializeField] GameObject hitLaserVFX;

    [Header("Ray Gun")]
    [SerializeField] float raySpeed = 8f;
    [SerializeField] float timeInSecondsTilNextRay = 0.5f;
    [SerializeField] int rayDamage = 2;
    [SerializeField] Projectile rayPrefab;
    [SerializeField] GameObject hitRayVFX;

    [Header("Bullet Icons")]
    [SerializeField] GameObject[] icons;

    //Current Bullet
    Projectile currentProjectile;
    float currentProjectileTime;


    void Start()
    {
        currentProjectile = cannonBallPrefab;

        //Setting Timer To 0 For Start
        currentProjectileTime = 0;

        showIcon();
    }

    void Update()
    {
        currentProjectileTime -= Time.deltaTime;
    }

    public void restartCurrentProjectileTime()
    {
        //Setting Current Projectile Timer Depending On Ammo Type
        switch (currentProjectile.tag)
        {
            case "CannonBall":
                currentProjectileTime = timeInSecondsTilNextCannon;
                break;

            case "Laser":
                currentProjectileTime = timeInSecondsTilNextLaser;
                break;

            case "Ray":
                currentProjectileTime = timeInSecondsTilNextRay;
                break;
        }
    }

    public void showIcon()
    {
        //Showing Icon Of Ammo Type Using Foreach Loop And Tags
        foreach (GameObject icon in icons)
        {
            if (icon.tag.Equals(currentProjectile.tag))
            {
                icon.SetActive(true);
            }

            else
            {
                icon.SetActive(false);
            }
        }
    }

    //Current Projectile Getters/Setters
    public void setCurrentProjectile(Projectile projectile)
    {
        //Sets The Current Projectile With Its Shooting Time Using .getTime()
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

    //Cannon Ball Getters
    public Projectile getCannonBallPrefab()
    {
        return cannonBallPrefab;
    }

    public GameObject getCannonVFX()
    {
        return hitCannonVFX;
    }

    public float getCannonBallSpeed()
    {
        return cannonBallSpeed;
    }

    public int getCannonBallDamage()
    {
        return cannonBallDamage;
    }

    public float getCannonBallTime()
    {
        return timeInSecondsTilNextCannon;
    }


    //Laser Getters
    public Projectile getLaserPrefab()
    {
        return laserPrefab;
    }

    public GameObject getLaserVFX()
    {
        return hitLaserVFX;
    }

    public float getLaserSpeed()
    {
        return laserSpeed;
    }

    public int getLaserDamage()
    {
        return laserDamage;
    }

    public float getLaserTime()
    {
        return timeInSecondsTilNextLaser;
    }

    //Ray Getters
    public Projectile getRayPrefab()
    {
        return rayPrefab;
    }

    public GameObject getRayVFX()
    {
        return hitRayVFX;
    }

    public float getRaySpeed()
    {
        return raySpeed;
    }

    public int getRayDamage()
    {
        return rayDamage;
    }

    public float getRayTime()
    {
        return timeInSecondsTilNextRay;
    }

   

    
   

   

   

    

  

   
}
