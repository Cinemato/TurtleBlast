using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject cannonTip;
    [SerializeField] TextMeshProUGUI fireButtonText;
    [SerializeField] BulletContainer bulletContainer;

    [SerializeField] CameraShake cm;

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
        if(BulletContainer.currentBulletTime <= 0)
        {
            GameObject i = Instantiate(BulletContainer.currentBullet.getPrefab(), cannonTip.transform.position, Quaternion.identity);  //Spawning Bullet Depending On The Position Of Cannon Tip
            Debug.Log(i.tag);
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
}
