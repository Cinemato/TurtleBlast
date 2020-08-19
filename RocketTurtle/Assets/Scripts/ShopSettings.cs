using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShopSettings : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Sprite[] skins;

    private void Update()
    {
       if(player != null)
       {
           player.GetComponent<SpriteRenderer>().sprite = skins[PlayerPrefs.GetInt("UsedSkin", 0)];
       }          
    }

}
