using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContainer : MonoBehaviour
{
    [Header("Cannon Ball")]
    [SerializeField] float timeInSecondsTilNextCannon = 2f;
    [SerializeField] float cannonBallDamage = 5;
    [SerializeField] GameObject cannonBallPrefab = null;
    [SerializeField] GameObject hitCannonVFX = null;
    [SerializeField] Sprite cannonSprite = null;
    [SerializeField] AudioClip cannonShootSFX = null;

    [Header("Laser")]
    [SerializeField] float timeInSecondsTilNextLaser = 0;
    [SerializeField] float laserDamage = 2;
    [SerializeField] GameObject laserPrefab = null;
    [SerializeField] GameObject hitLaserVFX = null;
    [SerializeField] Sprite laserCannonSprite = null;
    [SerializeField] AudioClip laserShootSFX = null;

    [Header("Ray Gun")]
    [SerializeField] float timeInSecondsTilNextRay = 0.5f;
    [SerializeField] float rayDamage = 2;
    [SerializeField] GameObject rayPrefab = null;
    [SerializeField] GameObject hitRayVFX = null;
    [SerializeField] Sprite rayCannon = null;
    [SerializeField] AudioClip rayShootSFX = null;

    [Header("Bullet Icons")]
    [SerializeField] GameObject[] icons = null;

    public static Projectile cannonBall;
    public static Projectile laser;
    public static Projectile rayBeam;

    public static Projectile currentBullet;
    public static float currentBulletTime;

    public static List<Projectile> projectiles = new List<Projectile>();
    

    private void Start()
    {
        cannonBall = Projectile.newProjectile(timeInSecondsTilNextCannon, cannonBallDamage, hitCannonVFX, cannonBallPrefab, cannonSprite, cannonShootSFX, "CannonBall");
        laser = Projectile.newProjectile(timeInSecondsTilNextLaser, laserDamage, hitLaserVFX, laserPrefab, laserCannonSprite, laserShootSFX, "Laser");
        rayBeam = Projectile.newProjectile(timeInSecondsTilNextRay, rayDamage, hitRayVFX, rayPrefab, rayCannon, rayShootSFX, "Ray");

        projectiles.Add(cannonBall);
        projectiles.Add(laser);
        projectiles.Add(rayBeam);

        currentBulletTime = 0;
        currentBullet = cannonBall;
        showIcon();
    }
        
    void Update()
    {
        currentBulletTime -= Time.deltaTime;
    }

    public static void setCurrentProjectile(Projectile projectile)
    {
        //Sets The Current Projectile With Its Shooting Time Using .getTime()
        currentBullet = projectile;
        currentBulletTime = projectile.getTime();
    }

    public void restartCurrentProjectileTime()
    {
        currentBulletTime = currentBullet.getTime();
    }

    public void showIcon()
    {
        //Showing Icon Of Ammo Type Using Foreach Loop And Tags
        foreach (GameObject icon in icons)
        {
            if (icon.tag.Equals(currentBullet.getPrefab().tag))
            {
                icon.SetActive(true);
            }

            else
            {
                icon.SetActive(false);
            }
        }
    }

    
}
