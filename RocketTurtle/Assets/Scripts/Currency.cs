using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starsText = null;
    
    public static int currentStars = 0;

    private void Start()
    {
        starsText.text = PlayerPrefs.GetInt("Stars", 0).ToString();
    }

    public static void addStars(int amount, GameObject star, Vector2 pos, AudioClip sound)
    {
        currentStars += amount;
        GameObject starAnimation = Instantiate(star, pos, Quaternion.identity);
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, 0.5f);
        Destroy(starAnimation, 2f);
        PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars", 0) + amount);
    }
}
