using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyRespawn : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip failSFX;

    public void buy()
    {
        if (PlayerPrefs.GetInt("Stars", 0) >= price)
        {
            PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") - price);
            AudioSource.PlayClipAtPoint(successSFX, Camera.main.transform.position, 0.7f);
            PlayerStats.instance.respawn();
        }

        else
            AudioSource.PlayClipAtPoint(failSFX, Camera.main.transform.position, 0.7f);

    }
}
