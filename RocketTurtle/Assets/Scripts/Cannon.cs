using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject cannon;
    [SerializeField] GameObject cannonTip;
    [SerializeField] ParticleSystem cannonChangeVFX;

    [SerializeField] Sprite normalCannon;
    [SerializeField] Sprite laserCannon;
    
    BulletManager bm;
    SpriteRenderer sr;

    private void Start()
    {
        bm = FindObjectOfType<BulletManager>();
        sr = cannon.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<BulletChange>())
        {
            switch (bm.getCurrentProjectile().tag)
            {
                case "CannonBall": 
                    sr.sprite = normalCannon; 
                    break;

                case "Laser": 
                    sr.sprite = laserCannon; 
                    break;
            }

            Vector2 vfxPosition = new Vector2(cannonTip.transform.position.x - 0.2f, cannonTip.transform.position.y);
            ParticleSystem vfx = Instantiate(cannonChangeVFX, vfxPosition, Quaternion.identity);
            vfx.transform.parent = cannonTip.transform;

            Destroy(vfx, 2f);
        }
    }
}
