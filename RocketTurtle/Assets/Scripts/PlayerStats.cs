using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] bool hasShieldOn = false;
    [SerializeField] GameObject shield = null;
    [SerializeField] float shieldTime = 10;
    [SerializeField] int numberOfWeapons = 1;
    [SerializeField] GameObject player;
    [SerializeField] GameObject adsMenu;

    bool hasRespawned = false;

    public static PlayerStats instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public bool getHasShieldOn()
    {
        return hasShieldOn;
    }

    public int getNumberOfWeapons()
    {
        return numberOfWeapons;
    }

    public void incrementWeapons()
    {
        if(numberOfWeapons < 3)
            numberOfWeapons++;
    }

    public void setHasShieldOn(bool boolean)
    {
        hasShieldOn = boolean;

        if (hasShieldOn)
        {
            shield.SetActive(true);
            StartCoroutine(shieldTimer());
        }
            
    }

    IEnumerator shieldTimer()
    {
        yield return new WaitForSeconds(shieldTime);
        shield.SetActive(false);
        hasShieldOn = false;
    }

    public void respawn()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.transform.GetChild(0).gameObject.SetActive(true);
        player.transform.GetChild(1).gameObject.SetActive(true);

        hasRespawned = true;
        setHasShieldOn(true);
        adsMenu.SetActive(false);
    }

    public bool getHasRespawned()
    {
        return hasRespawned;
    }


}
