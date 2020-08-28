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
                Skins.hasBought[i] = PlayerPrefs.GetInt("HasBought" + i, 1); //Setting all skins to bought
            }

            iapButton.SetActive(false);
        }
    }
}
