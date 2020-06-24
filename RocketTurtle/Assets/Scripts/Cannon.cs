using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject cannon = null;
    [SerializeField] GameObject cannonTip = null;
    [SerializeField] GameObject cannonChangeVFX = null;
    [SerializeField] AudioClip cannonChangeSFX = null;

    SpriteRenderer sr;

    private void Start()
    {
        sr = cannon.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<BulletChange>())
        {
            sr.sprite = BulletContainer.currentBullet.getCannonSprite();
            Vector2 vfxPosition = new Vector2(cannonTip.transform.position.x - 0.2f, cannonTip.transform.position.y);
            GameObject vfx = Instantiate(cannonChangeVFX, vfxPosition, Quaternion.identity);
            vfx.transform.parent = cannonTip.transform;
            AudioSource.PlayClipAtPoint(cannonChangeSFX, Camera.main.transform.position, 0.6f);

            Destroy(vfx, 2f);
        }
    }
}
