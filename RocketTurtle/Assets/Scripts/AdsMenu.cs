using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsMenu : MonoBehaviour
{
    [SerializeField] LoseMenu loseMenu;
    [SerializeField] AudioClip selectSound;
    public void showLoseMenu()
    {
        loseMenu.showLoseMenu(ScoreManager.compareScore());
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.3f);
        gameObject.SetActive(false);
    }
}
