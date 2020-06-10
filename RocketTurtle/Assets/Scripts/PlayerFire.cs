using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject cannonTip;
    [SerializeField] TextMeshProUGUI fireButtonText;

    BulletManager bm;

    private void Start()
    {
        bm = FindObjectOfType<BulletManager>();
    }

    private void Update()
    {
        if (bm.getCurrentProjectileTime() > 0)
        {
            fireButtonText.SetText(bm.getCurrentProjectileTime().ToString().Substring(0, 3));
        }

        else
        {
            fireButtonText.SetText("FIRE");
        }
        
    }


    public void fire()
    {
        if(bm.getCurrentProjectileTime() <= 0)
        {
            Projectile bullet = Instantiate(bm.getCurrentProjectile(), cannonTip.transform.position, Quaternion.identity);
            bm.restartCurrentProjectileTime();
        }
    }
}
