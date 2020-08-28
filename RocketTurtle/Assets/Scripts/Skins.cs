using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skins : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Sprite[] skins;
    [SerializeField] int[] skinPrices; //Prices for skins depending on their index. So price if skins[0] is skinPrices [0].
    [SerializeField] GameObject buyUI;
    [SerializeField] GameObject playUI;
    [SerializeField] TextMeshProUGUI priceText;   
    [SerializeField] AudioClip selectSound;
    [SerializeField] AudioClip failSound;
    [SerializeField] AudioClip buySound;
    [SerializeField] PurchaseCheck purchaseCheck;

    public static int[] hasBought; // Checks if a skin is bought or not. 1 for true, 0 for false.
    SpriteRenderer renderer;
    int currentSkinIndex;

    void Start()
    {
        currentSkinIndex = PlayerPrefs.GetInt("UsedSkin", 0); //Last Skin Selected

        hasBought = new int[skins.Length];
        hasBought[0] = 1; //1 Means The Skin Is Bought

        for(int i = 1; i < hasBought.Length; i++)
        {
            hasBought[i] = PlayerPrefs.GetInt("HasBought" + i, 0); //Setting all other skins to not bought
        }

        purchaseCheck.buyAllSkins();

        renderer = player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        priceText.text = skinPrices[currentSkinIndex].ToString();
        renderer.sprite = skins[currentSkinIndex];

        if (hasBought[currentSkinIndex] == 1)
        {
            PlayerPrefs.SetInt("UsedSkin", currentSkinIndex);
        }
    }

    public void rightMouseButton()
    {
        currentSkinIndex++;
        if(currentSkinIndex >= skins.Length)
        {
            currentSkinIndex = 0;
        }

        checkIfBought();

        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
    }

    public void leftMouseButton()
    {
        currentSkinIndex--;
        if(currentSkinIndex < 0)
        {
            currentSkinIndex = skins.Length - 1;
        }

        checkIfBought();

        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.5f);
    }

    void bought()
    {
        buyUI.SetActive(false);
        playUI.SetActive(true);
    }

    void notBought()
    {
        buyUI.SetActive(true);
        playUI.SetActive(false);
    }

    public void buy()
    {
        if(skinPrices[currentSkinIndex] <= PlayerPrefs.GetInt("Stars"))
        {
            hasBought[currentSkinIndex] = 1;
            PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") - skinPrices[currentSkinIndex]);            

            AudioSource.PlayClipAtPoint(buySound, Camera.main.transform.position, 0.7f);

            for (int i = 0; i < hasBought.Length; i++)
            {
                PlayerPrefs.SetInt("HasBought" + i, hasBought[i] == 1 ? 1 : 0);
            }

            bought();
        }

        else
        {
            AudioSource.PlayClipAtPoint(failSound, Camera.main.transform.position, 0.7f);
        }
    }

    private void checkIfBought()
    {
        if (hasBought[currentSkinIndex] == 1)
        {
            bought();
        }

        else if (hasBought[currentSkinIndex] <= 0)
        {
            notBought();
        }
    }

}
