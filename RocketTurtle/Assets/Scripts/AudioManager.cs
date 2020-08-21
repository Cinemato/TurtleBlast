using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sprite soundImage;
    [SerializeField] Sprite mutedSoundImage;

    [SerializeField] GameObject muteButton;


    private void Start()
    {
        if (PlayerPrefs.GetInt("hasSound") == 1) //0 = True, 1 = False
        {
            muteButton.GetComponent<Image>().sprite = mutedSoundImage;
            AudioListener.volume = 0;
        }

        else
        {
            muteButton.GetComponent<Image>().sprite = soundImage;
            AudioListener.volume = 1;
        }
    }

    public void toggleSound()
    {
        if (PlayerPrefs.GetInt("hasSound", 0) == 0)
        {
            PlayerPrefs.SetInt("hasSound", 1);
            muteButton.GetComponent<Image>().sprite = mutedSoundImage;
            AudioListener.volume = 0;
        }

        else
        {
            PlayerPrefs.SetInt("hasSound", 0);
            muteButton.GetComponent<Image>().sprite = soundImage;
            AudioListener.volume = 1;
        }
    }





}
