using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerFire : MonoBehaviour
{
    [SerializeField] CannonTip[] cannonTips;
    [SerializeField] GameObject[] reservers;
    [SerializeField] TextMeshProUGUI fireButtonText;
    [SerializeField] BulletContainer bulletContainer;
    [SerializeField] PlayerStats ps;
    [SerializeField] CameraShake cm;

    public static PlayerFire instance;

    public void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Update()
    {
        if (BulletContainer.currentBulletTime > 0)  //Checking If Shooting Timer Is Finished Or Not
        {
            fireButtonText.SetText(BulletContainer.currentBulletTime.ToString().Substring(0, 3)); //Changing Text
        }

        else
        {
            fireButtonText.SetText("FIRE");
        }
        
    }

    public void fire()
    {     
        if(BulletContainer.currentBulletTime <= 0 && GetComponent<PlayerMovement>().enabled)
        {
            for(int i = 0; i < cannonTips.Length; i++)
            {
                if(cannonTips[i].getIsUsed())
                {
                    GameObject a = Instantiate(BulletContainer.currentBullet.getPrefab(), cannonTips[i].transform.position, Quaternion.identity);  //Spawning Bullet Depending On The Position Of Cannon Tip
                    a.transform.SetParent(reservers[i].transform);
                }
            }
            
            AudioSource.PlayClipAtPoint(BulletContainer.currentBullet.getShootSFX(), Camera.main.transform.position, 0.5f);
            bulletContainer.restartCurrentProjectileTime();  //Restating The Shooting Timer Of The Current Projectile
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletChange>())
        {
            bulletContainer.showIcon();
        }
    }

    public void shakeCamera(float mag, float duration)
    {
        StartCoroutine(cm.Shake(mag, duration));
    }

    public void changeNumberOfWeapons()
    {
        switch(ps.getNumberOfWeapons())
        {
            case 2:
                cannonTips[0].setIsUsed(false);
                cannonTips[1].setIsUsed(true);
                cannonTips[2].setIsUsed(true);
                break;

            case 3:
                cannonTips[0].setIsUsed(true);
                break;

            default:
                Debug.Log("Error"); break;
        }                              
    }
}

