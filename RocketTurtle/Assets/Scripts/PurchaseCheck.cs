using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseCheck : MonoBehaviour
{
    [SerializeField] GameObject iapButton;

    public void buyAllSkins()
    {
        if (PlayerPrefs.GetInt("AllSkins", 1) == 0)
        {
            for (int i = 1; i < Skins.hasBought.Length; i++)
            {
                Skins.hasBought[i] = 1; //Setting all skins to bought
                PlayerPrefs.SetInt("HasBought" + i, 1);
            }

            iapButton.SetActive(false);
        }
    }
}
