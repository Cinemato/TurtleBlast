using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Will Get Input From Bullet Container
    float timeTilNext;
    float damage;
    GameObject hitVFX;
    GameObject bulletPrefab;
    Sprite cannonSprite;
    AudioClip shootSFX;
    string name;

    private void Start()
    {
        for(int i = 0; i < BulletContainer.projectiles.Count; i++)
        {
            if(BulletContainer.projectiles[i].name == tag)
            {
                timeTilNext = BulletContainer.projectiles[i].timeTilNext;
                damage = BulletContainer.projectiles[i].damage;
                hitVFX = BulletContainer.projectiles[i].hitVFX;
                bulletPrefab = BulletContainer.projectiles[i].bulletPrefab;
                cannonSprite = BulletContainer.projectiles[i].cannonSprite;
                shootSFX = BulletContainer.projectiles[i].shootSFX;
            }
        }
    }
    public static Projectile newProjectile(float timeTilNext, float damage, GameObject hitVFX, GameObject bulletPrefab, Sprite cannonSprite, AudioClip shootSFX, string name)
    {
        Projectile projectile = new GameObject("Projectiles").AddComponent<Projectile>();

        projectile.timeTilNext = timeTilNext;
        projectile.damage = damage;
        projectile.hitVFX = hitVFX;
        projectile.bulletPrefab = bulletPrefab;
        projectile.cannonSprite = cannonSprite;
        projectile.shootSFX = shootSFX;
        projectile.name = name;

        return projectile;
    }

    public float getTime()
    {
        return timeTilNext;
    }

    public Sprite getCannonSprite()
    {
        return cannonSprite;
    }

    public GameObject getHitVFX()
    {
        return hitVFX;
    }

    public float getDamage()
    {
        return damage;
    }

    public GameObject getPrefab()
    {
        return bulletPrefab;
    }
    public AudioClip getShootSFX()
    {
        return shootSFX;
    }

    public void setPrefab(GameObject prefab)
    {
        this.bulletPrefab = prefab;
    }

    public string getName()
    {
        return name;
    }
}
